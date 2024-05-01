using GerenciadorRestaurante.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure.Persistence.Configuration
{
    public class RestauranteConfiguration : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.ToTable("tb_restaurante");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("varchar(150)").IsRequired();
            builder.OwnsOne(p => p.Endereco, x =>
            {
                x.Property(p => p.Cep).HasColumnType("varchar(9)").HasColumnName("Cep").IsRequired();
                x.Property(p => p.Cidade).HasColumnType("varchar(60)").HasColumnName("Cidade").IsRequired();
                x.Property(p => p.Estado).HasColumnType("varchar(2)").HasColumnName("Estado").IsRequired();
                x.Property(p => p.Bairro).HasColumnType("varchar(60)").HasColumnName("Bairro").IsRequired();
                x.Property(p => p.Logradouro).HasColumnType("varchar(60)").HasColumnName("Logradouro").IsRequired();
                x.Property(p => p.Numero).HasColumnType("varchar(10)").HasColumnName("Numero").IsRequired();
                x.Property(p => p.Complemento).HasColumnType("varchar(60)").HasColumnName("Complemento").IsRequired();
            });

            builder.HasMany(x => x.Mesas).WithOne(x => x.Restaurante).HasForeignKey(x => x.RestauranteId);
            builder.HasMany(x => x.Reservas).WithOne(x => x.Restaurante).HasForeignKey(x => x.RestauranteId);
            builder.HasMany(x => x.RestaurantePratos).WithOne(x => x.Restaurante).HasForeignKey(x => x.RestauranteId);

        }
    }
}
