using Thunders.TechTest.Domain.Cidades;
using Thunders.TechTest.Domain.Cidades.Dtos;

namespace Thunders.TechTest.ApiService.Estados.Services;

public class ConsultaCidadeService : IConsultaCidadeService
{
    private readonly ICidadeRepository _cidadeRepository;

    public ConsultaCidadeService(ICidadeRepository cidadeRepository)
    {
        _cidadeRepository = cidadeRepository;
    }

    public async Task<CidadeDto> ObterCidadePorIdAsync(int cidadeId)
    {
        var cidade = await _cidadeRepository.ObterCidadeComEstadoPorId(cidadeId);
        return new CidadeDto(cidade.Id, cidade.Nome, cidade.EstadoId, cidade.Estado.Sigla);
    }

    public async Task<List<CidadeDto>> ObterCidadesPorEstadoIdAsync(int estadoId)
    {
        var cidades = await _cidadeRepository.ObterCidadesPorEstadoId(estadoId);
        return cidades.Select(x => 
                new CidadeDto(x.Id, x.Nome, x.EstadoId, x.Estado.Sigla))
                .ToList();
    }
}