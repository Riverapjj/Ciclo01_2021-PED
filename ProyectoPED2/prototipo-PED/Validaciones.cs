using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace prototipo_PED
{
    class Validaciones
    {
        public void Texto(KeyPressEventArgs i)
        {
            if (char.IsLetter(i.KeyChar))
            {
                i.Handled = false;
            }
            else if (char.IsUpper(i.KeyChar))
            {
                i.Handled = false;
            }
            else if (char.IsControl(i.KeyChar))
            {
                i.Handled = false;
            }
            else if (char.IsWhiteSpace(i.KeyChar))
            {
                i.Handled = false;
            }else if (i.KeyChar == '.')
            {
                i.Handled = false;
            }
        else
            {
                i.Handled = true;
            }
        }
        public void Num(NumericUpDown numer)
        {
            if ((numer.Value <= 0) || (numer.Value > 8))
            {
                MessageBox.Show("El numero de personas debe encontrarse entre 1 y 8","Numero de personas por mesa",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                numer.Focus();
            }
            else
            {
            }
        }
        public void fecha(DateTimePicker time)
        {
            DateTime actual = DateTime.Now;
            if (time.Value<actual)
            {
                MessageBox.Show("La fecha de la reserva no puede ser una fecha pasada","Fecha de Reserva",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                time.Focus();
            }
        }
        public void Money(KeyPressEventArgs i, TextBox box)
        {
            if (char.IsNumber(i.KeyChar))
            {
                i.Handled = false;
            }
            else if (char.IsControl(i.KeyChar))
            {
                i.Handled = false;
            }
            else if ((i.KeyChar == '.') && (!box.Text.Contains('.')))
            {
                i.Handled = false;
            }
            else
            {
                i.Handled = true;
            }
        }
        public bool Correo(string mail)
        {
            string expresion = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9- ]+)*(.[a-z]{2,4})$";
            if (Regex.IsMatch(mail, expresion))
            {
                if (Regex.Replace(mail, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                return false;
            }
        }
        public bool Fijo(string cel)
        {
            string expresion = @"^((2)[0-9]{3}-?[0-9]{4})$";
            if (Regex.IsMatch(cel, expresion))
            {
                if (Regex.Replace(cel, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                return false;
            }
        }
        public bool Movil(string cel)
        {
            string expresion = @"^((6|7)[0-9]{3}-?[0-9]{4})$";
            if (Regex.IsMatch(cel, expresion))
            {
                if (Regex.Replace(cel, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                return false;
            }
        }
    }
}
