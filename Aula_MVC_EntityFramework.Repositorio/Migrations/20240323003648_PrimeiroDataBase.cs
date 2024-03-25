using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_MVC_EntityFramework.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiroDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_produto");
        }
    }
}
