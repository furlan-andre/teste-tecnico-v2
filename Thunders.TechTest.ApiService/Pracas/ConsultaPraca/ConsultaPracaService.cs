using Thunders.TechTest.Domain.Pracas;
using Thunders.TechTest.Domain.Pracas.Dtos;

namespace Thunders.TechTest.ApiService.Pracas.ConsultaPraca;

public class ConsultaPracaService : IConsultaPracaService
{
    private readonly IPracaRepository _pracaRepository;

    public ConsultaPracaService(IPracaRepository pracaRepository)
    {
        _pracaRepository = pracaRepository;
    }

    public async Task<PracaDto> ObterPorIdAsync(int pracaId)
    {
        var praca = await _pracaRepository.ObterPorIdAsync(pracaId);
        return new PracaDto(praca.Id, praca.Nome, praca.CidadeId);
    }
    
    public async Task<List<PracaViewDto>> ObterTodosAsync()
    {
        var pracas = await _pracaRepository.ObterTodosComCidadeAsync();
        return pracas.Select(p =>
                new PracaViewDto(
                    p.Id,
                    p.Nome,
                    p.CidadeId,
                    p.Cidade.Nome,
                    p.Cidade.Estado.Sigla))
            .ToList();
    }
}