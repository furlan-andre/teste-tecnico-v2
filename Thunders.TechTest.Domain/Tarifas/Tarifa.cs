using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Enums;
using Thunders.TechTest.Domain.Pracas;

namespace Thunders.TechTest.Domain.Tarifas;

public class Tarifa
{
    public int Id { get; set; }
    public int PracaId { get; set; }
    public virtual Praca Praca { get; set; }
    public TipoDeVeiculo TipoDeVeiculo { get; set; }
    [Precision(6, 2)]
    public decimal Valor { get; set; }
    
    protected Tarifa() { }

    public Tarifa(int pracaId, int tipoDeVeiculo, decimal valor)
    {
        ValidarValoresObrigatorios(pracaId, tipoDeVeiculo, valor);
        PracaId = pracaId;
        TipoDeVeiculo = (TipoDeVeiculo) tipoDeVeiculo;
        Valor = valor;
    }

    private void ValidarValoresObrigatorios(int pracaId, int tipoDeVeiculo, decimal valor)
    {
        if (pracaId <= 0)
            throw new ArgumentException("Praca é obrigatório");
        
        if(!Enum.IsDefined(typeof(TipoDeVeiculo), tipoDeVeiculo))
            throw new ArgumentException("Tipo de veículo é obrigatório");
        
        if (valor <= 0)
            throw new ArgumentException("Valor é obrigatório");
    }
}