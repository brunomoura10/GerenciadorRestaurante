using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorRestaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_reserva_tb_usuario_UsuarioId",
                table: "tb_reserva");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "tb_usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tb_usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tb_usuario",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "tb_usuario",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Permissao",
                table: "tb_usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenhaCriptografa",
                table: "tb_usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(60)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(60)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(60)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(60)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(60)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_Email",
                table: "tb_usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_NomeUsuario",
                table: "tb_usuario",
                column: "NomeUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_reserva_tb_cliente_UsuarioId",
                table: "tb_reserva",
                column: "UsuarioId",
                principalTable: "tb_cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_reserva_tb_cliente_UsuarioId",
                table: "tb_reserva");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_Email",
                table: "tb_usuario");

            migrationBuilder.DropIndex(
                name: "IX_tb_usuario_NomeUsuario",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "Permissao",
                table: "tb_usuario");

            migrationBuilder.DropColumn(
                name: "SenhaCriptografa",
                table: "tb_usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tb_usuario",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "tb_usuario",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "tb_usuario",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "tb_usuario",
                type: "varchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "tb_usuario",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "tb_usuario",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "tb_usuario",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "tb_usuario",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "tb_usuario",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "tb_usuario",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "tb_usuario",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "tb_usuario",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "tb_usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_reserva_tb_usuario_UsuarioId",
                table: "tb_reserva",
                column: "UsuarioId",
                principalTable: "tb_usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
