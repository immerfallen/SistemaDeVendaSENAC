using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeVenda.Server.Migrations
{
    public partial class AddTableProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: true),
                    Descricao = table.Column<string>(maxLength: 45, nullable: true),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    QnuantidadeEstoque = table.Column<decimal>(nullable: false),
                    UnidadeMedida = table.Column<string>(nullable: true),
                    LinkFoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
