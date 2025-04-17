using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain;
using Thunders.TechTest.Domain.Relatorios;
using Thunders.TechTest.Domain.Relatorios.Dtos;
using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class RanqueamentoMensalPorPracaRepository : IRanqueamentoMensalPorPracaRepository
{
    private readonly DatabaseContext _databaseContext;

    public RanqueamentoMensalPorPracaRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<RanqueamentoMensalPorPraca>> Obter(RanqueamentoMensalPorPracaDto ranqueamentoMensalPorPracaDto)
    {
        var mesAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        return await _databaseContext.RanqueamentoMensalPorPracas.AsNoTracking()
            .Where(x => x.Mes == mesAtual)
            .OrderBy(x => x.Ordem)
            .Take(ranqueamentoMensalPorPracaDto.QuantidadeDeRegistros)
            .ToListAsync();
    }
}