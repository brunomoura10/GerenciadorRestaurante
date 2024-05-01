﻿using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Repositories
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        Task<T> InserirAsync(T entidade);
        Task<T> AtualizarAsync(T entidade);
        Task<T> ObterPorIdAsync(long id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task ExcluirAsync(long id);
    }
}
