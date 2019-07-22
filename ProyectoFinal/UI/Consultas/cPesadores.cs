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
    public partial class cPesadores : Form
    {
        private List<Pesadores> listado;
        public cPesadores()
        {
            InitializeComponent();
            listado = new List<Pesadores>();
            FiltrocomboBox.SelectedIndex = 0;
            Buscar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            listado = new List<Pesadores>();
            RepositorioBase<Pesadores> db = new RepositorioBase<Pesadores>();

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
                            listado = db.GetList(U => U.IdPesador == id);
                            break;

                        case 2://Nombre
                            listado = db.GetList(U => U.Nombre.Contains(CriteriotextBox.Text));
                            break;

                            /*case 3:// Balance
                                listado = db.GetList(U => U.Balance == decimal.Parse(CriteriotextBox.Text));
                                break;*/

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

            if (FechacheckBox.Checked)
            {
                listado = listado.Where(U => U.FechaCreacion >= DesdedateTimePicker.Value.Date && U.FechaCreacion <= HastadateTimePicker.Value.AddDays(1).Date).ToList();
            }

            ConsultadataGridView.DataSource = listado;
        }


        private void FechacheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void DesdedateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void HastadateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
