using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VERTICAL.Controles
{
    public partial class TextBoxValidado : TextBox
    {
        public TextBoxValidado()
        {
            InitializeComponent();
            KeyPress += txt_KeyPess;
            Leave += txtEmail_Leave;
        }
        public Boolean TextBoxNumero { get; set; }
        public Boolean TextBoxDecimales { get; set; }
        public int Decimales { get; set; }
        public Boolean TextBoxEmail { get; set; }
        public Boolean TextBoxUrl { get; set; }
        public Boolean TextBoxMayus { get; set; }

        private void txt_KeyPess(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
            NumeroDecimales(e);
            Mayuscula(e);
        }

        private void Mayuscula(KeyPressEventArgs e)
        {
            if (TextBoxMayus)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        public void SoloNumero(KeyPressEventArgs e)
        {
            if (TextBoxNumero)
            {
                if (char.IsNumber(e.KeyChar) || (e.KeyChar == 8))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }
        public void NumeroDecimales(KeyPressEventArgs e)
        {
            if (TextBoxDecimales)
            {
                CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
                string separador = cc.NumberFormat.NumberDecimalSeparator;

                if (e.KeyChar.ToString() == separador && String.IsNullOrEmpty(Text))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar.ToString() == separador && Text.Contains(separador))
                {
                    e.Handled = true;
                }
                else if (Text.Length == MaxLength-1 && e.KeyChar.ToString() == separador)
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == separador || (e.KeyChar == 8))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }
        }
        public Boolean ValidarEmail(String email)
        {
            if (TextBoxEmail)
            {
                String expresion;
                if (!String.IsNullOrEmpty(email))
                {
                    expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                    if (Regex.IsMatch(email, expresion))
                    {
                        if (Regex.Replace(email, expresion, String.Empty).Length == 0)
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
                else
                {
                    return true;
                }
            }
            else return false;
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (TextBoxEmail)
            {
                if (!ValidarEmail(Text))
                {
                    MessageBox.Show("Su correo no es valido");
                    Focus();
                }
            }
        }

    }
}