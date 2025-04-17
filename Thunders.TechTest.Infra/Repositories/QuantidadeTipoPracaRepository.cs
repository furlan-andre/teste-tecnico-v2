using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class QuantidadeTipoPracaRepository : IQuantidadeTipoPracaRepository
{
    private readonly DatabaseContext _databaseContext;

    public QuantidadeTipoPracaRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<QuantidadeTipoPraca>> Obter(RelatorioQuantidadeTipoPracaDto relatorioQuantidadeTipoPracaDto)
    {
        return await _databaseContext.QuantidadeTipoPracas.AsNoTracking()
            .Where(x => (relatorioQuantidadeTipoPracaDto.PracaId == 0 ||
                                          x.PracaId == relatorioQuantidadeTipoPracaDto.PracaId))
            .ToListAsync();
    }
}