using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Pracas.ConsultaPraca;
using Thunders.TechTest.Domain.Pracas;

namespace Thunders.TechTest.ApiService.Pracas;

[ApiController]
[Route("api/[controller]")]
public class PracaController : ControllerBase
{
    private readonly IConsultaPracaService _consultaPracaService;

    public PracaController(IConsultaPracaService consultaPracaService)
    {
        _consultaPracaService = consultaPracaService;
    }

    [HttpGet("{pracaId}")]
    public async Task<IActionResult> ObterPorIdAsync([FromRoute] int pracaId)
    {
        var resultado = await _consultaPracaService.ObterPorIdAsync(pracaId);
        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var resultado = await _consultaPracaService.ObterTodosAsync();
        return Ok(resultado);
    }
}