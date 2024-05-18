using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Enums;

namespace GerenciadorRestaurante.Application.Models.ViewModels
{
    public class MesaViewModel
    {
        public long Id { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public LocalizacaoMesa Localizacao { get; set; }
        public long RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}