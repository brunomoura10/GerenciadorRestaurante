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
    public class MesaConfiguration : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.ToTable("tb_mesa");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.Numero).HasColumnType("int").IsRequired();
            builder.Property(p => p.Capacidade).HasColumnType("int").IsRequired();
            builder.Property(p => p.Localizacao).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Restaurante).WithMany(x => x.Mesas).HasForeignKey(x => x.RestauranteId);

        }
    }
}
