using Rebus.Handlers;
using Thunders.TechTest.ApiService.Pedagios.Services.CriarPedagioService;
using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.ApiService.Pedagios.Handlers;

public class PedagioHandler : IHandleMessages<PedagioDto>
{
    private readonly ICriarPedagioService _criarPedagioService;

    public PedagioHandler(ICriarPedagioService criarPedagioService)
    {
        _criarPedagioService = criarPedagioService;
    }

    public async Task Handle(PedagioDto pedagioDto)
    {
        await _criarPedagioService.CriarPedagio(pedagioDto).ConfigureAwait(false);
    }
}