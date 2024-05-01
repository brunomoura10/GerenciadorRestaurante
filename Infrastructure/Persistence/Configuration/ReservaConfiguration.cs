using GerenciadorRestaurante.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GerenciadorRestaurante.Infrastructure.Persistence.Configuration
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("tb_reserva");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.DataReserva).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.QuantidadePessoas).HasColumnType("int").IsRequired();
            builder.Property(p => p.Observacao).HasColumnType("varchar(150)");
            builder.Property(p => p.StatusReserva).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Mesa).WithMany(x => x.Reservas).HasForeignKey(x => x.MesaId);
            builder.HasOne(x => x.Usuario).WithMany(x => x.Reservas).HasForeignKey(x => x.UsuarioId);
            builder.HasOne(x => x.Restaurante).WithMany(x => x.Reservas).HasForeignKey(x => x.RestauranteId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
