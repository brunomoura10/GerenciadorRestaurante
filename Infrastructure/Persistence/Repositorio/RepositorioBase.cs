using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure.Persistence.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> AtualizarAsync(T entidade)
        {
            
            entidade.DataAlteracao = DateTime.Now;    
            
            _dbSet.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public virtual async Task ExcluirAsync(long id)
        {
            var entidade = await ObterPorIdAsync(id);
            _dbSet.Remove(entidade);
            await _context.SaveChangesAsync();
         
        }

        public virtual async Task<bool> ExistAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public virtual async Task<T> InserirAsync(T entidade)
        {
            _dbSet.Add(entidade);
            await _context.SaveChangesAsync(); 
            return entidade;
        }

        public virtual async Task<T> ObterPorIdAsync(long id)
        {
           return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
