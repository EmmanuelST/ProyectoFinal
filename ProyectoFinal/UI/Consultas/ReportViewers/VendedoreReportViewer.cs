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
    public partial class VendedoreReportViewer : Form
    {
        private List<Vendedores> lista;
        public VendedoreReportViewer(List<Vendedores> listado)
        {
            InitializeComponent();
            this.lista = listado;
            Cargar();
        }

        private void Cargar()
        {
            VendedoresReport reporte = new VendedoresReport();
            reporte.SetDataSource(lista);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();
        }
    }
}
