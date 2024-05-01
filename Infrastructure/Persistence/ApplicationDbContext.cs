using GerenciadorRestaurante.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<RestaurantePrato> RestaurantePratos { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }

   



}
