using FluentValidation;
using GerenciadorRestaurante.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Validation
{
    public class ClienteInputValidator : AbstractValidator<ClienteInputModel>
    {
        public ClienteInputValidator()
        {
            RuleFor(cliente => cliente.Nome)
        .NotEmpty().WithMessage("O nome é obrigatório.")
        .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(cliente => cliente.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");

            RuleFor(cliente => cliente.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$").WithMessage("O telefone deve ser um número válido.");

            RuleFor(cliente => cliente.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("O CPF deve ser um número válido no formato 000.000.000-00.");

            RuleFor(cliente => cliente.DataNascimento)
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data passada.");

            RuleFor(cliente => cliente.Endereco)
                .NotNull().WithMessage("O endereço é obrigatório.")
                .SetValidator(new EnderecoValidator());

            RuleFor(cliente => cliente.Tipo)
                .IsInEnum().WithMessage("O tipo de usuário deve ser um valor válido.");
        }
    }
}
