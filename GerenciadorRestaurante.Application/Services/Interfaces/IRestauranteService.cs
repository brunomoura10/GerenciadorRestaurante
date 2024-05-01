using GerenciadorRestaurante.Application.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Application.Services.Interfaces
{
    public interface IRestauranteService
    {
        //a ser implementado, falta gerar os dto's
        Task CadastrarRestaurante(RestauranteInputModel restauranteInputModel);
    }
}
