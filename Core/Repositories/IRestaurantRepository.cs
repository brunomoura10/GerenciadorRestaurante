﻿using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Repositories
{
    public interface IRestaurantRepository: IRepositorioBase<Restaurante>
    {
        Task<Restaurante> ObterRestauranteComReservasAsync(long id, DateTime dataReserva);
    }
}
