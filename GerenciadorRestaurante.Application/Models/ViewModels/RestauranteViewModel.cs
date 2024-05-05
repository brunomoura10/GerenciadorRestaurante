using GerenciadorRestaurante.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Models.ViewModels
{
    public class RestauranteViewModel
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public Endereco Endereco { get;  set; }


    }
}
