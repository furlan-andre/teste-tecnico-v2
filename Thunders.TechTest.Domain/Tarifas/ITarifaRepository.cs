using Thunders.TechTest.Domain.Tarifas.Dtos;

namespace Thunders.TechTest.Domain.Tarifas;

public interface ITarifaRepository
{
    Task AdicionarAsync(Tarifa tarifa);
    Task<Tarifa> ObterPorPracaETipoDeVeiculoAsync(int pracaId, int tipoDeVeiculo);
    Task<Tarifa> ObterPorIdAsync(int tarifaId);
    Task<List<Tarifa>> ObterPorPracaIdAsync(int pracaId);
}