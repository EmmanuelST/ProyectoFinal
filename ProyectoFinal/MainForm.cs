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
            /*Login login = new Login();
            login.ShowDialog();*/
           
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
    }
}
