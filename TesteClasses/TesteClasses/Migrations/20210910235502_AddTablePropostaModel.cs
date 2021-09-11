using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteClasses.Migrations
{
    public partial class AddTablePropostaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropostaModel",
                columns: table => new
                {
                    IdProposta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    QtdeDiasPrimeiraParcela = table.Column<int>(type: "int", nullable: false),
                    QtdeParcelas = table.Column<int>(type: "int", nullable: false),
                    AssinaturaProposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCp = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostaModel", x => x.IdProposta);
                    table.ForeignKey(
                        name: "FK_PropostaModel_ClienteModel_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "ClienteModel",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropostaModel_CondicaoPagamentoModel_IdCp",
                        column: x => x.IdCp,
                        principalTable: "CondicaoPagamentoModel",
                        principalColumn: "IdCp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropostaModel_IdCliente",
                table: "PropostaModel",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PropostaModel_IdCp",
                table: "PropostaModel",
                column: "IdCp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropostaModel");
        }
    }
}
