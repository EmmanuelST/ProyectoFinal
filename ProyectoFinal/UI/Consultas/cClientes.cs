﻿using BLL;
using Entidades;
using ProyectoFinal.UI.Consultas.ReportViewers;
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
    public partial class cClientes : Form
    {
        private List<Clientes> listado;
        public cClientes()
        {
            InitializeComponent();
            listado = new List<Clientes>();
            FiltrocomboBox.SelectedIndex = 0;
            Buscar();
        }

        private void Buscar()
        {
            listado = new List<Clientes>();
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();

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
                            listado = db.GetList(U => U.IdCliente == id);
                            break;

                        case 2://Nombre
                            listado = db.GetList(U => U.Nombre.Contains(CriteriotextBox.Text));
                            break;

                        case 3:// Balance
                            listado = db.GetList(U => U.Balance == decimal.Parse(CriteriotextBox.Text));
                            break;

                        case 4://FechaNacimiento
                            listado = db.GetList(U => true);
                            listado = listado.Where(U => U.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && U.FechaNacimiento.Date <= HastadateTimePicker.Value.Date).ToList();
                            break;
                    }




                }
                catch (Exception)
                {
                    
                }

            }
            else
            {
                if (FiltrocomboBox.SelectedIndex == 3)
                {
                    listado = db.GetList(U => true);
                    listado = listado.Where(U => U.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && U.FechaNacimiento.Date <= HastadateTimePicker.Value.Date).ToList();

                }
                else
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
            if(FiltrocomboBox.SelectedIndex == 4)
            {
                FechacheckBox.Checked = false;
                FechacheckBox.Enabled = false;
            }                
            else
                FechacheckBox.Enabled = true;

            Buscar();
        }

        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            ClientesReportViewer viewer = new ClientesReportViewer(listado);
            viewer.ShowDialog();
        }
    }
}
