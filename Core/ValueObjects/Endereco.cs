using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.ValueObjects
{
    public record Endereco(string Logradouro, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string Cep)
    {

    }
}
