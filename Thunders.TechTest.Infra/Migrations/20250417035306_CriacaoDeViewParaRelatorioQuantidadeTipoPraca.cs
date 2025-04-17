using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thunders.TechTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeViewParaRelatorioQuantidadeTipoPraca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER VIEW QuantidadeTipoPraca
            AS
            SELECT 
	            pr.Nome as PracaNome,
	            c.Nome as CidadeNome,
                PracaId as PracaId,
                COUNT(DISTINCT TipoDeVeiculo) AS TiposDistintos	
            FROM Pedagio p
            left join Praca pr on pr.id = p.Pracaid
            left join Cidade c on c.Id = pr.CidadeId
            GROUP BY p.PracaId, pr.nome, c.nome;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW QuantidadeTipoPraca");
        }
    }
}
