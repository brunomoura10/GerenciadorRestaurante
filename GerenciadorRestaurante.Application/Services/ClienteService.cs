using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services
{
    public class ClienteService : IClienteService
    {
        public Task<ClienteViewModel> AtualizarCliente(int id, ClienteInputModel clienteInputModel)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> CadastrarCliente(ClienteInputModel clienteInputModel)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> ConsultarClientePorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteViewModel>> ConsultarTodosClientes()
        {
            throw new NotImplementedException();
        }

        public Task<ClienteViewModel> DeletarReserva(int id)
        {
            throw new NotImplementedException();
        }
    }
}
