using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prototipo_PED
{
    public partial class mesas : Form
    {
        Conexion con = new Conexion();
        public mesas()
        {
            InitializeComponent();
            actualizar();
        }
        private void actualizar()
        {
            var mesasOcupadas = (from Mesa in con.Mesa join Soli in con.Solicitud on Mesa.ID equals Soli.ID_Mesa select Mesa).ToList();
            foreach(var mesa in mesasOcupadas)
            {
                CambiarEstado(mesa.ID);
            }

        }
        private void CambiarEstado(int num)
        {
            if (num == 1)
            {
                Mesa1.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }else if (num == 2)
            {
                Mesa2.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 3)
            {
                Mesa3.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 4)
            {
                Mesa4.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 5)
            {
                mesa5.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 6)
            {
                mesa6.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 7)
            {
                mesa7.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 8)
            {
                mesa8.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 9)
            {
                mesa9.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 10)
            {
                mesa10.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 11)
            {
                mesa11.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
            else if (num == 12)
            {
                mesa12.Image = prototipo_PED.Properties.Resources.RESERVADO;
            }
        }
        private void send(int num)
        {
            var mesa = (from Mes in con.Mesa where Mes.ID == num select Mes).FirstOrDefault();
            var soli = (from Soli in con.Solicitud where Soli.ID_Mesa == mesa.ID select Soli).FirstOrDefault();
            if (soli != null)
            {
                MessageBox.Show(this, "Esta mesa ya ha sido reservada");
            } else
            {
                cliente frm = new cliente(mesa);
                this.Hide();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.correct == true)
                    {
                        this.Show();
                        actualizar();
                    }                    
                }

            }
        }

        private void Mesa1_Click(object sender, EventArgs e)
        {
            send(1);
        }

        private void Mesa2_Click(object sender, EventArgs e)
        {
            send(2);
        }

        private void Mesa3_Click(object sender, EventArgs e)
        {
            send(3);
        }

        private void Mesa4_Click(object sender, EventArgs e)
        {
            send(4);
        }

        private void mesa5_Click(object sender, EventArgs e)
        {
            send(5);
        }

        private void mesa6_Click(object sender, EventArgs e)
        {
            send(6);
        }

        private void mesa7_Click(object sender, EventArgs e)
        {
            send(7);
        }

        private void mesa8_Click(object sender, EventArgs e)
        {
            send(8);
        }

        private void mesa9_Click(object sender, EventArgs e)
        {
            send(9);
        }

        private void mesa10_Click(object sender, EventArgs e)
        {
            send(10);
        }

        private void mesa11_Click(object sender, EventArgs e)
        {
            send(11);
        }

        private void mesa12_Click(object sender, EventArgs e)
        {
            send(12);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
