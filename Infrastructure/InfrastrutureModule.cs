using GerenciadorRestaurante.Core.Repositories;
using GerenciadorRestaurante.Infrastructure.Persistence;
using GerenciadorRestaurante.Infrastructure.Persistence.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure
{
    public static class InfrastrutureModule
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                //options.UseLazyLoadingProxies();

            }, ServiceLifetime.Scoped);

            services.AddScoped<IRestaurantRepository, RestauranteRepository>();
            services.AddScoped<IRestaurantePratoRepository, RestaurantePratoRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IMesaRepository, MesaRepository>();
            services.AddScoped<IPratoRepository, PratoRepository>();

            return services;

        }
    }
}