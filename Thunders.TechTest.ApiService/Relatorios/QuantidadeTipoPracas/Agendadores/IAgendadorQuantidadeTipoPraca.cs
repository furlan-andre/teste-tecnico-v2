using Thunders.TechTest.Domain.Relatorios.Dtos;

namespace Thunders.TechTest.ApiService.Relatorios.QuantidadeTipoPracas.Agendadores;

public interface IAgendadorQuantidadeTipoPraca
{
    Task Agendar(RelatorioQuantidadeTipoPracaDto ranqueamentoMensalPorPracaDto);
}