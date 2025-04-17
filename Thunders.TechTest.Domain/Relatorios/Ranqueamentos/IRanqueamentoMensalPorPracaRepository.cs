using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.Domain.Relatorios.Ranqueamentos;
public interface IRanqueamentoMensalPorPracaRepository
{
    Task<List<RanqueamentoMensalPorPraca>> Obter(RanqueamentoMensalPorPracaDto ranqueamentoMensalPorPracaDto);
}