using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteClasses.Migrations
{
    public partial class AddTableInteracoesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InteracoesModel",
                columns: table => new
                {
                    IdInteracao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataInteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeioContato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteRespondeu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteracoesModel", x => x.IdInteracao);
                    table.ForeignKey(
                        name: "FK_InteracoesModel_ClienteModel_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "ClienteModel",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InteracoesModel_IdCliente",
                table: "InteracoesModel",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteracoesModel");
        }
    }
}
