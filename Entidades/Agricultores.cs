using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Agricultores : Personas
    {
        public int IdAgricultor { get; set; }
        public decimal Balance { get; set; }

        public Agricultores()
        {
            IdAgricultor = 0;
            Balance = 0;
        }
    }
}
