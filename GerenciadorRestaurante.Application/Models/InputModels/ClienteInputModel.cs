using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Enums;
using GerenciadorRestaurante.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Models.InputModels
{
    public class ClienteInputModel
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public TipoUsuario Tipo { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
