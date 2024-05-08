using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IRestauranteService
    {
        Task CadastrarRestaurante(RestauranteInputModel restauranteInputModel);
        Task AtualizarRestaurante(long id, RestauranteInputModel restauranteInputModel);
        Task ExcluirRestaurante(long id);
        Task<IEnumerable<RestauranteViewModel>> ObterTodos();
        Task<RestauranteViewModel> ObterPorId(long id);



    }
}
