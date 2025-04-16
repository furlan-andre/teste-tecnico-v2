namespace Thunders.TechTest.Domain.Pedagios.Dtos;

public class TotalizadorDto
{
    public int CidadeId { get; set; }
    public string CidadeNome { get; set; }
    public decimal ValorTotal { get; set; }
}
public class FiltroCidadeDto
{
    public int CidadeId { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
}
public class FiltroFaturamentoDto
{
    public int QuantidadeDePracas  { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}

public class FiltroQuantitativoDto
{
    public List<int> PracasIds  { get; set; }
}