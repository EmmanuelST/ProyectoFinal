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
    public partial class rCliente : Form
    {
        private int IdUsuario;
        public rCliente(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            Clientes cliente = LlenarClase();
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            try
            {

                if(IdnumericUpDown.Value == 0)
                {
                    if(db.Guardar(cliente))
                    {
                        MessageBox.Show("Guardado Existosamente","Atencion!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (db.Modificar(cliente))
                    {
                        MessageBox.Show("Modificado Existosamente", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Modificar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }catch(Exception)
            {
                throw;
               // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if(string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombretextBox,"Este campo no puede estar vacio");
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

            if (FechadateTimePicker.Value > DateTime.Now)
            {
                paso = false;
                errorProvider.SetError(FechadateTimePicker,"La fecha no puede ser mayor que la de hoy");
            }

            if (FechaNacimientodateTimePicker.Value > DateTime.Now)
            {
                paso = false;
                errorProvider.SetError(FechadateTimePicker, "La fecha no puede ser mayor que la de hoy");
            }


            if (LimiteCreditonumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(LimiteCreditonumericUpDown,"Debe fijar un limite de credito");
            }

            if (LimiteVentasnumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(LimiteVentasnumericUpDown, "Debe fijar un limite de credito");
            }

            if(!Clientes.ValidarCedula(CedulatextBox.Text.Trim()))
            {
                paso = false;
                errorProvider.SetError(CedulatextBox,"Esta cedula no es valida");
            }

            


            return paso;
        }

        private Clientes LlenarClase()
        {
            Clientes cliente = new Clientes();

            cliente.IdCliente = (int)IdnumericUpDown.Value;
            cliente.Nombre = NombretextBox.Text;
            cliente.Cedula =  CedulatextBox.Text;
            cliente.Direccion = DirecciontextBox.Text;
            cliente.Telefono =  TelefonotextBox.Text;
            cliente.Celular =  CelulartextBox.Text;
            cliente.FechaCreacion =  FechadateTimePicker.Value;
            cliente.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            cliente.LimiteCredito = LimiteCreditonumericUpDown.Value ;
            cliente.LimiteVenta =  LimiteVentasnumericUpDown.Value;
            cliente.IdUsuario = IdUsuario;
            //cliente.Balance =  BalancetextBox.Text;

            return cliente;
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
            FechadateTimePicker.Value = DateTime.Now;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
            LimiteCreditonumericUpDown.Value = 0;
            LimiteVentasnumericUpDown.Value = 0;
            BalancetextBox.Text = "0.0";
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            errorProvider.Clear();
            try
            {
                if (IdnumericUpDown.Value == 0)
                {
                    errorProvider.SetError(IdnumericUpDown, "Este campo no puede ser cero al eliminar");
                }
                else
                {
                    if(db.Elimimar((int)IdnumericUpDown.Value))
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
            catch(Exception)
            {
                throw;
                // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes cliente;

            try
            {

                if((cliente = db.Buscar((int)IdnumericUpDown.Value)) is null)
                {
                    MessageBox.Show("No se pudo encontrar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LlenarCampos(cliente);
                    
                }

            }catch(Exception)
            {
                throw;
            }

        }

        private void LlenarCampos(Clientes cliente)
        {
            Limpiar();

            IdnumericUpDown.Value = cliente.IdCliente;
            NombretextBox.Text = cliente.Nombre;
            CedulatextBox.Text = cliente.Cedula;
            DirecciontextBox.Text = cliente.Direccion;
            TelefonotextBox.Text = cliente.Telefono;
            CelulartextBox.Text = cliente.Celular;
            FechadateTimePicker.Value = cliente.FechaCreacion;
            FechaNacimientodateTimePicker.Value = cliente.FechaNacimiento;
            LimiteCreditonumericUpDown.Value = cliente.LimiteCredito;
            LimiteVentasnumericUpDown.Value = cliente.LimiteVenta;
            BalancetextBox.Text = cliente.Balance.ToString();
        }
    }
}
