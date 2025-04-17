using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

namespace Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Services;

public interface IQuantidadeTipoPracaService
{
    Task<List<QuantidadeTipoPraca>> ObterRelatorio(int pracaId);
}