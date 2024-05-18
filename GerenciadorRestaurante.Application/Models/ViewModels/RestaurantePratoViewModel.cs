using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Models.ViewModels
{
    public class RestaurantePratoViewModel
    {
        public long Id { get; set; }
        public long RestauranteId { get; set; }
        public string RestauranteNome { get; set; }
        public long PratoId { get; set; }
        public string PratoNome { get; set; }
        public double PratoPreco { get; set; }
        public bool Disponivel { get; set; } 
       



    }
}
