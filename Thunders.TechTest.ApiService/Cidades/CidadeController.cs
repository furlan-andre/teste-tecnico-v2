using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Estados.Services;
using Thunders.TechTest.Domain.Cidades.Dtos;

namespace Thunders.TechTest.ApiService.Estados;

[Controller]
[Route("api/[controller]")]
public class CidadeController : ControllerBase
{
    private readonly IConsultaCidadeService _consultaCidadeService;

    public CidadeController(IConsultaCidadeService consultaCidadeService)
    {
        _consultaCidadeService = consultaCidadeService;
    }

    [HttpGet("{cidadeId}")]
    public async Task<IActionResult> ObterPorId([FromRoute]int cidadeId)
    {
        var resultado = await _consultaCidadeService.ObterCidadePorIdAsync(cidadeId);
        
        if(resultado is not null)
            return Ok(resultado);
        
        return Conflict();
    }
    
    [HttpGet("ObterPorEstadoId/{estadoId}")]
    public async Task<IActionResult> ObterPorEstadoId([FromRoute]int estadoId)
    {
        var resultado = await _consultaCidadeService.ObterCidadesPorEstadoIdAsync(estadoId);
        return Ok(resultado);
    }
}