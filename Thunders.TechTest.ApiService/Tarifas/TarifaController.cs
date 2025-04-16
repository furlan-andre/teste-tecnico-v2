using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Tarifa.ArmazenadorTarifa;
using Thunders.TechTest.ApiService.Tarifa.ConsultaTarifa;
using Thunders.TechTest.Domain.Tarifas.Dtos;

namespace Thunders.TechTest.ApiService.Tarifa;

[ApiController]
[Route("api/[controller]")]
public class TarifaController : ControllerBase
{
    private readonly IArmazenadorTarifa _armazenadorTarifa;
    private readonly IConsultarTarifa _consultarTarifa;
    public TarifaController(IArmazenadorTarifa armazenadorTarifa, IConsultarTarifa consultarTarifa)
    {
        _armazenadorTarifa = armazenadorTarifa;
        _consultarTarifa = consultarTarifa;
    }

    [HttpPost]
    public async Task<IActionResult> ArmazenarTarifa([FromBody] ArmazenadorTarifaDto armazenadorTarifa)
    {
        var tarifa = await _armazenadorTarifa.Armazenar(armazenadorTarifa);
        return CreatedAtAction(nameof(ObterPorId), tarifa);
    }

    [HttpGet("{tarifaId}")]
    public async Task<IActionResult> ObterPorId([FromRoute] int tarifaId)
    {
        var tarifa = await _consultarTarifa.ObterPorId(tarifaId);
        return Ok(tarifa);
    }
    
    [HttpGet("ObterPorPracaId/{pracaId}")]
    public async Task<IActionResult> ObterPorPracaId([FromRoute] int pracaId)
    {
        var tarifa = await _consultarTarifa.ObterPorPracaId(pracaId);
        return Ok(tarifa);
    }
}