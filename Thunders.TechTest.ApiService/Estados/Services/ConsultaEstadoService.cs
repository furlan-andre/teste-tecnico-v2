using Thunders.TechTest.Domain.Estados;
using Thunders.TechTest.Domain.Estados.Dtos;

namespace Thunders.TechTest.ApiService.Estados.Services;

public class ConsultaEstadoService : IConsultaEstadoService
{
    private readonly IEstadoRepository _estadoRepository;

    public ConsultaEstadoService(IEstadoRepository estadoRepository)
    {
        _estadoRepository = estadoRepository;
    }

    public async Task<EstadoDto> ObterPorIdAsync(int id)
    {
        var estado = await _estadoRepository.ObterPorIdAsync(id);
        if(estado is null)
            throw new ArgumentException("Estado não encontrado");
        
        return new EstadoDto(estado.Id, estado.Nome, estado.Sigla);
    }

    public async Task<List<EstadoDto>> ObterTodosAsync()
    {
        var estados = await _estadoRepository.ObterTodosAsync();
        return estados.Select(x => new EstadoDto(x.Id, x.Nome, x.Sigla)).ToList();
    }
}