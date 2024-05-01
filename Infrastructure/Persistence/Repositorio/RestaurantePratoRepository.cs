using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure.Persistence.Repositorio
{
    public class RestaurantePratoRepository : RepositorioBase<RestaurantePrato>, IRestaurantePratoRepository
    {
        public RestaurantePratoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
