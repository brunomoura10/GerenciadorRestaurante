using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace GerenciadorRestaurante.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestauranteService, RestauranteService>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
