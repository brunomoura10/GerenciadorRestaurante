using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Exceptions
{
    public class RestauranteNaoEncontradoException : Exception
    {
        public RestauranteNaoEncontradoException(string message) : base(message)
        {
        }
        public RestauranteNaoEncontradoException() : base(ExceptionMessage.RestauranteNaoEncontrado)
        {
        }
    }

    public class PratoNaoEncontradoException : Exception
    {
        public PratoNaoEncontradoException(string message) : base(message)
        {
        }
        public PratoNaoEncontradoException() : base(ExceptionMessage.PratoNaoEncontrado)
        {
        }
    }

    public class RestaurantePratoNaoEncontradoException : Exception
    {
        public RestaurantePratoNaoEncontradoException(string message) : base(message)
        {
        }
        public RestaurantePratoNaoEncontradoException() : base(ExceptionMessage.RestaurantePratoNaoEncontrado)
        {
        }
    }


    public class MesaNaoEncontradaException : Exception
    {
        public MesaNaoEncontradaException(string message) : base(message)
        {
        }
        public MesaNaoEncontradaException() : base(ExceptionMessage.MesaNaoEncontrada)

    public class NehumaReservaEncontradaParadaRestaurante : Exception
    {
        public NehumaReservaEncontradaParadaRestaurante(string message) : base(message)
        {
        }
        public NehumaReservaEncontradaParadaRestaurante() : base(ExceptionMessage.NehumaReservaEncontradaParadaRestaurante)

        {
        }
    }
}
