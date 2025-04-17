using Microsoft.Extensions.DependencyInjection;
using Thunders.TechTest.Domain.Cidades.Dtos;
using Thunders.TechTest.Domain.Estados;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pracas;
using Thunders.TechTest.Domain.Relatorios;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;
using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;
using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;
using Thunders.TechTest.Domain.Tarifas;
using Thunders.TechTest.Infra.Repositories;

namespace Thunders.TechTest.Infra.Extensions;

public static class DependencyInjections
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        services.AddScoped<IPedagioRepository, PedagioRepository>();
        services.AddScoped<IPracaRepository, PracaRepository>();
        services.AddScoped<ICidadeRepository, CidadeRepository>();
        services.AddScoped<IEstadoRepository, EstadoRepository>();
        services.AddScoped<ITarifaRepository, TarifaRepository>();
        services.AddScoped<IRanqueamentoMensalPorPracaRepository, RanqueamentoMensalPorPracaRepository>();
        services.AddScoped<ITotalPorHoraCidadeRepository, TotalPorHoraCidadeRepository>();
        services.AddScoped<IQuantidadeTipoPracaRepository, QuantidadeTipoPracaRepository>();
        
        return services;
    }
}