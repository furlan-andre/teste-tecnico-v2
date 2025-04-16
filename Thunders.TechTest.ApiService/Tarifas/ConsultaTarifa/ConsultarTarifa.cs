using Thunders.TechTest.Domain.Tarifas;
using Thunders.TechTest.Domain.Tarifas.Dtos;

namespace Thunders.TechTest.ApiService.Tarifa.ConsultaTarifa;

public class ConsultarTarifa : IConsultarTarifa
{
    private readonly ITarifaRepository _tarifaRepository;

    public ConsultarTarifa(ITarifaRepository tarifaRepository)
    {
        _tarifaRepository = tarifaRepository;
    }

    public async Task<TarifaDto> ObterTarifaPorPracaIdETipoDeVeiculo(int pedagioId, int tipoDeVeiculo)
    {
        var tarifa = await _tarifaRepository.ObterPorPracaETipoDeVeiculoAsync(pedagioId, tipoDeVeiculo);
        return new TarifaDto(tarifa.Id, tarifa.PracaId, tarifa.TipoDeVeiculo.GetHashCode(), tarifa.Valor);
    }

    public async Task<TarifaDto> ObterPorId(int tarifaId)
    {
        var tarifa = await _tarifaRepository.ObterPorIdAsync(tarifaId);
        return new TarifaDto(tarifa.Id, tarifa.PracaId, tarifa.TipoDeVeiculo.GetHashCode(), tarifa.Valor);
    }

    public async Task<List<TarifaDto>> ObterPorPracaId(int pracaId)
    {
        var tarifas = await _tarifaRepository.ObterPorPracaIdAsync(pracaId);
        return tarifas.Select(t => 
            new TarifaDto(
                t.Id,
                t.PracaId,
                (int)t.TipoDeVeiculo,
                t.Valor)
            ).ToList();
    }
}