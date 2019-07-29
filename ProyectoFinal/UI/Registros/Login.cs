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
            if (!Validar())
                return;

            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            if(Log_in())
            {
                
                List<Usuarios> usuario = db.GetList(U => U.Usuario == UsuariotextBox.Text);
                MainForm main = new MainForm(usuario[0].IdUsuario);
                Hide();
                main.ShowDialog();
                Dispose();
                
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if(string.IsNullOrWhiteSpace(UsuariotextBox.Text))
            {
                paso = false;
                errorProvider.SetError(UsuariotextBox,"Debe escribir un usuario");
            }

            if (string.IsNullOrWhiteSpace(ContrasenatextBox.Text))
            {
                paso = false;
                errorProvider.SetError(ContrasenatextBox, "Debe escribir una contraseña");
            }


            return paso;
        }

        private bool Log_in()
        {
            bool paso = false;

            try
            {
                RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
                string clave = Usuarios.Encriptar(ContrasenatextBox.Text);
                if (db.Repetido(U => U.Usuario == UsuariotextBox.Text && U.Clave == clave))
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

                if (db.Repetido(U => U.Usuario.Equals("Root")) == false)
                {
                    db.Guardar(new Usuarios()
                    {
                        Nombre = "Root",
                        Usuario = "Root",
                        Clave = Usuarios.Encriptar("Root12345"),
                        NivelUsuario = "Alto",
                        FechaRegistro = DateTime.Now
                    });
                }

            }
            catch (Exception) { }

        }

    }
}
