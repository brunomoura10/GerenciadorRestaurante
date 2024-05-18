using FluentValidation.AspNetCore;
using FluentValidation;
using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using GerenciadorRestaurante.Application.Validation;
using GerenciadorRestaurante.Application.Models.ViewModels;


namespace GerenciadorRestaurante.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IClienteService, ClienteService>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ReservaInputValidator>();
            services.AddValidatorsFromAssemblyContaining<ClienteInputValidator>();
            return services;
        }
    }
}
