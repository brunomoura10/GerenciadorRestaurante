using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using GerenciadorRestaurante.Core.Exceptions;

namespace GerenciadorRestaurante.Application.Services
{
    public class MesaService : IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IMapper _mapper;

        public MesaService(IMesaRepository mesaRepository, IMapper mapper)
        {
            _mesaRepository = mesaRepository;
            _mapper = mapper;
        }

        public async Task AtualizarMesa(long id, MesaInputModel mesaInputModel)
        {
            var mesa = await _mesaRepository.ObterPorIdAsync(id) ?? throw new MesaNaoEncontradaException(); ;

            _mapper.Map(mesaInputModel,mesa);

            await _mesaRepository.AtualizarAsync(mesa);
        }

        public async Task CadastrarMesa(MesaInputModel mesaInputModel)
        {
            var mesa = _mapper.Map<Mesa>(mesaInputModel);

            await _mesaRepository.InserirAsync(mesa);
        }

        public async Task ExcluirMesa(long id)
        {
            var mesa = await _mesaRepository.ObterPorIdAsync(id) ?? throw new MesaNaoEncontradaException();

            await _mesaRepository.ExcluirAsync(mesa);
        }

        public async Task<MesaViewModel> ObterPorId(long id)
        {
            var mesa = await _mesaRepository.ObterPorIdAsync(id) ?? throw new MesaNaoEncontradaException();

            return _mapper.Map<MesaViewModel>(mesa);
        }

        public async Task<IEnumerable<MesaViewModel>> ObterTodos()
        {
           var mesa = await _mesaRepository.ObterTodosAsync();

            return _mapper.Map<IEnumerable<MesaViewModel>>(mesa);
        }
    }
}