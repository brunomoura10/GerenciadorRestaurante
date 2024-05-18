using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.AutoMapper
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<RestauranteInputModel, Restaurante>();
            CreateMap<RestaurantePratoInputModel, RestaurantePrato>();
            CreateMap<MesaInputModel, Mesa>();
            CreateMap<PratoInputModel, Prato>();
        }

    }
}
