using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class TotalPorHoraCidadeRepository : ITotalPorHoraCidadeRepository
{
    private readonly DatabaseContext _databaseContext;

    public TotalPorHoraCidadeRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<TotalPorHoraCidade>> Obter(RelatorioTotalHoraCidadeDto relatorioTotalHoraCidadeDto)
    {
        return await _databaseContext.TotalPorHoraCidades.AsNoTracking()
            .Where(x => (relatorioTotalHoraCidadeDto.CidadeId ==0 || x.CidadeId == relatorioTotalHoraCidadeDto.CidadeId))
            .OrderByDescending(x => x.DataDaUtilizacao)
            .ThenByDescending(x => x.Hora)
            .ToListAsync();
    }   
}