using Thunders.TechTest.Domain.Cidades;

namespace Thunders.TechTest.Domain.Pracas;

public class Praca
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CidadeId { get; set; }
    public virtual Cidade Cidade { get; set; }

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