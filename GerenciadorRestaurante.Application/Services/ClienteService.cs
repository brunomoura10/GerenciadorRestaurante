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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }


        public async Task AtualizarCliente(int id, ClienteInputModel clienteInputModel)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(id) ?? throw new NotFoundException(); ;

            _mapper.Map(clienteInputModel, cliente);

            await _clienteRepository.AtualizarAsync(cliente);
        }

        public async Task CadastrarCliente(ClienteInputModel clienteInputModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteInputModel);

            await _clienteRepository.InserirAsync(cliente);
        }

        public async Task<ClienteViewModel> ConsultarClientePorId(int id)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(id) ?? throw new NotFoundException();

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> ConsultarTodosClientes()
        {
            var clientes = await _clienteRepository.ObterTodosAsync();

            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        }

        public async Task DeletarCliente(int id)
        {
            var cliente = await _clienteRepository.ObterPorIdAsync(id) ?? throw new NotFoundException();

            await _clienteRepository.ExcluirAsync(cliente);
        }
    }
}
