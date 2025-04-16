using Thunders.TechTest.Domain.Tarifas.Dtos;

namespace Thunders.TechTest.ApiService.Tarifa.ConsultaTarifa;

public interface IConsultarTarifa
{
    Task<TarifaDto> ObterTarifaPorPracaIdETipoDeVeiculo(int pracaId, int tipoDeVeiculo);
    Task<TarifaDto> ObterPorId(int tarifaId);
    Task<List<TarifaDto>> ObterPorPracaId(int pracaId);
}