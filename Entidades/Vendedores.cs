using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedores : Personas
    {
        public int IdVendedor { get; set; }

        public Vendedores()
        {
            IdVendedor = 0;
        }

    }
}
