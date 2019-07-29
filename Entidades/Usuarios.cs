using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum NivelUsuario : int
    {
        Bajo = 0,
        Medio = 1,
        Alto = 2
        
    }

    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        [Browsable(false)]
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NivelUsuario { get; set; }

        public Usuarios()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            Usuario = string.Empty;
            Clave = string.Empty;
            FechaRegistro = DateTime.Now;
            this.NivelUsuario = "Bajo";
        }

        public static string Encriptar(string cadenaEncriptada)
        {
            string resultado = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(cadenaEncriptada);
            resultado = Convert.ToBase64String(encryted);

            return resultado;
        }

        public static string DesEncriptar(string cadenaDesencriptada)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }
    }
}
