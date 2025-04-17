using Microsoft.AspNetCore.Mvc;
using Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Services;
using Thunders.TechTest.ApiService.Relatorios.Ranqueamento.Services;
using Thunders.TechTest.ApiService.Relatorios.TotaisPorHoraCidade.Services;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

namespace Thunders.TechTest.ApiService.Relatorios;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{   
    private readonly IRanqueamentoMensalPorPracaService _ranqueamentoMensalPorPraca;
    private readonly IQuantidadeTipoPracaService _quantidadeTipoPracaService;
    private readonly ITotalPorHoraCidadeService _totalPorHoraCidadeService;
    
    public RelatorioController(IRanqueamentoMensalPorPracaService ranqueamentoMensalPorPraca,
        IQuantidadeTipoPracaService quantidadeTipoPracaService,
        ITotalPorHoraCidadeService totalPorHoraCidadeService)
    {
        _ranqueamentoMensalPorPraca = ranqueamentoMensalPorPraca;
        _quantidadeTipoPracaService = quantidadeTipoPracaService;
        _totalPorHoraCidadeService = totalPorHoraCidadeService;
    }

    [HttpGet("RanqueamentoMensalPorPraca/{quantidadeDeRegistros}")]
    public async Task<IActionResult> ObterRanqueamentoMensalPorPraca([FromRoute]int quantidadeDeRegistros)
    {
        var retorno = await _ranqueamentoMensalPorPraca.ObterRelatorio(quantidadeDeRegistros);
        
        if (retorno.Count > 0)
            return Ok(retorno);
        
        return Accepted( new { message = "O relatório solicitado esta sendo gerado, tente novamente em instantes."});
    }
    
    [HttpGet("QuantidadeTipoPraca/{pracaId}")]
    public async Task<IActionResult> ObterQuantidadeTipoPraca([FromRoute]int pracaId)
    {
        var retorno = await _quantidadeTipoPracaService.ObterRelatorio(pracaId);
        
        if (retorno.Count > 0)
            return Ok(retorno);
        
        return Accepted( new { message = "O relatório solicitado esta sendo gerado, tente novamente em instantes."});
    }
    
    [HttpGet("TotalPorHoraCidade/{cidadeId}")]
    public async Task<IActionResult> ObterTotalPorHoraCidade([FromRoute] int cidadeId)
    {
        var retorno = await _totalPorHoraCidadeService.ObterRelatorio(cidadeId);
        
        if (retorno.Count > 0)
            return Ok(retorno);
        
        return Accepted( new { message = "O relatório solicitado esta sendo gerado, tente novamente em instantes."});
    }
}