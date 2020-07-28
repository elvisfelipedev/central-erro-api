using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralErros.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Origem = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ambiente = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1500)", nullable: false),
                    Evento = table.Column<int>(nullable: false),
                    Arquivar = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
