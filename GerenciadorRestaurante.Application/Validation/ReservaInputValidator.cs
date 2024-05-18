using FluentValidation;
using GerenciadorRestaurante.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Validation
{
    public class ReservaInputValidator : AbstractValidator<ReservaInputModel>
    {
        public ReservaInputValidator()
        {
            RuleFor(reserva => reserva.DataReserva)
           .GreaterThan(DateTime.Now).WithMessage("A data da reserva deve ser no futuro.");

            RuleFor(reserva => reserva.QuantidadePessoas)
                .GreaterThan(0).WithMessage("A quantidade de pessoas deve ser maior que zero.");

            RuleFor(reserva => reserva.Observacao)
                .MaximumLength(500).WithMessage("A observação deve ter no máximo 500 caracteres.");

            RuleFor(reserva => reserva.MesaId)
                .GreaterThan(0).WithMessage("O ID da mesa deve ser válido.");

            RuleFor(reserva => reserva.UsuarioId)
                .GreaterThan(0).WithMessage("O ID do usuário deve ser válido.");

            RuleFor(reserva => reserva.RestauranteId)
                .GreaterThan(0).WithMessage("O ID do restaurante deve ser válido.");

            RuleFor(reserva => reserva.StatusReserva)
                .IsInEnum().WithMessage("O status da reserva deve ser um valor válido.");
        }
    }
}
