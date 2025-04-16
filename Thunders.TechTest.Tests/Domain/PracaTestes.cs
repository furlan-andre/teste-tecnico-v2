using Thunders.TechTest.Domain.Pracas;

namespace Thunders.TechTest.Tests.Domain;

public class PracaTestes
{
    [Theory]
    [InlineData(1,"", "Nome é obrigatório")]
    [InlineData(1,null, "Nome é obrigatório")]
    [InlineData(0,"Praça 1", "Cidade é obrigatório")]
    public void Construtor_ComParametrosInvalidos_DeveLancarArgumentException(
        int cidadeId, string nome,  string mensagemEsperada)
    {
        var exception = Assert.Throws<ArgumentException>(() => 
            new Praca(nome, cidadeId));
        
        Assert.Equal(mensagemEsperada, exception.Message);
    }

    [Fact]
    public void Construtor_ComParametrosValidos_DeveCriarInstanciaCorretamente()
    {
        var nomeValido = "Praça da Sé";
        var cidadeIdValido = 1;
        var praca = new Praca(nomeValido, cidadeIdValido);
        
        Assert.Equal(nomeValido, praca.Nome);
        Assert.Equal(cidadeIdValido, praca.CidadeId);
    }
}