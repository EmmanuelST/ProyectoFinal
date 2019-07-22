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
    public partial class rVentas : Form
    {
        private List<VentaDetalles> Detalles;
        public rVentas()
        {
            InitializeComponent();
            Detalles = new List<VentaDetalles>();
        }

        private void CargarGrip()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = this.Detalles;
            //DetalledataGridView.Refresh();
        }

        private void RefreshTotal()
        {
            decimal total = 0;

            foreach(var item in Detalles)
            {
                total += item.SubTotal;
            }

            TotaltextBox.Text = total.ToString();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdVentanumericUpDown.Value = 0;
            FechaVentadateTimePicker.Value = DateTime.Now;
            IdClientenumericUpDown.Value = 0;
            NombreClientetextBox.Text = string.Empty;
            IdVendedornumericUpDown.Value = 0;
            NombreVendedortextBox.Text = string.Empty;
            TipoVentacomboBox.SelectedIndex = 0;
            InteresnumericUpDown.Value = 0;
            HastadateTimePicker.Value = DateTime.Now;
            IdProductonumericUpDown.Value = 0;
            NombreProductotextBox.Text = string.Empty;
            ProductoCantidadnumericUpDown.Value = 0;
            Detalles = new List<VentaDetalles>();
            CargarGrip();
            RefreshTotal();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            RepositorioVentas db = new RepositorioVentas();
            Ventas venta = LlenarClase();

            try
            {
                if(IdVentanumericUpDown.Value == 0)
                {
                    if(db.Guardar(venta))
                    {
                        MessageBox.Show("Guardado correctamente", "Información!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar","Atencion!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if(db.Modificar(venta))
                    {
                        MessageBox.Show("Guardado correctamente", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }catch(Exception)
            {
                throw;
                //MessageBox.Show("Hubo un error!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void BuscarCliente()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

            try
            {
                Clientes cliente = db.Buscar((int)IdClientenumericUpDown.Value);
                NombreClientetextBox.Text = cliente.Nombre;
            }
            catch (Exception) { }
        }

        private void BuscarVendedor()
        {
            RepositorioBase<Vendedores> db = new RepositorioBase<Vendedores>();

            try
            {
                Vendedores vendedor = db.Buscar((int)IdVendedornumericUpDown.Value);
                NombreVendedortextBox.Text = vendedor.Nombre;
            }
            catch (Exception) { }
        }

        private Ventas LlenarClase()
        {
            Ventas venta = new Ventas();

            venta.IdVenta = (int)IdVentanumericUpDown.Value;
            venta.Fecha = FechaVentadateTimePicker.Value;
            venta.IdCliente = (int)IdClientenumericUpDown.Value;
            venta.IdVendedor =(int)IdVendedornumericUpDown.Value;
            venta.TipoVeta = (TiposVentas)TipoVentacomboBox.SelectedIndex;
            venta.TasaInteres = InteresnumericUpDown.Value;
            venta.HastaFecha = HastadateTimePicker.Value;
            venta.Detalles = Detalles;
            RefreshTotal();
            try
            {
                venta.Total = decimal.Parse(TotaltextBox.Text);
            }catch (Exception) { }
            
            return venta;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if(IdClientenumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(IdClientenumericUpDown,"Este campo no puede ser cero");

            }

            if(string.IsNullOrWhiteSpace(NombreClientetextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombreClientetextBox,"Este campo no puede estar vacio, seleccione un cliente");

            }

            if (IdVendedornumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(IdVendedornumericUpDown, "Este campo no puede ser cero");

            }

            if (string.IsNullOrWhiteSpace(NombreVendedortextBox.Text))
            {
                paso = false;
                errorProvider.SetError(NombreVendedortextBox, "Este campo no puede estar vacio, seleccione un vendedor");

            }

            if(TipoVentacomboBox.SelectedIndex == 0)
            {
                paso = false;
                errorProvider.SetError(TipoVentacomboBox,"Debe seleccionar un tipo de venta");

            }

            if(TipoVentacomboBox.SelectedIndex == 2)
            {
              
                if(InteresnumericUpDown.Value == 0)
                {
                    paso = false;
                    errorProvider.SetError(InteresnumericUpDown,"Este campo no puede ser cero, debe fijar un porcentaje de interes");
                }

                if(HastadateTimePicker.Value == DateTime.Now)
                {
                    paso = false;
                    errorProvider.SetError(HastadateTimePicker, "La fecha de hasta no puede ser la misma de hoy");
                }

            }

            if(Detalles.Count == 0)
            {
                paso = false;
                errorProvider.SetError(DetalledataGridView, "Debe agregar almenos un articulo");
            }

            return paso;
        }

        private void IdClientenumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void IdVendedornumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            BuscarVendedor();
        }

        private Productos BuscarProducto()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            try
            {
                producto = db.Buscar((int)IdProductonumericUpDown.Value);
            }
            catch (Exception) { }

            return producto;
        }

        private void IdProductonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                NombreProductotextBox.Text = BuscarProducto().Descripcion;
            }
            catch (Exception) { }
            
        }

        private void AgregarProductobutton_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();
            if(string.IsNullOrWhiteSpace(NombreProductotextBox.Text))
            {
                errorProvider.SetError(NombreProductotextBox,"Debe seleccionar un producto");
                return;
            }

            if(ProductoCantidadnumericUpDown.Value == 0)
            {
                errorProvider.SetError(ProductoCantidadnumericUpDown,"La cantidad debe ser mayor que cero");
                return;
            }

            Productos producto;
            if ((producto = BuscarProducto())!= null)
            {
                VentaDetalles detalle = new VentaDetalles()
                {
                    IdProducto = producto.IdProductos,
                    Precio = producto.Precio,
                    Cantidad = ProductoCantidadnumericUpDown.Value

                };

                detalle.CalularSubTotal();

                Detalles.Add(detalle);
                CargarGrip();

                RefreshTotal();
            }
            
        }

        private void EliminarFilabutton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                if(Detalles.Count > 0)
                {
                    Detalles.RemoveAt(DetalledataGridView.CurrentRow.Index);
                    CargarGrip();
                    RefreshTotal();
                }
                else
                {
                    errorProvider.SetError(DetalledataGridView,"Debe haber productos en la lista para eliminar");
                }
                
            }
            catch (Exception) { }
        }

        private void BuscarProductobutton_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            int id = 0;
            BusquedaProducto consulta = new BusquedaProducto();
            consulta.ShowDialog();
            IdProductonumericUpDown.Value = consulta.id;
            consulta.Close();
        }

        private void BuscarVentabutton_Click(object sender, EventArgs e)
        {
            RepositorioVentas db = new RepositorioVentas();
            
            try
            {
                Ventas venta;
                if ((venta = db.Buscar((int)IdVentanumericUpDown.Value))!= null)
                {
                    LlenarCampos(venta);
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar","Informacion!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                
            }catch(Exception)
            {
                throw;
            }

        }

        private void LlenarCampos(Ventas venta)
        {
            IdVentanumericUpDown.Value = venta.IdVenta;
            FechaVentadateTimePicker.Value = venta.Fecha;
            IdClientenumericUpDown.Value = venta.IdCliente;
            IdVendedornumericUpDown.Value = venta.IdVendedor;
            TipoVentacomboBox.SelectedIndex = (int)venta.TipoVeta;
            InteresnumericUpDown.Value = venta.TasaInteres;
            HastadateTimePicker.Value = venta.HastaFecha;
            Detalles = venta.Detalles;
            CargarGrip();
            RefreshTotal();

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioVentas db = new RepositorioVentas();

            try
            {
                if(db.Elimimar((int)IdVentanumericUpDown.Value))
                {
                    MessageBox.Show("eliminado correctamente", "Información!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Informacion!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }catch(Exception)
            {
                throw;
            }
        }
    }
}
