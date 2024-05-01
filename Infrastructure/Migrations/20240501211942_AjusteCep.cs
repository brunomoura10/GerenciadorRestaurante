using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorRestaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "tb_usuario",
                type: "varchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "tb_restaurante",
                type: "varchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "tb_usuario",
                type: "varchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "tb_restaurante",
                type: "varchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)");
        }
    }
}
