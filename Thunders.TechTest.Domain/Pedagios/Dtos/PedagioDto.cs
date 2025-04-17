namespace Thunders.TechTest.Domain.Pedagios.Dtos;

public record PedagioDto
{
    public string Placa { get; set; }
    public int PracaId { get; set; }
    public DateTime DataDeUtilizacao { get; set; }
    public int TipoDeVeiculo { get; set; }
}

