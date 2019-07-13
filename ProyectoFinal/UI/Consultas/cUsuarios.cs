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
    public partial class cUsuarios : Form
    {
        public cUsuarios()
        {
            InitializeComponent();
            Buscar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            var listado = new List<Usuarios>();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

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

                        case 2://Nombre
                            listado = db.GetList(U => U.Nombre == CriteriotextBox.Text);
                            break;

                        case 3:// Usuario
                            listado = db.GetList(U => U.Usuario == CriteriotextBox.Text);
                            break;

                    }

                    if(FechacheckBox.Checked)
                    {
                        listado = listado.Where(U => U.FechaRegistro >= DesdedateTimePicker.Value.Date && U.FechaRegistro <= HastadateTimePicker.Value.Date).ToList();
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

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
