using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioViewModel> CreateAsync(UsuarioInputModel request);
        Task<UsuarioViewModel> GetByIdAsync(long id);
        Task<UsuarioViewModel> GetUsuarioByEmail(string email);
    }
}
