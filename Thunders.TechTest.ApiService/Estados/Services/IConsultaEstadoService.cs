using Thunders.TechTest.Domain.Estados.Dtos;

namespace Thunders.TechTest.ApiService.Estados.Services;

public interface IConsultaEstadoService
{
    Task<EstadoDto> ObterPorIdAsync(int id);
    Task<List<EstadoDto>> ObterTodosAsync();
}