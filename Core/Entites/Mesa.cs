using GerenciadorRestaurante.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Entites
{
    public class Mesa : EntidadeBase
    {
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public LocalizacaoMesa Localizacao { get; set; }
        public long RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
