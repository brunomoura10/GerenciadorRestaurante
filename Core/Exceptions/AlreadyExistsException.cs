using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Exceptions
{
    public class AlreadyExistsException : Exception
    {

        public AlreadyExistsException() : base(ExceptionMessage.Reserva_Already_Exists)
        {
    
        }

        public AlreadyExistsException(string message) : base(message)
        {

        }

    }
}
