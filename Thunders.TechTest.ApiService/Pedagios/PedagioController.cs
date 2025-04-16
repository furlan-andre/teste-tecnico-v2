using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Pedagios.Services;
using Thunders.TechTest.ApiService.Pedagios.Services.Agendador;
using Thunders.TechTest.ApiService.Pedagios.Services.CriarPedagioService;
using Thunders.TechTest.Domain;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.ApiService.Pedagios;


[ApiController]
[Route("api/[controller]")]
public class PedagioController : ControllerBase
{
    private readonly IPedagioRepository _pedagioRepository;
    private readonly IAgendadorCriarPedagio _agendadorCriarPedagio;
    
    public PedagioController(
        IPedagioRepository pedagioRepository,
        IAgendadorCriarPedagio agendadorCriarPedagio)
    {
        _pedagioRepository = pedagioRepository;
        _agendadorCriarPedagio = agendadorCriarPedagio;
    }

    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> CriarPedagio([FromBody] PedagioDto pedagioDto)
    {
        await _agendadorCriarPedagio.Agendar(pedagioDto).ConfigureAwait(false);
        return Accepted();
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var retorno = await _pedagioRepository.ObterTodos();
        return Ok(retorno);
    }
}
