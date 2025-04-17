using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thunders.TechTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeViewParaRelatorioRanqueamentoMensalPorPraca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER VIEW RanqueamentoMensalPorPraca
            AS
            SELECT
                pr.Id AS PracaId,
                pr.Nome AS PracaNome,
                c.Id AS CidadeId,
                c.Nome AS CidadeNome,
                DATEFROMPARTS(YEAR(p.DataDaUtilizacao), MONTH(p.DataDaUtilizacao), 1) AS Mes,
                SUM(p.ValorPago) AS ValorTotal,
                CAST(RANK() OVER (
                    PARTITION BY DATEFROMPARTS(YEAR(p.DataDaUtilizacao), MONTH(p.DataDaUtilizacao), 1)
                    ORDER BY SUM(p.ValorPago) DESC
                ) AS BIGINT) AS Ordem  
            FROM Pedagio p
            INNER JOIN Praca pr ON p.PracaId = pr.Id
            INNER JOIN Cidade c ON pr.CidadeId = c.Id
            GROUP BY 
                pr.Id, 
                pr.Nome,
                c.Id,
                c.Nome,
                DATEFROMPARTS(YEAR(p.DataDaUtilizacao), MONTH(p.DataDaUtilizacao), 1); 
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW RanqueamentoMensalPorPraca");
        }
    }
}
