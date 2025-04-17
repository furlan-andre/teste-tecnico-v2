using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;

namespace Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Services;

public interface IRanqueamentoMensalPorPracaService
{
    Task<List<RanqueamentoMensalPorPraca>> ObterRelatorio(int quantidadeDeRegistros);
}