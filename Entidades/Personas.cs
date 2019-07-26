using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool ValidarCedula(string cedula)
        {
            
            String regex = "^\\d{3}\\D?\\d{7}\\D?\\d$";

            if (Regex.IsMatch(cedula, regex))
                    return true;

            return false;
        }

        public static bool ValidarTelefono(string numero)
        {
            if (numero.Length == 10)
                return true;
            if (numero.Length == 12)
                return true;


            return false;
        }
    }
}
