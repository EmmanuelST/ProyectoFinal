using ProyectoFinal.UI;
using ProyectoFinal.UI.Consultas;
using ProyectoFinal.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Login login = new Login();
            login.ShowDialog();
           
        }

        private void limitador()
        {
            registrarUsuariosToolStripMenuItem.Enabled = false;
        }

        private void RegistrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario registro = new rUsuario();
            registro.MdiParent = this;
            registro.Show();
        }

        private void ConsultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cUsuarios consulta = new cUsuarios();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void RegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCliente registro = new rCliente();
            registro.MdiParent = this;
            registro.Show();
        }

        private void RegistrarPesadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rPesador registro = new rPesador();
            registro.MdiParent = this;
            registro.Show();
        }

        private void RegistroDeVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVendedor registro = new rVendedor();
            registro.MdiParent = this;
            registro.Show();
        }

        private void RegistroDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos registro = new rProductos();
            registro.MdiParent = this;
            registro.Show();
        }

        private void EntradaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradaProducto registro = new rEntradaProducto();
            registro.MdiParent = this;
            registro.Show();
        }

        private void RegistroDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCompras registro = new rCompras();
            registro.MdiParent = this;
            registro.Show();
        }

        private void RegistroDeAgricultoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAgricultor registro = new rAgricultor();
            registro.MdiParent = this;
            registro.Show();
        }

        private void RegistroDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVentas registro = new rVentas();
            registro.MdiParent = this;
            registro.Show();
        }

        private void ConsultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cClientes consulta = new cClientes();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void ConsultarVendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cVendedor consulta = new cVendedor();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void ConsultarAgriculturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cAgricultor consulta = new cAgricultor();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void ConsultarPesadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPesadores consulta = new cPesadores();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void ConsultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cProductos consulta = new cProductos();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void ConsultarComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cCompras consulta = new cCompras();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void ConsultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cVentas consulta = new cVentas();
            consulta.MdiParent = this;
            consulta.Show();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
