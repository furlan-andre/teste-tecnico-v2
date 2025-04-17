using Microsoft.Extensions.DependencyInjection;

var builder = DistributedApplication.CreateBuilder(args);


builder.AddServiceDefaults();
builder.Services.AddControllers();

var features = Features.BindFromConfiguration(builder.Configuration);

// Add services to the container.
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


builder.Build().Run();