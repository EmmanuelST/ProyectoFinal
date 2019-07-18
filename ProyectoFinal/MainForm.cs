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
    }
}
