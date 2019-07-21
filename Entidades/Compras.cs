using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }
        public int IdPesador { get; set; }
        public int IdAgricultor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdUsuario { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal Humedad { get; set; }
        public decimal TotalFanegas {get;set;}
        public decimal PrecioFanegas { get; set; }
        public decimal CantidadSacos { get; set; }

        public Compras()
        {
            IdCompra = 0;
            IdPesador = 0;
            IdAgricultor = 0;
            Fecha = DateTime.Now;
            Total = 0;
            IdUsuario = 0;
            PesoNeto = 0;
            Humedad = 0;
            TotalFanegas = 0;
            PrecioFanegas = 0;
            CantidadSacos = 0;
        }
    }
}
