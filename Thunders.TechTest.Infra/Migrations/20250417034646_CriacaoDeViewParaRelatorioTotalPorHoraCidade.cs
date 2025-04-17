using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thunders.TechTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeViewParaRelatorioTotalPorHoraCidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER VIEW TotalPorHoraCidade
            AS
            SELECT 
                c.Id AS CidadeId,
                c.Nome AS CidadeNome,
                CAST(p.DataDaUtilizacao AS DATE) AS DataDaUtilizacao,
                DATEPART(HOUR, p.DataDaUtilizacao) AS Hora,
                SUM(p.ValorPago) AS ValorTotal                
            FROM Pedagio p
            INNER JOIN Praca pr ON p.PracaId = pr.Id
            INNER JOIN Cidade c ON pr.CidadeId = c.Id
            GROUP BY 
                c.Id, 
                c.Nome, 
                CAST(p.DataDaUtilizacao AS DATE),
                DATEPART(HOUR, p.DataDaUtilizacao);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW TotalPorHoraCidade");
        }
    }
}
