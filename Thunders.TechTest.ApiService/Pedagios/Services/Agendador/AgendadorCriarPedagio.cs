using Thunders.TechTest.Domain.Pedagios.Dtos;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Pedagios.Services.Agendador;

public class AgendadorCriarPedagio : IAgendadorCriarPedagio
{
    private readonly IMessageSender _messageSender;

    public AgendadorCriarPedagio(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task Agendar(PedagioDto pedagioDto)
    {
        _messageSender.SendLocal(pedagioDto);
    }
}