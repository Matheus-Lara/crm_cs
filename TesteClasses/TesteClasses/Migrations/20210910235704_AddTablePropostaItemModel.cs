using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteClasses.Migrations
{
    public partial class AddTablePropostaItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropostaItemModel",
                columns: table => new
                {
                    IdPropostaItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdProposta = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostaItemModel", x => x.IdPropostaItem);
                    table.ForeignKey(
                        name: "FK_PropostaItemModel_ProdutoModel_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "ProdutoModel",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropostaItemModel_PropostaModel_IdProposta",
                        column: x => x.IdProposta,
                        principalTable: "PropostaModel",
                        principalColumn: "IdProposta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropostaItemModel_IdProduto",
                table: "PropostaItemModel",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PropostaItemModel_IdProposta",
                table: "PropostaItemModel",
                column: "IdProposta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropostaItemModel");
        }
    }
}
