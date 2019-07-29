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

namespace ProyectoFinal.UI
{
    public partial class rPesador : Form
    {
        private int IdUsuario;
        public rPesador(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            CedulatextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonotextBox.Text = string.Empty;
            CelulartextBox.Text = string.Empty;
            FechaRegistrodateTimePicker.Value = DateTime.Now;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
            
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            Pesadores pesador = LlenarClase();
            RepositorioBase<Pesadores> db = new RepositorioBase<Pesadores>();

            try
            {

                if (IdnumericUpDown.Value == 0)
                {
                    if (db.Guardar(pesador))
                    {
                        MessageBox.Show("Guardado Existosamente", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (db.Modificar(pesador))
                    {
                        MessageBox.Show("Modificado Existosamente", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Modificar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }
            catch (Exception)
            {
                
                 MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Pesadores LlenarClase()
        {
            Pesadores pesador = new Pesadores();

            pesador.IdPesador = (int)IdnumericUpDown.Value;
            pesador.Nombre = NombretextBox.Text;
            pesador.Cedula = CedulatextBox.Text;
            pesador.Direccion = DirecciontextBox.Text;
            pesador.Telefono = TelefonotextBox.Text;
            pesador.Celular = CelulartextBox.Text;
            pesador.FechaCreacion = FechaRegistrodateTimePicker.Value;
            pesador.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            pesador.IdUsuario = IdUsuario;
           

            return pesador;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombretextBox, "Este campo no puede estar vacio");
            }

            if (string.IsNullOrWhiteSpace(CedulatextBox.Text))
            {
                paso = false;
                errorProvider.SetError(CedulatextBox, "Este campo no puede estar vacio");
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                paso = false;
                errorProvider.SetError(DirecciontextBox, "Este campo no puede estar vacio");
            }

            if (string.IsNullOrWhiteSpace(TelefonotextBox.Text))
            {
                paso = false;
                errorProvider.SetError(TelefonotextBox, "Este campo no puede estar vacio");
            }


            if (FechaRegistrodateTimePicker.Value > DateTime.Now)
            {
                paso = false;
                errorProvider.SetError(FechaRegistrodateTimePicker, "La fecha no puede ser mayor que la de hoy");
            }

            if (FechaNacimientodateTimePicker.Value > DateTime.Now)
            {
                paso = false;
                errorProvider.SetError(FechaNacimientodateTimePicker, "La fecha no puede ser mayor que la de hoy");
            }

            if (!Personas.ValidarCedula(CedulatextBox.Text.Trim()))
            {
                paso = false;
                errorProvider.SetError(CedulatextBox, "Esta cedula no es valida");
            }

            


            return paso;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pesadores> db = new RepositorioBase<Pesadores>();
            errorProvider.Clear();
            try
            {
                if (IdnumericUpDown.Value == 0)
                {
                    errorProvider.SetError(IdnumericUpDown, "Este campo no puede ser cero al eliminar");
                }
                else
                {
                    if (db.Elimimar((int)IdnumericUpDown.Value))
                    {
                        MessageBox.Show("Eliminado Existosamente", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }
            catch (Exception)
            {
                
                 MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pesadores> db = new RepositorioBase<Pesadores>();
            Pesadores pesador;

            try
            {

                if ((pesador = db.Buscar((int)IdnumericUpDown.Value)) is null)
                {
                    MessageBox.Show("No se pudo encontrar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LlenarCampos(pesador);

                }

            }
            catch (Exception)
            {
               
                 MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCampos(Pesadores pesador)
        {
            Limpiar();

            IdnumericUpDown.Value = pesador.IdPesador;
            NombretextBox.Text = pesador.Nombre;
            CedulatextBox.Text = pesador.Cedula;
            DirecciontextBox.Text = pesador.Direccion;
            TelefonotextBox.Text = pesador.Telefono;
            CelulartextBox.Text = pesador.Celular;
            FechaRegistrodateTimePicker.Value = pesador.FechaCreacion;
            FechaNacimientodateTimePicker.Value = pesador.FechaNacimiento;
            
        }
    }
}
