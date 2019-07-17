using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes : Personas
    {
        public int IdCliente { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal Balance { get; set; }
        public int IdVendedor { get; set; }

        public Clientes()
        {
            IdCliente = 0;
            LimiteCredito = 0;
            Balance = 0;
            IdVendedor = 0;
        }
    }
}
