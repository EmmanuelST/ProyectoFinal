using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pesadores : Personas
    {
        [Key]
        public int IdPesador { get; set; }

        public Pesadores()
        {
            IdPesador = 0;
        }

    }
}
