using Microsoft.EntityFrameworkCore;

namespace Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;

[Keyless]
public class TotalPorHoraCidade
{
    public int CidadeId { get; set; }
    public string CidadeNome { get; set; }
    public DateTime DataDaUtilizacao { get; set; }
    public int Hora { get; set; }
    public decimal ValorTotal { get; set; }
}