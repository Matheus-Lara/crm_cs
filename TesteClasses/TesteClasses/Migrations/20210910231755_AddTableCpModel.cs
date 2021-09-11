using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteClasses.Migrations
{
    public partial class AddTableCpModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicaoPagamentoModel",
                columns: table => new
                {
                    IdCp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdePadraoDias = table.Column<int>(type: "int", nullable: false),
                    QtdePadraoParcelas = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicaoPagamentoModel", x => x.IdCp);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondicaoPagamentoModel");
        }
    }
}
