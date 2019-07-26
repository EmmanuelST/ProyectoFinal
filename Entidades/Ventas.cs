using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum TiposVentas : int
    {
        Contado = 0,
        Credito = 1

    }
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }
        public TiposVentas TipoVeta { get; set; }
        public decimal TasaInteres { get; set; }
        public DateTime HastaFecha { get; set; }
        public decimal Balance { get; set; }
        public virtual List<VentaDetalles> Detalles { get; set; }

        public Ventas()
        {
            IdVenta = 0;
            IdVendedor = 0;
            IdCliente = 0;
            Fecha = DateTime.Now;
            Total = 0;
            IdUsuario = 0;
            TipoVeta = TiposVentas.Contado;
            TasaInteres = 0;
            HastaFecha = DateTime.Now;
            Detalles = new List<VentaDetalles>();
        }


        public decimal CalcularInteres()
        {
            return (TasaInteres / 100) / Total;
        }
    }
}
