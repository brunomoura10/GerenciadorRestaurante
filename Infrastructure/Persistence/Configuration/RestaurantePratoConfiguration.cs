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
    public class RestaurantePratoConfiguration : IEntityTypeConfiguration<RestaurantePrato>
    {
        public void Configure(EntityTypeBuilder<RestaurantePrato> builder)
        {
            builder.ToTable("tb_restaurante_prato");
            builder.HasKey(rp => rp.Id);

            builder.HasOne(rp => rp.Restaurante)
                .WithMany(r => r.RestaurantePratos)
                .HasForeignKey(rp => rp.RestauranteId);

            builder.HasOne(rp => rp.Prato)
                .WithMany(p => p.RestaurantePratos)
                .HasForeignKey(rp => rp.PratoId);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.Disponivel).HasColumnType("bit").IsRequired();

            
        }
    }
    
}
