namespace Thunders.TechTest.Domain.Pedagios;

public interface IPedagioRepository
{
    Task AdicionarAsync(Pedagio pedagio);
    Task<IEnumerable<Pedagio>> ObterTodos();
}