using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Exceptions
{
    public class ExceptionMessage
    {
        public static string Id_Not_Found = "Consulta não encontrada";
        public static string Bad_Request = "Requisição inválida";
        public static string Unknown_Error = "Erro Desconhecido";
        public static string Reserva_Already_Exists = "Objeto já cadastrado";
    }
}
