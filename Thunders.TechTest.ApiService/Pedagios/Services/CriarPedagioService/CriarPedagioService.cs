using Thunders.TechTest.ApiService.Persistencia;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Dtos;
using Thunders.TechTest.Domain.Pracas;
using Thunders.TechTest.Domain.Tarifas;

namespace Thunders.TechTest.ApiService.Pedagios.Services.CriarPedagioService;

public class CriarPedagioService : ICriarPedagioService
{
    private readonly IPedagioRepository _pedagioRepository;
    private readonly IPracaRepository _pracaRepository;
    private readonly ITarifaRepository _tarifaRepository;
    private ILogger<CriarPedagioService> _logger;
    
    public CriarPedagioService(
        IPedagioRepository pedagioRepository,
        IPracaRepository pracaRepository,
        ILogger<CriarPedagioService> logger, ITarifaRepository tarifaRepository)
    {
        _pedagioRepository = pedagioRepository;
        _pracaRepository = pracaRepository;
        _logger = logger;
        _tarifaRepository = tarifaRepository;
    }

    public async Task<PedagioDto> CriarPedagio(PedagioDto pedagioDto)
    {
        try
        {
            var praca = await _pracaRepository.ObterPorIdAsync(pedagioDto.PracaId);
            if (praca is null)
            {
                _logger.LogError("Erro ao criar pedagio devido a Praça com payload: " + pedagioDto);
                throw new ArgumentException("Praça não encontrada");
            }
            
            var tarifa =
                await _tarifaRepository.ObterPorPracaETipoDeVeiculoAsync(pedagioDto.PracaId, pedagioDto.TipoDeVeiculo);
            if (tarifa is null)
            {
                _logger.LogError("Erro ao criar pedagio devido a Tarifa com payload: " + pedagioDto);
                throw new ArgumentException("Tarifa não encontrada");
            }
            
            var pedagio = new Pedagio
            (
                pedagioDto.Placa,
                pedagioDto.PracaId,
                pedagioDto.TipoDeVeiculo,
                tarifa.Valor,
                pedagioDto.DataDeUtilizacao
            );
                
            await _pedagioRepository.AdicionarAsync(pedagio);
            return pedagioDto;
        }
        catch(ArgumentException ex)
        {
            _logger.LogError(ex, "Falha ao armazenar o Pedágio " + ex.Message);
            throw;
        }
    }
}