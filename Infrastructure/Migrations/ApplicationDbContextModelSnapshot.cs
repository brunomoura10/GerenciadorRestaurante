﻿// <auto-generated />
using System;
using GerenciadorRestaurante.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorRestaurante.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Mesa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Localizacao")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<long>("RestauranteId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("tb_mesa", (string)null);
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Prato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("tb_prato", (string)null);
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Reserva", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime");

                    b.Property<long>("MesaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("QuantidadePessoas")
                        .HasColumnType("int");

                    b.Property<long>("RestauranteId")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusReserva")
                        .HasColumnType("int");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.HasIndex("RestauranteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_reserva", (string)null);
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Restaurante", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("tb_restaurante", (string)null);
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.RestaurantePrato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<long>("PratoId")
                        .HasColumnType("bigint");

                    b.Property<long>("RestauranteId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PratoId");

                    b.HasIndex("RestauranteId");

                    b.ToTable("tb_restaurante_prato", (string)null);
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tb_usuario", (string)null);
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Mesa", b =>
                {
                    b.HasOne("GerenciadorRestaurante.Core.Entites.Restaurante", "Restaurante")
                        .WithMany("Mesas")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Reserva", b =>
                {
                    b.HasOne("GerenciadorRestaurante.Core.Entites.Mesa", "Mesa")
                        .WithMany("Reservas")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciadorRestaurante.Core.Entites.Restaurante", "Restaurante")
                        .WithMany("Reservas")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GerenciadorRestaurante.Core.Entites.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");

                    b.Navigation("Restaurante");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Restaurante", b =>
                {
                    b.OwnsOne("GerenciadorRestaurante.Core.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<long>("RestauranteId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("varchar(9)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Complemento");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("varchar(2)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Numero");

                            b1.HasKey("RestauranteId");

                            b1.ToTable("tb_restaurante");

                            b1.WithOwner()
                                .HasForeignKey("RestauranteId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.RestaurantePrato", b =>
                {
                    b.HasOne("GerenciadorRestaurante.Core.Entites.Prato", "Prato")
                        .WithMany("RestaurantePratos")
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciadorRestaurante.Core.Entites.Restaurante", "Restaurante")
                        .WithMany("RestaurantePratos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prato");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Usuario", b =>
                {
                    b.OwnsOne("GerenciadorRestaurante.Core.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<long>("UsuarioId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("varchar(9)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Complemento");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasColumnType("varchar(2)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Logradouro");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Numero");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("tb_usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Mesa", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Prato", b =>
                {
                    b.Navigation("RestaurantePratos");
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Restaurante", b =>
                {
                    b.Navigation("Mesas");

                    b.Navigation("Reservas");

                    b.Navigation("RestaurantePratos");
                });

            modelBuilder.Entity("GerenciadorRestaurante.Core.Entites.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
