namespace Thunders.TechTest.ApiService.Persistencia;

public interface IUnitOfWork
{
    Task IniciarTransacaoAsync();
    Task ConfirmarTransacaoAsync();
    Task RetrocederTransacaoAsync();
}