using GerenciadorRestaurante.Core.Enums;
using GerenciadorRestaurante.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Entites
{
    public class Usuario : EntidadeBase    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public TipoUsuario Tipo { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
