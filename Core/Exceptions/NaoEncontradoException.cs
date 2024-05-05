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
}
