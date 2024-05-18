using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(ExceptionMessage.Bad_Request)
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }
    }
}
