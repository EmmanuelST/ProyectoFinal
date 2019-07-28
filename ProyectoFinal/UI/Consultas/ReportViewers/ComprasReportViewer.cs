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
    public partial class ComprasReportViewer : Form
    {
        private List<Compras> lista;
        public ComprasReportViewer(List<Compras> listado)
        {
            InitializeComponent();
            this.lista = listado;
            Cargar();
        }

        private void Cargar()
        {
            CompraReport reporte = new CompraReport();
            reporte.SetDataSource(lista);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();
        }
    }
}
