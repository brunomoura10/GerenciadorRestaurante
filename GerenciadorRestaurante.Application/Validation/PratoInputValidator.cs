using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using GerenciadorRestaurante.Application.Models.InputModels;

namespace GerenciadorRestaurante.Application.Validation
{
    public class PratoInputValidator : AbstractValidator<PratoInputModel>
    {
        public PratoInputValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage("O nome do prato é obrigatório")
                .Length(3, 60)
                .WithMessage("O nome do prato deve ter entre 3 e 60 caracteres");

            RuleFor(r => r.Preco)
                .NotNull()
                .WithMessage("O preço do prato é obrigatório");             
        }
    }
}