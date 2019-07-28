using Entidades;
using ProyectoFinal.UI.Consultas.Reporte.Facturas;
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
    public partial class FacturaVentaViewer : Form
    {
        List<Ventas> lista;
        public FacturaVentaViewer(Ventas venta)
        {
            InitializeComponent();
            lista = new List<Ventas>();
            this.lista.Add(venta);
            Cargar();
        }

        private void Cargar()
        {
            VentasFactura factura = new VentasFactura();
            factura.SetDataSource(lista);
            MycrystalReportViewer.ReportSource = factura;
            MycrystalReportViewer.Refresh();
        }
    }
}
