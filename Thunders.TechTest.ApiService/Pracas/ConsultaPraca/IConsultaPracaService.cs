using Thunders.TechTest.Domain.Pracas.Dtos;

namespace Thunders.TechTest.ApiService.Pracas.ConsultaPraca;

public interface IConsultaPracaService
{
    Task<PracaDto> ObterPorIdAsync(int pracaId);
    Task<List<PracaViewDto>> ObterTodosAsync();
}