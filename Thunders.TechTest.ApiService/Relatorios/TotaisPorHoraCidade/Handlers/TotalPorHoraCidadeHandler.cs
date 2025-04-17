using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Rebus.Handlers;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;

namespace Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Handlers;

public class TotalPorHoraCidadeHandler : IHandleMessages<RelatorioTotalHoraCidadeDto>
{
    private readonly ILogger<TotalPorHoraCidadeHandler> _logger;
    private readonly IDistributedCache _distributedCache;
    private readonly ITotalPorHoraCidadeRepository _totalPorHoraCidadeRepository;

    public TotalPorHoraCidadeHandler(
        ILogger<TotalPorHoraCidadeHandler> logger,
        IDistributedCache distributedCache,
        ITotalPorHoraCidadeRepository totalPorHoraCidadeRepository)
    {
        _logger = logger;
        _distributedCache = distributedCache;
        _totalPorHoraCidadeRepository = totalPorHoraCidadeRepository;
    }

    public async Task Handle(RelatorioTotalHoraCidadeDto relatorioTotalHoraCidadeDto)
    {
        var cacheKey = $"relatorio:total:hora:cidade:{relatorioTotalHoraCidadeDto.CidadeId}";
        _logger.LogInformation("Iniciado produção assincrona do relatorio de Total por Hora Cidade");
        
        var relatorio = await _totalPorHoraCidadeRepository
            .Obter(relatorioTotalHoraCidadeDto)
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