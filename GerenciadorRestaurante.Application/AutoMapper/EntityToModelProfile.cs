using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.ViewModels;

namespace GerenciadorRestaurante.Application.AutoMapper
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<Restaurante, RestauranteViewModel>();
            CreateMap<RestaurantePrato, RestaurantePratoViewModel>();
            CreateMap<Reserva, ReservaViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }     
    }
}
