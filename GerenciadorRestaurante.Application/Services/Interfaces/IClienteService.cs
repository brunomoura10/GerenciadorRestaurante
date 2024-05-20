using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task CadastrarCliente(ClienteInputModel clienteInputModel);

        Task<ClienteViewModel> ConsultarClientePorId(int id);

        Task<IEnumerable<ClienteViewModel>> ConsultarTodosClientes();

        Task DeletarCliente(int id);

        Task AtualizarCliente(int id, ClienteInputModel clienteInputModel);
    }
}
