using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Rebus.Handlers;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

namespace Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Handlers;

public class QuantidadeTipoPracaHandler : IHandleMessages<RelatorioQuantidadeTipoPracaDto>
{
    private readonly ILogger<QuantidadeTipoPracaHandler> _logger;
    private readonly IDistributedCache _distributedCache;
    private readonly IQuantidadeTipoPracaRepository _quantidadeTipoPracaRepository;
    
    public QuantidadeTipoPracaHandler(
        IDistributedCache distributedCache,
        ILogger<QuantidadeTipoPracaHandler> logger,
        IQuantidadeTipoPracaRepository quantidadeTipoPracaRepository)
    {
        _distributedCache = distributedCache;
        _logger = logger;
        _quantidadeTipoPracaRepository = quantidadeTipoPracaRepository;
    }

    public async Task Handle(RelatorioQuantidadeTipoPracaDto relatorioQuantidadeTipoPracaDto)
    {
        var cacheKey = $"relatorio:quantidade:tipo:praca:{relatorioQuantidadeTipoPracaDto.PracaId}";
        _logger.LogInformation("Iniciado produção assincrona do relatorio de Quantidade de Tipo de veículo por Praça");
        
        var relatorio = await _quantidadeTipoPracaRepository
            .Obter(relatorioQuantidadeTipoPracaDto)
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