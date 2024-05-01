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
    public class PratoConfiguration : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("tb_prato");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.Nome).HasColumnType("varchar(60)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("varchar(150)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("decimal(10,2)").IsRequired();
            builder.HasMany(x => x.RestaurantePratos).WithOne(x => x.Prato).HasForeignKey(x => x.PratoId);
        }
    }
}
