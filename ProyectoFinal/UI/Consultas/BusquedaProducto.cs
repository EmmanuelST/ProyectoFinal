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

namespace ProyectoFinal.UI.Consultas
{
    public partial class BusquedaProducto : Form
    {
        
        private List<Productos> listado;
        public int id { get; set; }

        public BusquedaProducto()
        {
            InitializeComponent();
            listado = new List<Productos>();
            id = 0;
           
            Buscar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        
        private void Buscar()
        {
            
            RepositorioBase<Productos> db = new RepositorioBase<Productos>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {

                try
                {

                    switch (FiltrocomboBox.SelectedIndex)
                    {
                        case 0://Todo
                            listado = db.GetList(U => true);
                            break;

                        case 1://ID
                            int id = int.Parse(CriteriotextBox.Text);
                            listado = db.GetList(U => U.IdUsuario == id);
                            break;

                        case 2://Descripcion
                            listado = db.GetList(U => U.Descripcion == CriteriotextBox.Text);
                            break;

                        case 3:// Usuario
                            listado = db.GetList(U => U.IdUsuario == int.Parse(CriteriotextBox.Text));
                            break;

                    }

                    if (FechacheckBox.Checked)
                    {
                        listado = listado.Where(U => U.FechaCreacion >= DesdedateTimePicker.Value.Date && U.FechaCreacion <= HastadateTimePicker.Value.Date).ToList();
                    }


                }
                catch (Exception)
                {

                }

            }
            else
            {
                listado = db.GetList(p => true);
            }

            //listado = listado.Where(E => E.FechaIngreso >= DesdedateTimePicker.Value.Date  && E.FechaIngreso <= HastadateTimePicker.Value.Date ).ToList();

            //ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }

        private void ConsultadataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = ConsultadataGridView.CurrentRow.Index;
            this.Close();
        }

        private void ConsultadataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = ConsultadataGridView.CurrentRow.Index;
            this.Hide();
        }
    }
}
