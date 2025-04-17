using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Agendadores;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;

namespace Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Services;

public class TotalPorHoraCidadeService : ITotalPorHoraCidadeService
{
    private readonly ILogger<TotalPorHoraCidadeService> _logger;
    private readonly IDistributedCache _distributedCache;
    private readonly IAgendadorTotalPorHoraCidade _agendadorTotalPorHoraCidade;
    
    public TotalPorHoraCidadeService(
        IDistributedCache distributedCache, 
        ILogger<TotalPorHoraCidadeService> logger,
        IAgendadorTotalPorHoraCidade agendadorTotalPorHoraCidade)
    {
        _distributedCache = distributedCache;
        _logger = logger;
        _agendadorTotalPorHoraCidade = agendadorTotalPorHoraCidade;
    }

    public async Task<List<TotalPorHoraCidade>> ObterRelatorio(int cidadeId)
    {
        try
        {
            var cacheKey = $"relatorio:total:hora:cidade:{cidadeId}";
            _logger.LogInformation("Buscando dados no cache com chave: {cacheKey}", cacheKey);
            
            var cachedData = await _distributedCache.GetAsync(cacheKey);
            
            if (cachedData != null)
            {
                _logger.LogInformation("Relatório Total por Hora Cidade encontrado no cache");
                var result = JsonSerializer.Deserialize<IEnumerable<TotalPorHoraCidade>>(cachedData);
                
                return result.ToList();
            }
            
            _logger.LogInformation("Relatório de Total por Hora Cidade sendo agendado");

            var relatorioTotalPorHoraCidade = new RelatorioTotalHoraCidadeDto(cidadeId);
            await _agendadorTotalPorHoraCidade.Agendar(relatorioTotalPorHoraCidade).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao agendar Relatório");
            throw;
        }

        return [];
    }
}