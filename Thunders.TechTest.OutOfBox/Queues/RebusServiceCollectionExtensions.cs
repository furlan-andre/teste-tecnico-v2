using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;
using Rebus.Retry.Simple;
using Thunders.TechTest.Domain.Pedagios.Dtos;
using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.OutOfBox.Queues
{
    public static class RebusServiceCollectionExtensions
    {
        public static IServiceCollection AddBus(
            this IServiceCollection services, 
            IConfiguration configuration, 
            SubscriptionBuilder? subscriptionBuilder = null)
        {
            services.AutoRegisterHandlersFromAssembly(Assembly.GetEntryAssembly());
            services.AddRebus(c => c
                    
                    .Transport(t =>
                    {
                        t.UseRabbitMq(configuration.GetConnectionString("RabbitMq"), "Thunders.TechTest")
                            .AddClientProperties(new Dictionary<string, string> {["performance"] = "high"})
                            .Prefetch(50);
                    })
                    .Options(o =>
                    {
                        o.SetNumberOfWorkers(Environment.ProcessorCount * 2);
                        o.SetMaxParallelism(50);
                        o.RetryStrategy(maxDeliveryAttempts: 3, secondLevelRetriesEnabled: true);
                    }), 
                onCreated: async bus =>
                {
                    if (subscriptionBuilder != null)
                    {
                        foreach (var type in subscriptionBuilder.TypesToSubscribe)
                        {
                            await bus.Subscribe(type);
                        }
                    }
                });

            return services;
        }
    }

    public class SubscriptionBuilder
    {
        internal List<Type> TypesToSubscribe { get; private set; } = 
            [
                typeof(PedagioDto),
                typeof(RanqueamentoMensalPorPracaDto),
                typeof(RelatorioQuantidadeTipoPracaDto),
                typeof(RelatorioTotalHoraCidadeDto)
            ];

        public SubscriptionBuilder Add<T>()
        {
            TypesToSubscribe.Add(typeof(T));

            return this;
        }
    }
}
