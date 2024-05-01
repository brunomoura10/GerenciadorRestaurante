using GerenciadorRestaurante.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Entites
{
    public class Restaurante : EntidadeBase
    {
     
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
       
        // Relacionamentos
        public ICollection<Mesa> Mesas { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<RestaurantePrato> RestaurantePratos { get; set; }
       

    }
}
