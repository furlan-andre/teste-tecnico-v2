using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Agendadores;

public class AgendadorTotalPorHoraCidade : IAgendadorTotalPorHoraCidade
{
    private readonly IMessageSender _messageSender;

    public AgendadorTotalPorHoraCidade(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task Agendar(RelatorioTotalHoraCidadeDto relatorioTotalHoraCidadeDto)
    {
        _messageSender.SendLocal(relatorioTotalHoraCidadeDto);
    }
}