using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Exceptions;
using GerenciadorRestaurante.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services
{
    public class RestaurantePratoService : IRestaurantePratoService
    {
        private readonly IRestaurantePratoRepository _restaurantePratoRepository;
        private readonly IRestaurantRepository _restauranteRepository;
        //private readonly IPratoRepository _pratoRepository;
        private readonly IMapper _mapper;

        public RestaurantePratoService(IRestaurantePratoRepository restaurantePratoRepository, IRestaurantRepository restauranteRepository, IMapper mapper)
        {
            _restaurantePratoRepository = restaurantePratoRepository;
            _restauranteRepository = restauranteRepository;
            _mapper = mapper;
        }

        public async Task AtualizarRestaurantePrato(long id, RestaurantePratoUpdateModel restaurantePratoUpdateModel)
        {
            var resturantePrato = await _restaurantePratoRepository.ObterPorIdAsync(id) ?? throw new RestaurantePratoNaoEncontradoException();

            resturantePrato.Disponivel = restaurantePratoUpdateModel.Disponivel;
            
            await _restaurantePratoRepository.AtualizarAsync(resturantePrato);

        }


        public async Task CadastrarPratoRestaurante(RestaurantePratoInputModel restaurantePratoInputModel)
        {
            var restaurante = await _restauranteRepository.ObterPorIdAsync(restaurantePratoInputModel.RestauranteId) ?? throw new RestauranteNaoEncontradoException();
            
            //var prato = await _pratoRepository.ObterPorIdAsync(pratoInputModel.PratoId) ?? throw new PratoNaoEncontradoException();

            var restaurantePrato = _mapper.Map<RestaurantePrato>(restaurantePratoInputModel);

            await _restaurantePratoRepository.InserirAsync(restaurantePrato);

        }

        public async Task<RestaurantePratoViewModel> ObterRestaurantePrato(long id)
        {
            var restaurantePrato = await _restaurantePratoRepository.ObterPorIdAsync(id) ?? throw new RestaurantePratoNaoEncontradoException();

            return _mapper.Map<RestaurantePratoViewModel>(restaurantePrato);
        }

        public async Task<IEnumerable<RestaurantePratoViewModel>> ObterTodosRestaurantePrato()
        {
            var restaurantePratos = await _restaurantePratoRepository.ObterTodosAsync();

            return _mapper.Map<IEnumerable<RestaurantePratoViewModel>>(restaurantePratos);

        }
    }
}
