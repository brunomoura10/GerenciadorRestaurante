using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using GerenciadorRestaurante.Application.Models.InputModels;

namespace GerenciadorRestaurante.Application.Validation
{
    public class MesaInputValidator : AbstractValidator<MesaInputModel>
    {
        public MesaInputValidator()
        {
            RuleFor(r => r.Numero)
                .NotNull()
                .WithMessage("O número da mesa é obrigatório");    

            RuleFor(r => r.Capacidade)
                .NotNull()
                .WithMessage("O capacidade da mesa é obrigatório");                 
        }
    }
}