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
    public partial class rAgricultor : Form
    {
        private int IdUsuario;
        public rAgricultor(int IdUsuario)
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
            BalancetextBox.Text = "0.0";

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            Agricultores agricultor = LlenarClase();
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();

            try
            {

                if (IdnumericUpDown.Value == 0)
                {
                    if (db.Guardar(agricultor))
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
                    if (db.Modificar(agricultor))
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
                throw;
                // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Agricultores LlenarClase()
        {
            Agricultores agricultor = new Agricultores();

            agricultor.IdAgricultor = (int)IdnumericUpDown.Value;
            agricultor.Nombre = NombretextBox.Text;
            agricultor.Cedula = CedulatextBox.Text;
            agricultor.Direccion = DirecciontextBox.Text;
            agricultor.Telefono = TelefonotextBox.Text;
            agricultor.Celular = CelulartextBox.Text;
            agricultor.FechaCreacion = FechaRegistrodateTimePicker.Value;
            agricultor.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            agricultor.IdUsuario = IdUsuario;
            try
            {
                agricultor.Balance = decimal.Parse(BalancetextBox.Text);
            }
            catch (Exception){ }

            return agricultor;
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

            if (string.IsNullOrWhiteSpace(CelulartextBox.Text))
            {
                paso = false;
                errorProvider.SetError(CelulartextBox, "Este campo no puede estar vacio");
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
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();
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
                throw;
                // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();
            Agricultores agricultores;

            try
            {

                if ((agricultores = db.Buscar((int)IdnumericUpDown.Value)) is null)
                {
                    MessageBox.Show("No se pudo encontrar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LlenarCampos(agricultores);

                }

            }
            catch (Exception)
            {
                throw;
                // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarCampos(Agricultores agricultor)
        {
            Limpiar();

            IdnumericUpDown.Value = agricultor.IdAgricultor;
            NombretextBox.Text = agricultor.Nombre;
            CedulatextBox.Text = agricultor.Cedula;
            DirecciontextBox.Text = agricultor.Direccion;
            TelefonotextBox.Text = agricultor.Telefono;
            CelulartextBox.Text = agricultor.Celular;
            FechaRegistrodateTimePicker.Value = agricultor.FechaCreacion;
            FechaNacimientodateTimePicker.Value = agricultor.FechaNacimiento;
            BalancetextBox.Text = agricultor.Balance.ToString();

        }
    }
}
