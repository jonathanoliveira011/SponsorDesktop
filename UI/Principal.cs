using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moninterprise_tcc
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {

            Evento evt = new Evento();
            evt.Show();
            this.Hide();

        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {

            Empresas emp = new Empresas();
            emp.Show();
            this.Hide();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Login log = new Login();
            log.Show();
            this.Hide();

        }
    }
}
