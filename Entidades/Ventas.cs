using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        public int IdVenta { get; set; }    
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; } 
        public decimal Total { get; set; }  
        public int IdUsuario { get; set; }  
        public int TipoVeta { get; set; }
        public decimal TasaInteres { get; set; }
        public DateTime HastaFecha { get; set; }
        public virtual List<VentaDetalles>Detalles { get; set; }

        public Ventas()
        {
            IdVenta = 0;
            IdVendedor = 0;
            IdCliente = 0;
            Fecha = DateTime.Now;
            Total = 0;
            IdUsuario = 0;
            TipoVeta = 0;
            TasaInteres = 0;
            HastaFecha = DateTime.Now;
            Detalles = new List<VentaDetalles>();
        }
    }
}
