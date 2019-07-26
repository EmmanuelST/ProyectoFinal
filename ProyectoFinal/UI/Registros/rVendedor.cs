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
    public partial class rVendedor : Form
    {
        private int IdUsuario;
        public rVendedor(int IdUsuario)
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

            Vendedores vendedor = LlenarClase();
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();

            try
            {

                if (IdnumericUpDown.Value == 0)
                {
                    if (db.Guardar(vendedor))
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
                    if (db.Modificar(vendedor))
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

        private Vendedores LlenarClase()
        {
            Vendedores vendedor = new Vendedores();

            vendedor.IdVendedor = (int)IdnumericUpDown.Value;
            vendedor.Nombre = NombretextBox.Text;
            vendedor.Cedula = CedulatextBox.Text;
            vendedor.Direccion = DirecciontextBox.Text;
            vendedor.Telefono = TelefonotextBox.Text;
            vendedor.Celular = CelulartextBox.Text;
            vendedor.FechaCreacion = FechaRegistrodateTimePicker.Value;
            vendedor.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            vendedor.IdUsuario = IdUsuario;


            return vendedor;
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
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();
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
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();
            Vendedores vendedores;

            try
            {

                if ((vendedores = db.Buscar((int)IdnumericUpDown.Value)) is null)
                {
                    MessageBox.Show("No se pudo encontrar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LlenarCampos(vendedores);

                }

            }
            catch (Exception)
            {
                throw;
                // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCampos(Vendedores vendedor)
        {
            Limpiar();

            IdnumericUpDown.Value = vendedor.IdVendedor;
            NombretextBox.Text = vendedor.Nombre;
            CedulatextBox.Text = vendedor.Cedula;
            DirecciontextBox.Text = vendedor.Direccion;
            TelefonotextBox.Text = vendedor.Telefono;
            CelulartextBox.Text = vendedor.Celular;
            FechaRegistrodateTimePicker.Value = vendedor.FechaCreacion;
            FechaNacimientodateTimePicker.Value = vendedor.FechaNacimiento;

        }
    }
}
