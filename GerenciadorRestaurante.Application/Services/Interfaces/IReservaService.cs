using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IReservaService
    {
        Task<ReservaViewModel> CadastrarReserva(ReservaInputModel reservaInputModel);

        Task<ReservaViewModel> ConsultarReservaPorId(int id);

        Task<IEnumerable<ReservaViewModel>> ConsultarTodasAsReservas();

        Task<ReservaViewModel> DeletarReserva(int id);

        Task  AtualizarReserva(int id, ReservaInputModel reservaInputModel);
    }
}
