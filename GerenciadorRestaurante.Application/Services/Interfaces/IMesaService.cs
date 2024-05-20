using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;


namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IMesaService
    {
        Task CadastrarMesa(MesaInputModel mesaInputModel);
        Task AtualizarMesa(long id, MesaInputModel mesaInputModel);
        Task ExcluirMesa(long id);
        Task<IEnumerable<MesaViewModel>> ObterTodos();
        Task<MesaViewModel> ObterPorId(long id);
    }
}