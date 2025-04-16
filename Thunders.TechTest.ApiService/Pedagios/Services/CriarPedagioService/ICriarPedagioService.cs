using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.ApiService.Pedagios.Services.CriarPedagioService;

public interface ICriarPedagioService
{
    Task<PedagioDto> CriarPedagio(PedagioDto pedagioDto);
}