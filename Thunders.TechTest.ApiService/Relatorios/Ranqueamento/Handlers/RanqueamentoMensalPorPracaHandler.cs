using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Rebus.Handlers;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;

namespace Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Handlers;

public class RanqueamentoMensalPorPracaHandler : IHandleMessages<RanqueamentoMensalPorPracaDto>
{
    private readonly IRanqueamentoMensalPorPracaRepository _ranqueamentoMensalPorPracaRepository;
    private readonly ILogger<RanqueamentoMensalPorPracaHandler> _logger;
    private readonly IDistributedCache _distributedCache;
    
    public RanqueamentoMensalPorPracaHandler(
        ILogger<RanqueamentoMensalPorPracaHandler> logger,
        IDistributedCache distributedCache,
        IRanqueamentoMensalPorPracaRepository ranqueamentoMensalPorPracaRepository)
    {
        _ranqueamentoMensalPorPracaRepository = ranqueamentoMensalPorPracaRepository;
        _logger = logger;
        _distributedCache = distributedCache;
    }

    public async Task Handle(RanqueamentoMensalPorPracaDto ranqueamentoMensalPorPracaDto)
    {
        var cacheKey = $"relatorio:ranqueamento:pracas:mes:{ranqueamentoMensalPorPracaDto.QuantidadeDeRegistros}";
        _logger.LogInformation("Iniciado produção assincrona do relatorio de Ranqueamento Mensal por Praças");
        
        var relatorio = await _ranqueamentoMensalPorPracaRepository
            .Obter(ranqueamentoMensalPorPracaDto)
            .ConfigureAwait(false);
        
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) 
        };

        try
        {
            _logger.LogInformation("Armazenando dados no cache...");
            await _distributedCache.SetAsync(
                cacheKey,
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(relatorio)),
                cacheOptions);
                
            _logger.LogInformation("Dados armazenados com sucesso no cache");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao salvar dados no cache");
        }
    }
}