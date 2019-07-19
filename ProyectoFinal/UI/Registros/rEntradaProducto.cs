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
    public partial class rEntradaProducto : Form
    {

        private Productos producto;
        public rEntradaProducto()
        {
            InitializeComponent();
            producto = new Productos();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            ExistencianumericUpDown.Value = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            hacerCambios();

            try
            {
                if(db.Modificar(producto))
                {
                    MessageBox.Show("Guardado correctamente","Atencion!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("no se pudo guardar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }catch(Exception)
            {
                throw;
                //MessageBox.Show("Hubo un error!!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void hacerCambios()
        {
            this.producto.Existencia = ExistencianumericUpDown.Value;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if(string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                paso = false;
                errorProvider.SetError(DescripciontextBox,"Debe buscar un producto antes de guardar");
            }

            return paso;
        }

        private void Buscar()
        {
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();
            Productos producto;

            try
            {
                if((producto = db.Buscar((int)IdnumericUpDown.Value)) is null)
                {
                    MessageBox.Show("No se pudo encontrar el producto","Atencion!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    LlenarCampos(producto);
                    this.producto = producto;
                }


            }catch(Exception)
            {
                throw;
                //MessageBox.Show("Hubo un error!!!","Error!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
        }
        private void LlenarCampos(Productos producto)
        {
            
            DescripciontextBox.Text = producto.Descripcion;
            ExistencianumericUpDown.Value = producto.Existencia;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
