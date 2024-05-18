using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(ExceptionMessage.Id_Not_Found)
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
