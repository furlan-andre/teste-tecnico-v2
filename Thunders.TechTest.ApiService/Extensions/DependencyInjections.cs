using Thunders.TechTest.ApiService.Estados.Services;
using Thunders.TechTest.ApiService.Pedagios.Services.Agendador;
using Thunders.TechTest.ApiService.Pedagios.Services.CriarPedagioService;
using Thunders.TechTest.ApiService.Persistencia;
using Thunders.TechTest.ApiService.Pracas.ConsultaPraca;
using Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Agendadores;
using Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Services;
using Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Agendadores;
using Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Services;
using Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Agendadores;
using Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Services;
using Thunders.TechTest.ApiService.Tarifa.ArmazenadorTarifa;
using Thunders.TechTest.ApiService.Tarifa.ConsultaTarifa;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Infra.Repositories;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Extensions;

public static class DependencyInjections
{
    public static IServiceCollection AddServicesInjections(this IServiceCollection services)
    {
        services.AddScoped<ICriarPedagioService, CriarPedagioService>();
        services.AddScoped<IMessageSender, RebusMessageSender>();
        services.AddScoped<IAgendadorCriarPedagio, AgendadorCriarPedagio>();
        services.AddScoped<IConsultaPracaService, ConsultaPracaService>();
        services.AddScoped<IConsultaCidadeService, ConsultaCidadeService>();
        services.AddScoped<IConsultaEstadoService, ConsultaEstadoService>();
        services.AddScoped<IArmazenadorTarifa, ArmazenadorTarifa>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IConsultarTarifa, ConsultarTarifa>();
        services.AddScoped<IPedagioRepository, PedagioRepository>();
        services.AddScoped<IAgendadorRanqueamentoMensalPorPraca, AgendadorRanqueamentoMensalPorPraca>();
        services.AddScoped<IRanqueamentoMensalPorPracaService, RanqueamentoMensalPorPracaService>();
        services.AddScoped<IQuantidadeTipoPracaService, QuantidadeTipoPracaService>();
        services.AddScoped<IAgendadorQuantidadeTipoPraca, AgendadorQuantidadeTipoPraca>();
        services.AddScoped<IAgendadorTotalPorHoraCidade, AgendadorTotalPorHoraCidade>();
        services.AddScoped<ITotalPorHoraCidadeService, TotalPorHoraCidadeService>();
        
        return services;
    }
}