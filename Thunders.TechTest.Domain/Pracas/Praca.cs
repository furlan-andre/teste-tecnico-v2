using Thunders.TechTest.Domain.Cidades;

namespace Thunders.TechTest.Domain.Pracas;

public class Praca
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public int CidadeId { get; init; }
    public virtual Cidade Cidade { get; init; }

    public Praca(string nome, int cidadeId)
    {
        ValidarDadosObrigatorios(nome, cidadeId);
        Nome = nome;
        CidadeId = cidadeId;
    }

    private void ValidarDadosObrigatorios(string nome, int cidadeId)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentException("Nome é obrigatório");
        
        if(cidadeId <= 0)
            throw new ArgumentException("Cidade é obrigatório");
    }
}