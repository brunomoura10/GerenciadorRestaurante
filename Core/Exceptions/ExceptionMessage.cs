using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Exceptions
{
    public static class ExceptionMessage
    {
        public static string RestauranteNaoEncontrado = "Restaurante não encontrado na base de dados";
        public static string PratoNaoEncontrado = "Prato não encontrado na base de dados";
        public static string RestaurantePratoNaoEncontrado = "Relação Restaurante Prato não encontrada na base de dados";
        public static string NehumaReservaEncontradaParadaRestaurante = "Nenhuma reserva encontrada para o restaurante";
    }
}
