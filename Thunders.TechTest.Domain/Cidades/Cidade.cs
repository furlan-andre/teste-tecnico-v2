using Thunders.TechTest.Domain.Estados;

namespace Thunders.TechTest.Domain.Cidades;

public class Cidade
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int EstadoId { get; set; }
    public Estado Estado { get; set; }
}