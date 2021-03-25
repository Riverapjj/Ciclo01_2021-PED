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
    public partial class cliente : Form
    {
        Conexion con = new Conexion();
        Validaciones val = new Validaciones();
        Mesa mesa1 = null;
        public bool correct = false;
        public cliente(Mesa mesa)
        {
            InitializeComponent();
            mesa1 = mesa;
        }

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Texto(e);
        }

        private void DtpFechaRes_Leave(object sender, EventArgs e)
        {
            val.fecha(DtpFechaRes);
        }

        private void mtbNumTel_Leave(object sender, EventArgs e)
        {
            string num = mtbNumTel.Text;
            if (val.Fijo(num) || val.Movil(num))
            {

            }
            else
            {
                mtbNumTel.Focus();
                MessageBox.Show("Los numeros telefonicos deben comenzar con 2,7 o 6","Numero Telefonico",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            solicitud.ID_Mesa = mesa1.ID;
            if (!checkUser())
            {
                Usuario usu = new Usuario();
                usu.Correo = txtCorreo.Text;
                usu.Telefono = mtbNumTel.Text;
                usu.Nombre = txtNom.Text;
                usu.Documento = "";
                con.Usuario.InsertOnSubmit(usu);
                con.SubmitChanges();
            }
            var usuario = (from Usu in con.Usuario where Usu.Correo == txtCorreo.Text select Usu).FirstOrDefault();
            solicitud.ID_Usuario = usuario.ID;
            solicitud.ID_Estado = 1;
            solicitud.Fecha = DtpFechaRes.Value;
            solicitud.Hora = TimeSpan.Parse(cbHora.Text.Split('.')[0]);
            con.Solicitud.InsertOnSubmit(solicitud);
            con.SubmitChanges();
            MessageBox.Show(this, "Solicitud Ingresada con éxito");
            correct = true;
            this.Close();
        }

        private bool checkUser()
        {
            var usuario = (from Usu in con.Usuario where Usu.Correo == txtCorreo.Text select Usu).FirstOrDefault();
            if (usuario != null)
            {
                return true;
            }
            return false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
