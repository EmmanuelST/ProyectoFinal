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

namespace ProyectoFinal.UI.Consultas
{
    public partial class UsuariosReportViewer : Form
    {
        private List<Usuarios> listado;
        public UsuariosReportViewer(List<Usuarios> listados)
        {
            InitializeComponent();
            this.listado = listado;
            UsuariosReport reporte = new UsuariosReport();
            reporte.SetDataSource(listado);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();

        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            /*UsuariosReport reporte = new UsuariosReport();
            reporte.SetDataSource(listado);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();*/

            
        }
    }
}
