using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly IRestaurantRepository _restauranteRepository;
        private readonly IMapper _mapper;

        public RestauranteService(IRestaurantRepository restauranteRepository, IMapper mapper)
        {
            _restauranteRepository = restauranteRepository;
            _mapper = mapper;
        }

        public async Task CadastrarRestaurante(RestauranteInputModel restauranteInputModel)
        {
            var restaurante = _mapper.Map<Restaurante>(restauranteInputModel);

            await _restauranteRepository.InserirAsync(restaurante);
            
        }
    }
}
