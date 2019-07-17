using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoVentas
    {
        public int IdTipoVenta { get; set; }
        public string Descripcion { get; set; }

        public TipoVentas()
        {
            IdTipoVenta = 0;
            Descripcion = string.Empty;
        }
    }
}
