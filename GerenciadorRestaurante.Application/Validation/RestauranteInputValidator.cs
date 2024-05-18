using FluentValidation;
using GerenciadorRestaurante.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Validation
{
    public class RestauranteInputValidator : AbstractValidator<RestauranteInputModel>
    {
        public RestauranteInputValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty().WithMessage("O nome do restaurante é obrigatório")
                .Length(3, 60).WithMessage("O nome do restaurante deve ter entre 3 e 60 caracteres");

            RuleFor(r => r.Endereco.Logradouro)
                .NotEmpty().WithMessage("O logradouro do restaurante é obrigatório")
                .MaximumLength(60).WithMessage("O logradouro do restaurante deve ter no máximo 60 caracteres");

            RuleFor(r => r.Endereco.Cep)
                 .NotEmpty().WithMessage("O CEP do restaurante é obrigatório")
                 .Length(9).WithMessage("O CEP do restaurante deve ter 9 caracteres");

            RuleFor(r => r.Endereco.Cidade)
                .NotEmpty().WithMessage("A cidade do restaurante é obrigatória")
                .MaximumLength(60).WithMessage("A cidade do restaurante deve ter no máximo 60 caracteres");

            RuleFor(r => r.Endereco.Estado)
                .NotEmpty().WithMessage("O estado do restaurante é obrigatório")
                .Length(2).WithMessage("O estado do restaurante deve ter 2 caracteres");

            RuleFor(r => r.Endereco.Bairro)
                .NotEmpty().WithMessage("O bairro do restaurante é obrigatório")
                .MaximumLength(60).WithMessage("O bairro do restaurante deve ter no máximo 60 caracteres");

            RuleFor(r => r.Endereco.Numero)
                .NotEmpty().WithMessage("O número do restaurante é obrigatório")
                .MaximumLength(10).WithMessage("O número do restaurante deve ter no máximo 10 caracteres");

            RuleFor(r => r.Endereco.Complemento)
                   .MaximumLength(60).WithMessage("O complemento do restaurante deve ter no máximo 60 caracteres");



        }  
    }
}
