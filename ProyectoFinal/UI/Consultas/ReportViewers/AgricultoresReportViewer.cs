using CrystalDecisions.CrystalReports.Engine;
using Entidades;
using ProyectoFinal.UI.Consultas.Reporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consultas.ReportViewers
{
    public partial class AgricultoresReportViewer : Form
    {
        private List<Agricultores> lista;
    
        public AgricultoresReportViewer(List<Agricultores> listado)
        {
            InitializeComponent();
            this.lista = listado;
            Cargar();
        }

        private void Cargar()
        {
            AgricultoresReport reporte = new AgricultoresReport();
            reporte.SetDataSource(lista);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();

        }
    }
}
