using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personas
    {
        //public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion {get;set;}
        public int IdUsuario { get; set; }

        public Personas()
        {
            //IdPersona = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            FechaNacimiento = DateTime.Now;
            Direccion = string.Empty;
            Celular = string.Empty;
            Telefono = string.Empty;
            FechaCreacion = DateTime.Now;
            IdUsuario = 0;
        }
    }
}
