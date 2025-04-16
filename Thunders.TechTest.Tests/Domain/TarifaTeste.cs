using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Enums;
using Thunders.TechTest.Domain.Tarifas;

namespace Thunders.TechTest.Tests.Domain;

public class TarifaTestes
{ 
    [Theory]
    [InlineData(0, 1, 10.50d, "Praca é obrigatório")]
    [InlineData(1, 0, 10.50d, "Tipo de veículo é obrigatório")]
    [InlineData(1, 4, 10.50d, "Tipo de veículo é obrigatório")]
    public void Construtor_ComParametrosInvalidos_DeveLancarArgumentExceptionComMensagemCorreta(
        int pracaId, int tipoDeVeiculo, decimal valor, string mensagemEsperada)
    {
        var exception = Assert.Throws<ArgumentException>(() => 
            new Tarifa(pracaId, tipoDeVeiculo, valor));
        
        Assert.Equal(mensagemEsperada, exception.Message);
    }
    
    [Fact]
    public void DeveCriarTarifaComSucesso()
    {
        var pracaId = 1;
        var tipoDeVeiculo = 1;
        var valor = 10.50m;

        var tarifa = new Tarifa(pracaId, tipoDeVeiculo, valor);

        Assert.Equal(pracaId, tarifa.PracaId);
        Assert.Equal(TipoDeVeiculo.Moto, tarifa.TipoDeVeiculo);
        Assert.Equal(valor, tarifa.Valor);
    }
}
