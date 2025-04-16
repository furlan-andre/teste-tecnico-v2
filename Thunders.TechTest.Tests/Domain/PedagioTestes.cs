using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Enums;

namespace Thunders.TechTest.Tests.Domain;

public class PedagioTestes
{
    [Theory]
    [InlineData("AB12345")]   // Apenas 2 letras iniciais (inválido)
    [InlineData("ABCD123")]   // 4 letras no início, excede o padrão antigo
    [InlineData("ABC123")]    // Apenas 3 números no final, falta 1
    [InlineData("ABC12D3")]   // Ordem errada no padrão Mercosul
    [InlineData("AB1C234")]   // Ordem incorreta de letras e números
    [InlineData("123ABCD")]   // Começa com números, fora do padrão
    [InlineData("A1B2C3D")]   // Alternância inválida de letras e números
    [InlineData("ABC-1234")]  // Contém hífen, regex atual não aceita hífen
    [InlineData("abc1234")]   // Letras minúsculas (regex exige maiúsculas)
    [InlineData("ABC1d23")]   // Letra minúscula no meio (Mercosul exige maiúsculas)
    [InlineData("ABCDE12")]   // 5 letras no início, excede o limite
    [InlineData("AB12C34")]   // Ordem incorreta (mistura dos padrões antigo e novo)
    [InlineData("A@C1234")]   // Caractere especial "@" inválido
    [InlineData("ABC12345")]  // Número excedente (5 dígitos, deveria ser 4 ou 2)
    [InlineData("")]          // Placa vazia
    public void NaoDeveCriarUmPedagioComPlacaInvalida(string placa)
    {
        var pracaId = 1;
        var tipoVeiculo = 1;
        var valorPago = 10.50m;
        var dataUtilizacao = DateTime.Now;
        var mensagemEsperada = "Placa inválida";
        
        var exception = Assert.Throws<ArgumentException>(() => 
            new Pedagio(placa, pracaId, tipoVeiculo, valorPago, dataUtilizacao));
        
        Assert.Equal(mensagemEsperada, exception.Message);
    }
    
    [Theory]
    [InlineData(1,0, "Praça inválida")]
    [InlineData(0,1, "Tipo de veículo inválido")]
    [InlineData(4,1, "Tipo de veículo inválido")]
    public void Construtor_ComParametrosInvalidos_DeveLancarArgumentException(
         int tipoDeVeiculo, int pracaId, string mensagemEsperada)
    {
        var placaValida = "HTT1234";
        
        var exception = Assert.Throws<ArgumentException>(() => 
            new Pedagio(placaValida, pracaId, tipoDeVeiculo, 10, DateTime.Today));
        
        Assert.Equal(mensagemEsperada, exception.Message);
    }
    
    [Fact]
    public void DeveCriarPedagioComSucesso()
    {
        var placaValida = "ABC1D23";
        var pracaId = 1;
        var tipoVeiculo = (int) TipoDeVeiculo.Caminhao;
        var valorPago = 15.75m;
        var dataUtilizacao = DateTime.Now;
        
        var pedagio = new Pedagio(placaValida, pracaId, tipoVeiculo, valorPago, dataUtilizacao);

        Assert.Equal(placaValida, pedagio.Placa);
        Assert.Equal(pracaId, pedagio.PracaId);
        Assert.Equal(TipoDeVeiculo.Caminhao, pedagio.TipoDeVeiculo);
        Assert.Equal(valorPago, pedagio.ValorPago);
        Assert.Equal(dataUtilizacao, pedagio.DataDaUtilizacao);
    }
}