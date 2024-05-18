using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorRestaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_restaurante_prato",
                table: "tb_restaurante_prato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_restaurante_prato",
                table: "tb_restaurante_prato",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_restaurante_prato_RestauranteId",
                table: "tb_restaurante_prato",
                column: "RestauranteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_restaurante_prato",
                table: "tb_restaurante_prato");

            migrationBuilder.DropIndex(
                name: "IX_tb_restaurante_prato_RestauranteId",
                table: "tb_restaurante_prato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_restaurante_prato",
                table: "tb_restaurante_prato",
                columns: new[] { "RestauranteId", "PratoId" });
        }
    }
}
