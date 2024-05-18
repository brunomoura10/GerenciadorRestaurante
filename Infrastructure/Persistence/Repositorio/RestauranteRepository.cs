using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Enums;
using GerenciadorRestaurante.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure.Persistence.Repositorio
{
    public class RestauranteRepository : RepositorioBase<Restaurante>, IRestaurantRepository
    {
        public RestauranteRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Restaurante> ObterRestauranteComReservasAsync(long id, DateTime dataReserva)
        {
            var inicioDia = dataReserva.Date;
            var fimDia = dataReserva.Date.AddDays(1).AddTicks(-1);

            var restaurante = await _dbSet.Include(restaurante => restaurante.Reservas)
                                .Where(restaurante => restaurante.Id == id)
                                .Select(restaurante => new Restaurante
                                {
                                    Id = restaurante.Id,
                                    Nome = restaurante.Nome,
                                    Reservas = null
                                })
                                .FirstOrDefaultAsync();

            if (restaurante != null)
            {
                var reservas = await _context.Reservas
                                            .Where(reserva => reserva.RestauranteId == id
                                                              && reserva.DataReserva >= inicioDia
                                                              && reserva.DataReserva <= fimDia
                                                              && reserva.StatusReserva == StatusReserva.Confirmada)
                                            .Select(reserva => new Reserva
                                            {
                                                Id = reserva.Id,
                                                DataReserva = reserva.DataReserva,
                                                QuantidadePessoas = reserva.QuantidadePessoas,
                                                Observacao = reserva.Observacao,
                                                StatusReserva = reserva.StatusReserva,
                                                MesaId = reserva.MesaId,
                                                UsuarioId = reserva.UsuarioId,
                                                
                                            })
                                            .ToListAsync();

                restaurante.Reservas = reservas;
            }

            return restaurante;
        }
    }
}
