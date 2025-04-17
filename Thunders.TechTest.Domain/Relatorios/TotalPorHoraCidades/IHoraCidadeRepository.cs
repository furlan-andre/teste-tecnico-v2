using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;

public interface ITotalPorHoraCidadeRepository
{
    Task<List<TotalPorHoraCidade>> Obter(RelatorioTotalHoraCidadeDto relatorioTotalHoraCidadeDto);
}