using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI
{
    public partial class rCompras : Form
    {
        private int IdUsuario;
        public rCompras(int IdUsuario)
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
            IdCompranumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            IdAgricultornumericUpDown.Value = 0;
            NombreAgricultortextBox.Text = string.Empty;
            IdPesadornumericUpDown.Value = 0;
            NombrePesadortextBox.Text = string.Empty;
            PesoNetonumericUpDown.Value = 0;
            HumedadnumericUpDown.Value = 0;
            FanegastextBox.Text = "0";
            PrecionumericUpDown.Value = 0;
            CantidadSacosnumericUpDown.Value = 0;
            TotaltextBox.Text = "0.0";
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
                return;

            RepositorioCompras db = new RepositorioCompras();
            Compras compra = LlenarClase();

            try
            {

                if(IdCompranumericUpDown.Value == 0)
                {
                    if(db.Guardar(compra))
                    {
                        MessageBox.Show("Guardado correctamente", "Información!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if(db.Modificar(compra))
                    {
                        MessageBox.Show("Modificado correctamente", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }catch(Exception)
            {
                
                MessageBox.Show("Hubo un error!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private Compras LlenarClase()
        {
            Compras compra = new Compras();

            try
            {
                compra.IdCompra = (int)IdCompranumericUpDown.Value;
                compra.Fecha = FechadateTimePicker.Value;
                compra.IdAgricultor = (int)IdAgricultornumericUpDown.Value;
                compra.IdPesador = (int)IdPesadornumericUpDown.Value;
                compra.PesoNeto = PesoNetonumericUpDown.Value;
                compra.Humedad = HumedadnumericUpDown.Value;
                compra.TotalFanegas = PesoNetonumericUpDown.Value / HumedadnumericUpDown.Value;
                compra.PrecioFanegas = PrecionumericUpDown.Value;
                compra.CantidadSacos = CantidadSacosnumericUpDown.Value;
                compra.Total = decimal.Parse(TotaltextBox.Text);
                compra.IdUsuario = IdUsuario;
            }
            catch (Exception) { }
            

            return compra;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if(IdAgricultornumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(IdAgricultornumericUpDown,"Este campo no puede ser cero");
            }

            if (string.IsNullOrWhiteSpace(NombreAgricultortextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombreAgricultortextBox,"Este campo no puede esta vacio, debe de seleccionar un agricultor");
            }

            if (IdPesadornumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(IdPesadornumericUpDown, "Este campo no puede ser cero");
            }

            if (string.IsNullOrWhiteSpace(NombrePesadortextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombrePesadortextBox, "Este campo no puede esta vacio, debe de seleccionar un pesador");
            }

            if(PesoNetonumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(PesoNetonumericUpDown,"Este campo no puede ser cero");
            }

            if(HumedadnumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(HumedadnumericUpDown,"Este campo no puede ser cero");
            }

            if(PrecionumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(PrecionumericUpDown,"Este campo no puede ser cero");
            }

            if(CantidadSacosnumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(CantidadSacosnumericUpDown,"Este campor no puede ser cero");
            }

            


            return paso;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            RepositorioCompras db = new RepositorioCompras();

            try
            {
                if(db.Elimimar((int)IdCompranumericUpDown.Value))
                {
                    MessageBox.Show("Eliminado correctamente", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }catch(Exception)
            {
                
                MessageBox.Show("Hubo un error!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BuscarComprabutton_Click(object sender, EventArgs e)
        {
            RepositorioCompras db = new RepositorioCompras();

            try
            {
                Compras compra = db.Buscar((int)IdCompranumericUpDown.Value);

                if(compra is null)
                {
                    MessageBox.Show("No se encontro la compra", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    LlenarCampos(compra);
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void LlenarCampos(Compras compra)
        {
            IdCompranumericUpDown.Value = compra.IdCompra;
            FechadateTimePicker.Value =compra.Fecha;
            IdAgricultornumericUpDown.Value = compra.IdAgricultor;
            IdPesadornumericUpDown.Value = compra.IdPesador;
            PesoNetonumericUpDown.Value = compra.PesoNeto;
            HumedadnumericUpDown.Value = compra.Humedad;
            FanegastextBox.Text = compra.TotalFanegas.ToString();
            PrecionumericUpDown.Value = compra.PrecioFanegas;
            CantidadSacosnumericUpDown.Value = compra.CantidadSacos;
            //CalcularTotal();
        }
        
        private void CalcularFanegas()
        {
            try
            {
                decimal fanega = PesoNetonumericUpDown.Value / HumedadnumericUpDown.Value;
                FanegastextBox.Text = fanega.ToString();
            }
            catch (Exception) { }
            
        }

        private void CalcularTotal()
        {
            try
            {
                decimal total = decimal.Parse(FanegastextBox.Text) * PrecionumericUpDown.Value;
                TotaltextBox.Text = total.ToString();
            }
            catch (Exception) { }
           
        }

        private void PesoNetonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularFanegas();
            CalcularTotal();
        }

        private void HumedadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularFanegas();
            CalcularTotal();
        }

        private void PrecionumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void BuscarArgricultor()
        {
            RepositorioBase<Agricultores> db = new RepositorioBase<Agricultores>();
            try
            {
                Agricultores agricultor = db.Buscar((int)IdAgricultornumericUpDown.Value);
                if(agricultor != null)
                    NombreAgricultortextBox.Text = agricultor.Nombre;
                else
                {
                    NombreAgricultortextBox.Text = string.Empty;
                   // MessageBox.Show("No se encontro el Agricultor", "!!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                    

            }
            catch(Exception)
            {
                //MessageBox.Show("No se encontro el Agricultor","!!Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }

        private void BuscarPesador()
        {
            RepositorioBase<Pesadores> db = new RepositorioBase<Pesadores>();
            try
            {

                Pesadores pesador = db.Buscar((int)IdPesadornumericUpDown.Value);
                if(pesador != null)
                    NombrePesadortextBox.Text = pesador.Nombre;
                else
                {
                    NombrePesadortextBox.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("No se encontro el Pesador", "!!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void IdAgricultornumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuscarArgricultor();
            VerificarArroz();
        }

        private void IdPesadornumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuscarPesador();
        }

        private void BuscarAgricultorbutton_Click(object sender, EventArgs e)
        {
            BuscarArgricultor();
        }

        private void Pesadorbutton_Click(object sender, EventArgs e)
        {
            BuscarPesador();
        }

        private void VerificarArroz()
        {
           
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            try
            {
                if (!db.Repetido(P => P.Descripcion.Equals("Arroz Cascara")))
                {
                    MessageBox.Show("El producto Arroz Cascara no existe, Debe crearlo antes de comprar", "!!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                
            }
            catch (Exception) { }

            return;
        }
    }
}
