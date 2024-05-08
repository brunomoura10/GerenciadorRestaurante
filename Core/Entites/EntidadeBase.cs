using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorRestaurante.Core.Entites
{
    public class EntidadeBase
    {
        public long Id { get; set; }
        public DateTime DataCriacao { get;  set; }
        public DateTime DataAlteracao { get;  set; }

        public EntidadeBase()
        {
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

    }
}
