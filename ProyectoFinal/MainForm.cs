using ProyectoFinal.UI;
using ProyectoFinal.UI.Consultas;
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
    }
}
