using GerenciadorRestaurante.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GerarToken(LoginInputModel login);
    }
}
