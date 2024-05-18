using GerenciadorRestaurante.Core.Entites;
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
        public long Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAlteracao { get;  private set; }
        public string Nome { get;  private set; }
        public string Descricao { get; private set; }
        public Endereco Endereco { get; private set; }
        public IEnumerable<RestaurantePrato> RestaurantePratos { get; set; }
        public IEnumerable<Reserva> Reservas { get; set; }
        public IEnumerable<Mesa> Mesas { get; set; }

    }
}
