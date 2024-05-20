using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Exceptions;
using GerenciadorRestaurante.Core.Repositories;

namespace GerenciadorRestaurante.Application.Services
{
    public class PratoService : IPratoService
    {
        private readonly IPratoRepository _pratoRepository;
        private readonly IMapper _mapper;

        public PratoService(IPratoRepository pratoRepository, IMapper mapper)
        {
            _pratoRepository = pratoRepository;
            _mapper = mapper;
        }

        public async Task AtualizarPrato(long id, PratoInputModel pratoInputModel)
        {
            var prato = await _pratoRepository.ObterPorIdAsync(id) ?? throw new PratoNaoEncontradoException(); ;

            _mapper.Map(pratoInputModel, prato);

            await _pratoRepository.AtualizarAsync(prato);
        }

        public async Task CadastrarPrato(PratoInputModel pratoInputModel)
        {
            var prato = _mapper.Map<Prato>(pratoInputModel);

            await _pratoRepository.InserirAsync(prato);
        }

        public async Task ExcluirPrato(long id)
        {
            var prato = await _pratoRepository.ObterPorIdAsync(id) ?? throw new PratoNaoEncontradoException();

            await _pratoRepository.ExcluirAsync(prato);
        }

        public async Task<PratoViewModel> ObterPorId(long id)
        {
            var prato = await _pratoRepository.ObterPorIdAsync(id) ?? throw new PratoNaoEncontradoException();

            return _mapper.Map<PratoViewModel>(prato);
        }

        public async Task<IEnumerable<PratoViewModel>> ObterTodos()
        {
            var prato = await _pratoRepository.ObterTodosAsync();

            return _mapper.Map<IEnumerable<PratoViewModel>>(prato);
        }
    }
}