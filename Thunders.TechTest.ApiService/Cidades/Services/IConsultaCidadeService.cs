using Thunders.TechTest.Domain.Cidades;
using Thunders.TechTest.Domain.Cidades.Dtos;

namespace Thunders.TechTest.ApiService.Estados.Services;

public interface IConsultaCidadeService
{
    Task<CidadeDto> ObterCidadePorIdAsync(int cidadeId);  
    Task<List<CidadeDto>> ObterCidadesPorEstadoIdAsync(int estadoId);
}