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
    public class RestauranteService : IRestauranteService
    {
        private readonly IRestaurantRepository _restauranteRepository;
        private readonly IMapper _mapper;

        public RestauranteService(IRestaurantRepository restauranteRepository, IMapper mapper)
        {
            _restauranteRepository = restauranteRepository;
            _mapper = mapper;
        }

        public async Task AtualizarRestaurante(long id, RestauranteInputModel restauranteInputModel)
        {
            var restaurante = await _restauranteRepository.ObterPorIdAsync(id) ?? throw new RestauranteNaoEncontradoException(); ;

            var restauranteAtualizado = _mapper.Map<Restaurante>(restauranteInputModel);

            await _restauranteRepository.AtualizarAsync(restauranteAtualizado);
        }

        public async Task CadastrarRestaurante(RestauranteInputModel restauranteInputModel)
        {
            var restaurante = _mapper.Map<Restaurante>(restauranteInputModel);

            await _restauranteRepository.InserirAsync(restaurante);
            
        }

        public async Task ExcluirRestaurante(long id)
        {
            var restaurante = _restauranteRepository.ObterPorIdAsync(id) ?? throw new RestauranteNaoEncontradoException();

            await _restauranteRepository.ExcluirAsync(id);
        }

        public async Task<RestauranteViewModel> ObterPorId(long id)
        {
            var restaurante = await _restauranteRepository.ObterPorIdAsync(id) ?? throw new RestauranteNaoEncontradoException();

            return _mapper.Map<RestauranteViewModel>(restaurante);
        }

        public async Task<IEnumerable<RestauranteViewModel>> ObterTodos()
        {
           var restaurantes = await _restauranteRepository.ObterTodosAsync();

            return _mapper.Map<IEnumerable<RestauranteViewModel>>(restaurantes);
        }
    }
}
