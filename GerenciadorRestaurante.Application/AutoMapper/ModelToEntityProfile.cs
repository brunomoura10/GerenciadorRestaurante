﻿using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.AutoMapper
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<RestauranteInputModel, Restaurante>();
            CreateMap<ReservaInputModel, Reserva>();
            CreateMap<RestaurantePratoInputModel, RestaurantePrato>();
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<UsuarioInputModel, Usuario>();
            CreateMap<MesaInputModel, Mesa>();
            CreateMap<PratoInputModel, Prato>();
        }
    }
}
