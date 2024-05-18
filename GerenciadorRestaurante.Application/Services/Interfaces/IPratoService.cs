using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IPratoService
    {
        Task CadastrarPrato(PratoInputModel pratoInputModel);
        Task AtualizarPrato(long id, PratoInputModel pratoInputModel);
        Task ExcluirPrato(long id);
        Task<IEnumerable<PratoViewModel>> ObterTodos();
        Task<PratoViewModel> ObterPorId(long id);
    }
}