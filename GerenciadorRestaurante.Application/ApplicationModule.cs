using FluentValidation.AspNetCore;
using FluentValidation;
using GerenciadorRestaurante.Application.Services;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            services.AddScoped<IRestaurantePratoService, RestaurantePratoService>();
            services.AddScoped<IReservaService, ReservaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IMesaService, MesaService>();
            services.AddScoped<IPratoService, PratoService>();


            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RestauranteInputValidator>();
            services.AddValidatorsFromAssemblyContaining<ReservaInputValidator>();
            services.AddValidatorsFromAssemblyContaining<ClienteInputValidator>();
            services.AddValidatorsFromAssemblyContaining<MesaInputValidator>();
            services.AddValidatorsFromAssemblyContaining<PratoInputValidator>();


            return services;
        }
    }
}
