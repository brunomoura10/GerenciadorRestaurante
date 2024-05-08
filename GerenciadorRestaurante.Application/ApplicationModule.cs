using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using GerenciadorRestaurante.Application.Validation;


namespace GerenciadorRestaurante.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IRestaurantePratoService, RestaurantePratoService>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RestauranteInputValidator>(); ;
            return services;
        }
    }
}
