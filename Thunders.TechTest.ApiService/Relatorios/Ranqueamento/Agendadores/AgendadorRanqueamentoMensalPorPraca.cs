using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Agendadores;

public class AgendadorRanqueamentoMensalPorPraca : IAgendadorRanqueamentoMensalPorPraca
{
    private readonly IMessageSender _messageSender;

    public AgendadorRanqueamentoMensalPorPraca(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task Agendar(RanqueamentoMensalPorPracaDto ranqueamentoMensalPorPracaDto)
    {
        _messageSender.SendLocal(ranqueamentoMensalPorPracaDto);
    }
}