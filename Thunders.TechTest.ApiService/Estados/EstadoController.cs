using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Estados.Services;

namespace Thunders.TechTest.ApiService.Estados;

[Controller]
[Route("api/[controller]")]
public class EstadoController : ControllerBase
{
    private readonly IConsultaEstadoService _consultaEstadoService;

    public EstadoController(IConsultaEstadoService consultaEstadoService)
    {
        _consultaEstadoService = consultaEstadoService;
    }
    
    [HttpGet("{estadoId}")]
    public async Task<IActionResult> ObterPorId([FromRoute]int estadoId)
    {
        var resultado = await _consultaEstadoService.ObterPorIdAsync(estadoId);
        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var resultado = await _consultaEstadoService.ObterTodosAsync();
        return Ok(resultado);
    }
}