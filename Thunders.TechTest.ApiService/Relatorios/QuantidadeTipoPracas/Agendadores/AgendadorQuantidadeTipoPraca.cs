using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Agendadores;

public class AgendadorQuantidadeTipoPraca : IAgendadorQuantidadeTipoPraca
{
    private readonly IMessageSender _messageSender;

    public AgendadorQuantidadeTipoPraca(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task Agendar(RelatorioQuantidadeTipoPracaDto ranqueamentoMensalPorPracaDto)
    {
        _messageSender.SendLocal(ranqueamentoMensalPorPracaDto);
    }
}