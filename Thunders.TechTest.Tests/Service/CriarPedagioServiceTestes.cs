using Microsoft.Extensions.Logging;
using Moq;
using Thunders.TechTest.ApiService.Pedagios.Services.CriarPedagioService;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Dtos;
using Thunders.TechTest.Domain.Pracas;
using Thunders.TechTest.Domain.Tarifas;

namespace Thunders.TechTest.Tests.Service;

public class CriarPedagioServiceTestes
{
    private readonly Mock<IPedagioRepository> _pedagioRepositoryMock;
    private readonly Mock<IPracaRepository> _pracaRepositoryMock;
    private readonly Mock<ITarifaRepository> _tarifaRepositoryMock;
    private readonly Mock<ILogger<CriarPedagioService>> _loggerMock;
    private readonly CriarPedagioService _service;
    private readonly PedagioDto _pedagioDto;
    
    public CriarPedagioServiceTestes()
    {
        _pedagioRepositoryMock = new Mock<IPedagioRepository>();
        _pracaRepositoryMock = new Mock<IPracaRepository>();
        _tarifaRepositoryMock = new Mock<ITarifaRepository>();
        _loggerMock = new Mock<ILogger<CriarPedagioService>>();
        
        _service = new CriarPedagioService(
            _pedagioRepositoryMock.Object,
            _pracaRepositoryMock.Object,
            _loggerMock.Object,
            _tarifaRepositoryMock.Object);
        
        _pedagioDto = new PedagioDto
        {
            Placa = "ABC1D23",
            PracaId = 1,
            TipoDeVeiculo = 1,
            DataDeUtilizacao = DateTime.Now
        };
    }
    
    [Fact]
    public async Task NaoDeveSerPossivelCriarPedagioQuandoNaoEncontrarPracaInformada()
    {  
        var mensagemEsperada = "Praça não encontrada";
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.CriarPedagio(_pedagioDto));
        Assert.Equal(mensagemEsperada, exception.Message);
    }

    [Fact]
    public async Task NaoDeveSerPossivelCriarPedagioQuandoNaoEncontrarTarifa()
    {  
        var mensagemEsperada = "Tarifa não encontrada";
        _pracaRepositoryMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Praca("Praça Teste", 1));
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.CriarPedagio(_pedagioDto));
        Assert.Equal(mensagemEsperada, exception.Message);
    }

    [Fact]
    public async Task CriarPedagio_ComDadosValidos_DeveRetornarPedagioDto()
    {   
        _pracaRepositoryMock.Setup(x => x.ObterPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Praca("Praça Teste", 1));
        _tarifaRepositoryMock.Setup(x => x.ObterPorPracaETipoDeVeiculoAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(new Tarifa(
                _pedagioDto.PracaId,
                _pedagioDto.TipoDeVeiculo,
                (decimal)20.10
                ));

        var result = await _service.CriarPedagio(_pedagioDto);

        Assert.Equal(_pedagioDto.Placa, result.Placa);
        Assert.Equal(_pedagioDto.PracaId, result.PracaId);
        Assert.Equal(_pedagioDto.TipoDeVeiculo, result.TipoDeVeiculo);
        Assert.Equal(_pedagioDto.DataDeUtilizacao, result.DataDeUtilizacao);
        _pedagioRepositoryMock.Verify(repo => 
            repo.AdicionarAsync(It.IsAny<Pedagio>()), Times.Once);
    }
}