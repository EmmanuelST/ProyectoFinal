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
    public partial class ClientesReportViewer : Form
    {
        private List<Clientes> lista;
        public ClientesReportViewer(List<Clientes> listado)
        {
            InitializeComponent();
            this.lista = listado;
            Cargar();
        }

        private void Cargar()
        {
            ClientesResport reporte = new ClientesResport();
            reporte.SetDataSource(lista);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();
        }
    }
}
