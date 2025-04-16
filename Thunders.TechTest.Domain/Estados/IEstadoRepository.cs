namespace Thunders.TechTest.Domain.Estados;

public interface IEstadoRepository
{
    Task<Estado> ObterPorIdAsync(int id);
    Task<List<Estado>> ObterTodosAsync();
}