using BLL;
using Entidades;
using Entidades.View;
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
    public partial class VentasReportViewer : Form
    {
        private List<Ventas> listado;
        List<VentasView> lista ;
        public VentasReportViewer(List<Ventas> listados)
        {
            InitializeComponent();
            this.listado = listados;
            lista = new List<VentasView>();
            LlenarClase();
            VentasReport reporte = new VentasReport();
            reporte.SetDataSource(lista);
            MycrystalReportViewer.ReportSource = reporte;
            MycrystalReportViewer.Refresh();
        }

        private void LlenarClase()
        {
            RepositorioBase<Clientes> dbC = new RepositorioBase<Clientes>();
            RepositorioBase<Vendedores> dbV = new RepositorioBase<Vendedores>();
            lista = new List<VentasView>();

            foreach(var item in this.listado)
            {
                Clientes cliente = dbC.Buscar(item.IdCliente);
                Vendedores vendedor = dbV.Buscar(item.IdVendedor);
                lista.Add(new VentasView()
                {
                    IdVenta = item.IdVenta,
                    Nombre = vendedor.Nombre,
                    Expr1 = cliente.Nombre,
                    Fecha = item.Fecha,
                    HastaFecha = item.HastaFecha,
                    Total = item.Total
                });

            }
        }
    }
}
