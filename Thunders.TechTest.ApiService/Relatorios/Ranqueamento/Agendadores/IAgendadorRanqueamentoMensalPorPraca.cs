using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Agendadores;

public interface IAgendadorRanqueamentoMensalPorPraca
{
    Task Agendar(RanqueamentoMensalPorPracaDto ranqueamentoMensalPorPracaDto);
}