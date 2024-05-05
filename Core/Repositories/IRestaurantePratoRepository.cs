using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Repositories
{
    public interface IRestaurantePratoRepository : IRepositorioBase<RestaurantePrato>
    {
        Task<RestaurantePrato> ObterPorIdFull(long id);
    }
}
