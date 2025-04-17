using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;

namespace Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Services;

public interface ITotalPorHoraCidadeService
{
    Task<List<TotalPorHoraCidade>> ObterRelatorio(int cidadeId);
}