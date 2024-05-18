using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Models.InputModels
{
    public class RestaurantePratoInputModel
    {
        public long RestauranteId { get; set; }
        public long PratoId { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
