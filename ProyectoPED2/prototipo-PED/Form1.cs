using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prototipo_PED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerente_Click(object sender, EventArgs e)
        {
            gerente frm = new gerente();
            frm.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            mesas frm = new mesas();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
