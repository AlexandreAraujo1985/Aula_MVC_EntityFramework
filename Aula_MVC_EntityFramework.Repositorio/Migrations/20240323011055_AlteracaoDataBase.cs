using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula_MVC_EntityFramework.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fornecedor_id",
                table: "tb_produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_fornecedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    data_cadastro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fornecedor", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_fornecedor_id",
                table: "tb_produto",
                column: "fornecedor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_fornecedor_fornecedor_id",
                table: "tb_produto",
                column: "fornecedor_id",
                principalTable: "tb_fornecedor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_fornecedor_fornecedor_id",
                table: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_tb_produto_fornecedor_id",
                table: "tb_produto");

            migrationBuilder.DropColumn(
                name: "fornecedor_id",
                table: "tb_produto");
        }
    }
}
