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
        Task<ClienteViewModel> CadastrarCliente(ClienteInputModel clienteInputModel);

        Task<ClienteViewModel> ConsultarClientePorId(int id);

        Task<IEnumerable<ClienteViewModel>> ConsultarTodosClientes();

        Task<ClienteViewModel> DeletarReserva(int id);

        Task<ClienteViewModel> AtualizarCliente(int id, ClienteInputModel clienteInputModel);
    }
}
