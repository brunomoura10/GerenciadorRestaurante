using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Entites
{
    public class Prato : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public ICollection<RestaurantePrato> RestaurantePratos { get; set; }

    }
}
