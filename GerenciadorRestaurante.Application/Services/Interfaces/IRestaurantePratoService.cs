using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IRestaurantePratoService
    {
        Task CadastrarPratoRestaurante( RestaurantePratoInputModel restaurantePratoInputModel);
        Task<RestaurantePratoViewModel> ObterRestaurantePrato(long id);
        Task<IEnumerable<RestaurantePratoViewModel>> ObterTodosRestaurantePrato();
        Task AtualizarRestaurantePrato(long id,RestaurantePratoUpdateModel restaurantePratoUpdateModel);

        
    }
}
