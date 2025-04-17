using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Agendadores;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

namespace Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Services;

public class QuantidadeTipoPracaService : IQuantidadeTipoPracaService
{
    private readonly ILogger<QuantidadeTipoPracaService> _logger;
    private readonly IDistributedCache _distributedCache;
    private readonly IAgendadorQuantidadeTipoPraca _agendadorQuantidadeTipoPraca;
    
    public QuantidadeTipoPracaService(
        ILogger<QuantidadeTipoPracaService> logger,
        IDistributedCache distributedCache,
        IAgendadorQuantidadeTipoPraca agendadorQuantidadeTipoPraca)
    {
        _logger = logger;
        _distributedCache = distributedCache;
        _agendadorQuantidadeTipoPraca = agendadorQuantidadeTipoPraca;
    }

    public async Task<List<QuantidadeTipoPraca>> ObterRelatorio(int pracaId)
    {
        try
        {
            var cacheKey = $"relatorio:quantidade:tipo:praca:{pracaId}";
            _logger.LogInformation("Buscando dados no cache com chave: {cacheKey}", cacheKey);
            
            var cachedData = await _distributedCache.GetAsync(cacheKey);
            
            if (cachedData != null)
            {
                _logger.LogInformation("Relatório Quantidade de Tipo de veículo por Praça encontrado no cache");
                var result = JsonSerializer.Deserialize<IEnumerable<QuantidadeTipoPraca>>(cachedData);
                
                return result.ToList();
            }
            
            _logger.LogInformation("Relatório de Quantidade de Tipo de veículo por Praça sendo agendado");
         
            var quantidadeTipoPracaDto = new RelatorioQuantidadeTipoPracaDto(pracaId);
            await _agendadorQuantidadeTipoPraca.Agendar(quantidadeTipoPracaDto).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao agendar Relatório");
            throw;
        }

        return [];
    }
}