﻿using BLL;
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

            RepositorioBase<Compras> db = new RepositorioBase<Compras>();
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
                throw;
                //MessageBox.Show("Hubo un error!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private Compras LlenarClase()
        {
            Compras compra = new Compras();

            compra.IdCompra = (int) IdCompranumericUpDown.Value;
            compra.Fecha =  FechadateTimePicker.Value;
            compra.IdAgricultor = (int) IdAgricultornumericUpDown.Value;
            compra.IdPesador = (int) IdPesadornumericUpDown.Value;
            compra.PesoNeto =  PesoNetonumericUpDown.Value;
            compra.Humedad = HumedadnumericUpDown.Value;
            compra.TotalFanegas = decimal.Parse(FanegastextBox.Text);
            compra.PrecioFanegas =  PrecionumericUpDown.Value;
            compra.CantidadSacos =  CantidadSacosnumericUpDown.Value;
            compra.Total = decimal.Parse(TotaltextBox.Text);
            compra.IdUsuario = IdUsuario;

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

            RepositorioBase<Compras> db = new RepositorioBase<Compras>();

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
                throw;
                //MessageBox.Show("Hubo un error!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BuscarComprabutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Compras> db = new RepositorioBase<Compras>();

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
                throw;
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
                NombreAgricultortextBox.Text = agricultor.Nombre;

            }
            catch(Exception)
            {
                
            }
            
        }

        private void BuscarPesador()
        {
            RepositorioBase<Pesadores> db = new RepositorioBase<Pesadores>();
            try
            {

                Pesadores pesador = db.Buscar((int)IdPesadornumericUpDown.Value);
                NombrePesadortextBox.Text = pesador.Nombre;
            }
            catch (Exception)
            {
            }

        }

        private void IdAgricultornumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuscarArgricultor();
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
    }
}
