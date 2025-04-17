using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

public interface IQuantidadeTipoPracaRepository
{
    Task<List<QuantidadeTipoPraca>> Obter(RelatorioQuantidadeTipoPracaDto relatorioQuantidadeTipoPracaDto);
}