using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Registros
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.ControlBox = false;
            Root();
            UsuariotextBox.Focus();
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {

            if(Log_in())
            {
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos");
            }

        }

        private bool Log_in()
        {
            bool paso = false;

            try
            {
                RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
                if (db.Repetido(U => U.Usuario == UsuariotextBox.Text && U.Clave == ContrasenatextBox.Text))
                {
                    paso = true;
                }
            }
            catch (Exception) { }


            return paso;
        }

        private void Root()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            try
            {

                if (!db.Repetido(U => U.Usuario.Equals("Root")))
                {
                    db.Guardar(new Usuarios()
                    {
                        Nombre = "Root",
                        Usuario = "Root",
                        Clave = "Root12345",
                        NivelUsuario = 5,
                        FechaRegistro = DateTime.Now
                    });
                }

            }
            catch (Exception) { }

        }
    }
}
