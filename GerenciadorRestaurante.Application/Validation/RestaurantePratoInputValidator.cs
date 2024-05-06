using FluentValidation;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Validation
{
    public class RestaurantePratoInputValidator : AbstractValidator<RestaurantePratoInputModel>
    {
        public RestaurantePratoInputValidator(IRestaurantRepository restaurantRepository)
        {

            RuleFor(r => r.RestauranteId)
                .NotEmpty()
                .Must(r => restaurantRepository.ExistAsync(p => p.Id == r).Result).WithMessage("O restaurante não foi encontrado")
                .WithMessage("O id do restaurante é obrigatório");
                

            RuleFor(r => r.PratoId)
                //.Must(r => pratoRepository.ExistAsync(p => p.Id == r).Result).WithMessage("O prato não foi encontrado")
                .NotEmpty().WithMessage("O id do prato é obrigatório");
            
            RuleFor(r => r.Disponivel)
                .NotEmpty().WithMessage("O campo disponível é obrigatório");

          
        }
    }
    
    
}
