using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Infrastructure.Persistence.Repositorio
{
    public class PratoRepository : RepositorioBase<Prato>, IPratoRepository
    {
        public PratoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
    
    
}
