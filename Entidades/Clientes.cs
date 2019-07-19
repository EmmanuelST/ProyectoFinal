using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes : Personas
    {
        [Key]
        public int IdCliente { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal LimiteVenta { get; set; }
        public decimal Balance { get; set; }
       

        public Clientes()
        {
            IdCliente = 0;
            LimiteCredito = 0;
            LimiteVenta = 0;
            Balance = 0;
            
        }
    }
}
