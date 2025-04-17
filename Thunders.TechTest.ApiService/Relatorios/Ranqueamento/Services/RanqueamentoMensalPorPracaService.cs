using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Agendadores;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;

namespace Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Services;

public class RanqueamentoMensalPorPracaService : IRanqueamentoMensalPorPracaService
{
    private readonly ILogger<RanqueamentoMensalPorPracaService> _logger;
    private readonly IDistributedCache _distributedCache;
    private readonly IAgendadorRanqueamentoMensalPorPraca _agendadorRanqueamentoMensalPorPraca;
    
    public RanqueamentoMensalPorPracaService(
        ILogger<RanqueamentoMensalPorPracaService> logger,
        IDistributedCache distributedCache,
        IAgendadorRanqueamentoMensalPorPraca agendadorRanqueamentoMensalPorPraca)
    {
        _logger = logger;
        _distributedCache = distributedCache;
        _agendadorRanqueamentoMensalPorPraca = agendadorRanqueamentoMensalPorPraca;
    }

    public async Task<List<RanqueamentoMensalPorPraca>> ObterRelatorio(int quantidadeDeRegistros)
    {
        try
        {
            var cacheKey = $"relatorio:ranqueamento:pracas:mes:{quantidadeDeRegistros}";
            _logger.LogInformation("Buscando dados no cache com chave: {cacheKey}", cacheKey);
            
            var cachedData = await _distributedCache.GetAsync(cacheKey);
            
            if (cachedData != null)
            {
                _logger.LogInformation("Relatório Ranqueamento Mensal por Praça encontrado no cache");
                var result = JsonSerializer.Deserialize<IEnumerable<RanqueamentoMensalPorPraca>>(cachedData);
                
                return result.ToList();
            }
            
            _logger.LogInformation("Relatório de Ranqueamento Mensal por Praça sendo agendado");
         
            var ranqueamentoMensalPorPracaDto = new RanqueamentoMensalPorPracaDto(quantidadeDeRegistros);
            await _agendadorRanqueamentoMensalPorPraca.Agendar(ranqueamentoMensalPorPracaDto).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao agendar Relatório");
            throw;
        }

        return [];
    }
}