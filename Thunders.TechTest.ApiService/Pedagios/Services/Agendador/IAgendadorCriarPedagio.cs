using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.ApiService.Pedagios.Services.Agendador;

public interface IAgendadorCriarPedagio
{
    Task Agendar(PedagioDto pedagioDto);
}