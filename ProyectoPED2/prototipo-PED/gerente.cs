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
        Conexion con = new Conexion();
        Cola [] colas = new Cola[13];
        int tec = 0;
        public gerente()
        {
            InitializeComponent(); 
            for (int i = 0; i < 13; i++)
            {
                colas[i] = new Cola();
            }
            cmb1.SelectedIndex = 0;
            
        }
        private void llenardgv()
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = obtenerSolicitudes();
        }

        public List<sp_solicitudesResult> obtenerSolicitudes()
        {
            var selectSolicitudes = con.sp_solicitudes();

            return selectSolicitudes.ToList();
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
                    if (colas[i].tam == 0)
                    {
                        nuevo.mesa = i;
                        colas[i].Insertar(nuevo);
                        actualizar();
                        return;
                    }
                }
            }

            colas[x].Insertar(nuevo);
            actualizar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        public void actualizar()
        {
            dgvReservas.AutoGenerateColumns = true;
            List<Soli> nueva = colas[cmb1.SelectedIndex].Mostrar();
            dgvReservas.DataSource = nueva;

            MessageBox.Show(nueva.Count.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try{
                colas[cmb1.SelectedIndex].Eliminar();
                if (colas[cmb1.SelectedIndex].tam == 0)
                {
                    if(colas[0].tam > 0)
                    {
                        colas[cmb1.SelectedIndex].Insertar(colas[0].inicio.Datos);
                        colas[cmb1.SelectedIndex].inicio.Datos.mesa = cmb1.SelectedIndex;
                        colas[0].Eliminar();
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
