using Microsoft.EntityFrameworkCore;

namespace Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

[Keyless]
public class QuantidadeTipoPraca
{
    public int PracaId { get; set; }
    public string PracaNome { get; set; }
    public string CidadeNome { get; set; }
    public int TiposDistintos { get; set; }
}