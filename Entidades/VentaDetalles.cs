using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentaDetalles
    {

        public int IdVentaDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; } 
        public decimal Cantidad { get; set; }   
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }

        public VentaDetalles()
        {
            IdVentaDetalle = 0;
            IdVenta = 0;
            IdProducto = 0;
            Cantidad = 0;
            Precio = 0;
            SubTotal = 0;
        }
    }
}
