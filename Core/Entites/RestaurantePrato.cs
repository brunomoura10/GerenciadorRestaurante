using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Entites
{
    public class RestaurantePrato  : EntidadeBase
    {
        public long RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
        public long PratoId { get; set; }
        public Prato Prato { get; set; }
        public bool Disponivel { get; set; } = true;

    }
}
