using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Agendadores;

public interface IAgendadorTotalPorHoraCidade
{
    Task Agendar(RelatorioTotalHoraCidadeDto relatorioTotalHoraCidadeDto);
}