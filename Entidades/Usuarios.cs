using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        [Browsable(false)]
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int NivelUsuario { get; set; }

        public Usuarios()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            Usuario = string.Empty;
            Clave = string.Empty;
            FechaRegistro = DateTime.Now;
            NivelUsuario = 0;
        }
    }
}
