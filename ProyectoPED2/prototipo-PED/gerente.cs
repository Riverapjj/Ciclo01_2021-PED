using prototipo_PED.Clases;
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
    public partial class gerente : Form
    {
        Solicitud solicitud = new Solicitud();
        Queue<Soli> [] colas = new Queue<Soli>[13];
        int tec = 0;
        public gerente()
        {
            InitializeComponent(); 
            for (int i = 0; i < 13; i++)
            {
                colas[i] = new Queue<Soli>();
            }
            cmb1.SelectedIndex = 0;
            
        }
        private void llenardgv()
        {
            dgvReservas.DataSource = null;
        }

        private void gerente_Load(object sender, EventArgs e)
        {
            llenardgv();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int x = cmb1.SelectedIndex;

            Soli nuevo = new Soli();
            nuevo.estado = 1;
            nuevo.fecha = DateTime.Today;
            nuevo.hora = DateTime.Now;
            nuevo.ID = ++tec;
            nuevo.usuario = 1;
            nuevo.mesa = x;

            if (x == 0)
            {
                for (int i = 1; i < 13; i++)
                {
                    if (colas[i].Count == 0)
                    {
                        nuevo.mesa = i;
                        colas[i].Enqueue(nuevo);
                        actualizar();
                        return;
                    }
                }
            }

            colas[x].Enqueue(nuevo);
            actualizar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        public void actualizar()
        {
            dgvReservas.Rows.Clear();
            foreach (Soli x in colas[cmb1.SelectedIndex])
            {
                dgvReservas.Rows.Add(x.ID, x.mesa, 1, 1, "7034-5565", "Juan Perez");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try{
                colas[cmb1.SelectedIndex].Dequeue();
                if (colas[cmb1.SelectedIndex].Count == 0)
                {
                    if(colas[0].Count > 0)
                    {
                        colas[cmb1.SelectedIndex].Enqueue(colas[0].Peek());
                        colas[cmb1.SelectedIndex].Peek().mesa = cmb1.SelectedIndex;
                        colas[0].Dequeue();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Está vacía");
            }
            
        }
    }
}
