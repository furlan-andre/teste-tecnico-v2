using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using Rebus.Config;
using Thunders.TechTest.ApiService;
using Thunders.TechTest.ApiService.Extensions;
using Thunders.TechTest.ApiService.Pedagios.Handlers;
using Thunders.TechTest.Infra.Database;
using Thunders.TechTest.Infra.Extensions;
using Thunders.TechTest.OutOfBox.Queues;

var builder = WebApplication.CreateBuilder(args);

builder.AddRedisDistributedCache("cache");
builder.WebHost.ConfigureKestrel(
    serverOptions =>
    {
        serverOptions.Limits.MaxConcurrentConnections = 10_000;
        serverOptions.Limits.MaxConcurrentUpgradedConnections = 10_000;
        serverOptions.Limits.MaxRequestBodySize = 10 * 1024 * 1024;
        serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);
    } 
);

builder.Services.AddResiliencePipeline("http-pipeline", pipelineBuilder =>
{
    pipelineBuilder.AddRetry(new RetryStrategyOptions
    {
        MaxRetryAttempts = 3,
        Delay = TimeSpan.FromMilliseconds(200),
        BackoffType = DelayBackoffType.Exponential
    });
    
    pipelineBuilder.AddCircuitBreaker(new ()
    {
        FailureRatio = 0.3,
        SamplingDuration = TimeSpan.FromSeconds(10),
        MinimumThroughput = 8,
        BreakDuration = TimeSpan.FromSeconds(30)
    });
    
    pipelineBuilder.AddTimeout(TimeSpan.FromSeconds(5));
});

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            context.Request.Headers.Host.ToString(),
            _ => new()
            {
                AutoReplenishment = true,
                PermitLimit = 100,
                Window = TimeSpan.FromSeconds(1)
            }));
});

builder.Services.ConfigureHttpJsonOptions(options => 
{
    options.SerializerOptions.WriteIndented = false;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.AddServiceDefaults();
builder.Services.AddControllers();

var features = Features.BindFromConfiguration(builder.Configuration);

builder.Services.AddProblemDetails();

if (features.UseMessageBroker)
{
    builder.Services.AddBus(builder.Configuration, new SubscriptionBuilder());
}

if (features.UseEntityFramework)
{
    builder.Services.AddDatabase(builder.Configuration);
}
builder.Services.AddInfraServices();
builder.Services.AddServicesInjections();
builder.Services.AddRebusHandler<PedagioHandler>();

var app = builder.Build();

app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapControllers();

_ = Task.Run(async () =>
{
    await Task.Delay(TimeSpan.FromSeconds(15));
    
    try 
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        await db.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations");
    }
});
app.Run();
