using Thunders.TechTest.Domain.Estados;

namespace Thunders.TechTest.Domain.Cidades;

public class Cidade
{
    public int Id { get; init; }
    public string Nome { get; init; }
    public int EstadoId { get; init; }
    public Estado Estado { get; init; }
}