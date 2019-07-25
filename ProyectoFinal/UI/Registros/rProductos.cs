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
    public partial class rProductos : Form
    {
        private int IdUsuario;
        public rProductos(int IdUsuario)
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
            DescripciontextBox.Text = string.Empty;
            UnidadMedidacomboBox.SelectedIndex = 1;
            CostonumericUpDown.Value = 0;
            PrecionumericUpDown.Value = 0;
            ExistenciatextBox.Text = "0";
            ObservaciontextBox.Text = string.Empty;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            if (!Validar())
                return;

            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos producto = LlenarClase();

            try
            {

                if (IdnumericUpDown.Value == 0)
                {
                    if (db.Guardar(producto))
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
                    if (db.Modificar(producto))
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

        private Productos LlenarClase()
        {
            Productos producto = new Productos();
            try
            {
               
                producto.IdProductos = (int)IdnumericUpDown.Value;
                producto.Descripcion = DescripciontextBox.Text;
                producto.UnidadMedida = (UnidadesMedidas)UnidadMedidacomboBox.SelectedIndex;
                producto.Costo = CostonumericUpDown.Value;
                producto.Precio = PrecionumericUpDown.Value;
                producto.Existencia = decimal.Parse(ExistenciatextBox.Text);
                producto.Observacion = ObservaciontextBox.Text;
                producto.IdUsuario = IdUsuario;

            }
            catch(Exception)
            {

            }
            return producto;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if(string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                paso = false;
                errorProvider.SetError(DescripciontextBox,"Este campo no puede estar vacio");
            }

            if(CostonumericUpDown.Value == 0)
            {
                paso = false;
                errorProvider.SetError(CostonumericUpDown,"Este campo no puede ser cero");
            }

            if(PrecionumericUpDown.Value <= CostonumericUpDown.Value)
            {
                paso = false;
                errorProvider.SetError(PrecionumericUpDown,"El precio no puede ser igual o menos que el costo");
            }


            return paso;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
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
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos producto;

            try
            {

                if ((producto = db.Buscar((int)IdnumericUpDown.Value)) is null)
                {
                    MessageBox.Show("No se pudo encontrar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LlenarCampos(producto);

                }

            }
            catch (Exception)
            {
                throw;
                // MessageBox.Show("Hubo un error!!", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCampos(Productos producto)
        {

            IdnumericUpDown.Value = producto.IdProductos;
            DescripciontextBox.Text = producto.Descripcion;
            UnidadMedidacomboBox.SelectedIndex = (int)producto.UnidadMedida;
            CostonumericUpDown.Value = producto.Costo;
            PrecionumericUpDown.Value = producto.Precio;
            ExistenciatextBox.Text = producto.Existencia.ToString();
            ObservaciontextBox.Text = producto.Observacion;
        }
    }
}
