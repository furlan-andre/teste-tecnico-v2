namespace Thunders.TechTest.Domain.Pracas;

public interface IPracaRepository
{
    Task<Praca> ObterPorIdAsync(int pracaId);
    Task<Praca> ObterPorIdComCidadeAsync(int pracaId);
    Task<List<Praca>> ObterTodosComCidadeAsync();
}