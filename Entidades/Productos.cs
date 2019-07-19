﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public enum UnidadesMedidas : int
    {
        Nada = 0,
        Libras = 1,
        Sacos = 2,
        Fanegas = 3
    }
    public class Productos
    {
        [Key]
        public int IdProductos { get; set; }
        public string Descripcion { get; set; } 
        public decimal Existencia { get; set; }
        public UnidadesMedidas UnidadMedida { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }

        public Productos()
        {
            IdProductos = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            UnidadMedida = UnidadesMedidas.Nada;
            Costo = 0;
            Precio = 0;
            Observacion = string.Empty;
            FechaCreacion = DateTime.Now;
            IdUsuario = 0;
        }
    }
}
