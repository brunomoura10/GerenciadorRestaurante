using GerenciadorRestaurante.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Repositories
{
    public interface IUsuarioRepository : IRepositorioBase<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetByNomeUsuarioAsync(string nomeUsuario);
    }
}
