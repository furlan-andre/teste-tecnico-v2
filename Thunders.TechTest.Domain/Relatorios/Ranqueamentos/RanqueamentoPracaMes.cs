using Microsoft.EntityFrameworkCore;

namespace Thunders.TechTest.Domain.Relatorios.Ranqueamentos;

[Keyless]
public class RanqueamentoMensalPorPraca
{
    public int PracaId { get; set; }
    public string PracaNome { get; set; }
    public int CidadeId { get; set; }
    public string CidadeNome { get; set; }
    public DateTime Mes { get; set; }
    public decimal ValorTotal { get; set; }
    public long Ordem { get; set; }
}