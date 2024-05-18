using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Models.ViewModels
{
    public class ReservaViewModel
    {
        public DateTime DataReserva { get; set; }
        public int QuantidadePessoas { get; set; }
        public string Observacao { get; set; } = string.Empty;
        public StatusReserva StatusReserva { get; set; }
        public Mesa Mesa { get; set; }
        public Usuario Usuario { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
