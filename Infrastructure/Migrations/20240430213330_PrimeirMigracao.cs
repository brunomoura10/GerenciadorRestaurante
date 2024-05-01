using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorRestaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimeirMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_prato",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_prato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_restaurante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(60)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(60)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(60)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(60)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_restaurante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(60)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(60)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(60)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(60)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(60)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_mesa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Localizacao = table.Column<int>(type: "int", nullable: false),
                    RestauranteId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_mesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_mesa_tb_restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "tb_restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_restaurante_prato",
                columns: table => new
                {
                    RestauranteId = table.Column<long>(type: "bigint", nullable: false),
                    PratoId = table.Column<long>(type: "bigint", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_restaurante_prato", x => new { x.RestauranteId, x.PratoId });
                    table.ForeignKey(
                        name: "FK_tb_restaurante_prato_tb_prato_PratoId",
                        column: x => x.PratoId,
                        principalTable: "tb_prato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_restaurante_prato_tb_restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "tb_restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_reserva",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataReserva = table.Column<DateTime>(type: "datetime", nullable: false),
                    QuantidadePessoas = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(150)", nullable: false),
                    StatusReserva = table.Column<int>(type: "int", nullable: false),
                    MesaId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    RestauranteId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_reserva_tb_mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "tb_mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_reserva_tb_restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "tb_restaurante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_reserva_tb_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_mesa_RestauranteId",
                table: "tb_mesa",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reserva_MesaId",
                table: "tb_reserva",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reserva_RestauranteId",
                table: "tb_reserva",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_reserva_UsuarioId",
                table: "tb_reserva",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_restaurante_prato_PratoId",
                table: "tb_restaurante_prato",
                column: "PratoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_reserva");

            migrationBuilder.DropTable(
                name: "tb_restaurante_prato");

            migrationBuilder.DropTable(
                name: "tb_mesa");

            migrationBuilder.DropTable(
                name: "tb_usuario");

            migrationBuilder.DropTable(
                name: "tb_prato");

            migrationBuilder.DropTable(
                name: "tb_restaurante");
        }
    }
}
