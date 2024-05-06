using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<RestaurantePrato> ObterPorId(long id)
        {
             var restaurantePrato = await _dbSet.Include(rp => rp.Prato)
                                                        .Include(rp => rp.Restaurante)
                                                        .Select(e => new RestaurantePrato
                                                        {
                                                            Id = e.Id,
                                                            RestauranteId = e.RestauranteId,
                                                            PratoId = e.PratoId,
                                                            Disponivel = e.Disponivel,
                                                            Prato = new Prato
                                                            {
                                                                Nome = e.Prato.Nome,
                                                                Preco = e.Prato.Preco
                                                            },
                                                            Restaurante = new Restaurante
                                                            {
                                                                Nome = e.Restaurante.Nome
                                                            }
                                                        })
                                                        .FirstOrDefaultAsync(e => e.Id == id);
            
       
            return restaurantePrato;
            
        }
    }
}
