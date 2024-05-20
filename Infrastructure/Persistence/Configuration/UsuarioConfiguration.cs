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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuario");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(80).IsRequired();
            builder.Property(u => u.SenhaCriptografa).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Permissao).HasConversion<string>().IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.NomeUsuario).IsUnique();
        }
    }
}
