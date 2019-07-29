using BLL;
using Entidades;
using ProyectoFinal.UI.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI
{
    public partial class rUsuario : Form
    {
        private int IdUsuario;
        public rUsuario(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
            NivelcomboBox.SelectedIndex = 0;
        }


        private string Seleccion(int num)
        {
            string seleccion = "Bajo";
            if (num == 0)
                seleccion = "Bajo";
            else
                    if (num == 1)
                seleccion = "Medio";
            else
                if (num == 3)
                seleccion = "Alto";

            return seleccion;
        }

        private int SeleccionInt(string num)
        {
            int seleccion = 0;
            if (num == "Bajo")
                seleccion = 0;
            else
                    if (num == "Medio")
                seleccion = 1;
            else
                if (num == "Alto")
                seleccion = 2;

            return seleccion;
        }

        private bool VerificarUsuario()
        {
            if (IdnumericUpDown.Value == IdUsuario)
                return true;
            else
                return false;
        }

        private bool Validar()
        {
            bool paso = true;
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            errorProvider.Clear();

            if(string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombretextBox,"Este campo no puede estar vacio");
            }

            if (string.IsNullOrWhiteSpace(UsuariotextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombretextBox, "Este campo no puede estar vacio");
            }

            if (string.IsNullOrWhiteSpace(ClavetextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombretextBox, "Este campo no puede estar vacio");
            }

            
            try
            {
                if(db.Repetido(U=> U.Usuario.Equals(UsuariotextBox.Text.Trim())))
                {
                    paso = false;
                    errorProvider.SetError(UsuariotextBox, "Este Usuario ya esta ocupado");
                }

            }
            catch (Exception) { }

            


            return paso;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
                return;
            Usuarios usuario = new Usuarios();
            usuario = LlenarClase();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            try
            {

                if(IdnumericUpDown.Value == 0)
                {
                    if(db.Guardar(usuario))
                    {
                        MessageBox.Show("Guardado correctamente","Informacion!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (db.Modificar(usuario))
                    {
                        MessageBox.Show("Modificado correctamente", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }catch(Exception)
            {
               
                MessageBox.Show("Ocurrio un error", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        private Usuarios LlenarClase()
        {
            Usuarios usuario = new Usuarios()
            {
                IdUsuario = (int)IdnumericUpDown.Value,
                Nombre = NombretextBox.Text,
                Usuario = UsuariotextBox.Text,
                Clave = Usuarios.Encriptar(ClavetextBox.Text),
                FechaRegistro = FechadateTimePicker.Value,
                NivelUsuario = Seleccion(NivelcomboBox.SelectedIndex) 
            };

            return usuario;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            UsuariotextBox.Text = string.Empty;
            ClavetextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            NivelcomboBox.SelectedIndex = 0;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            errorProvider.Clear();

            if (VerificarUsuario())
            {
                MessageBox.Show("No puede Eliminar el usuario que esta en uso", "Infromación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {

                if(IdnumericUpDown.Value > 0)
                {
                    if(db.Elimimar((int)IdnumericUpDown.Value))
                    {
                        MessageBox.Show("Eliminado correctamente", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    errorProvider.SetError(IdnumericUpDown,"Este campo debe ser diferente de 0 para eliminar");
                    
                }


            }catch(Exception)
            {
                
                MessageBox.Show("Ocurrio un error", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios usuario;
            try
            {
                if ((usuario = db.Buscar((int)IdnumericUpDown.Value)) != null)
                {
                    LlenarCampos(usuario);
                }
                else
                {
                    MessageBox.Show("No se encontro el usuario", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }catch(Exception)
            {
                
                MessageBox.Show("Ocurrio un error", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LlenarCampos(Usuarios usuario)
        {
            IdnumericUpDown.Value = usuario.IdUsuario;
            NombretextBox.Text = usuario.Nombre;
            UsuariotextBox.Text = usuario.Usuario;
            ClavetextBox.Text = Usuarios.DesEncriptar(usuario.Clave);
            FechadateTimePicker.Value = usuario.FechaRegistro;
            NivelcomboBox.SelectedIndex = SeleccionInt(usuario.NivelUsuario);
        }

        
    }
}
