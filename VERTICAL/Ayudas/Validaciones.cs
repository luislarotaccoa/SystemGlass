using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VERTICAL.Modelos.Publico;

namespace VERTICAL.Ayudas
{
    public class Validaciones
    {
        public static bool ValidarDocumento(Documento codigo, string numero)
        {

            if (numero.Length == 8 && codigo == Documento.DNI)
            {
                if (!DniInvalido(numero))
                {
                    numero = DNIMasControl(numero);
                    return ValidateDocument(numero);
                }
                else
                {
                    return false;
                }

            }
            else if (numero.Length == 11 && codigo == Documento.RUC)
            {
                return ValidarRuc(numero);
            }
            else
            {
                return false;
            }
        }
        private static bool ValidarRuc(string ruc)
        {
            int[] inicialesRUC = { 10, 15, 17, 20 };
            string inicial = ruc.Substring(0, 2);
            //Verificacion de la primera regla
            if (!inicialesRUC.Contains(Convert.ToInt32(inicial)))
            {
                return false;
            }
            else
            {
                int adicion = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                string diezDigitosDelRuc = ruc.Substring(0, ruc.Length - 1);
                for (int i = 0; i < diezDigitosDelRuc.Length; i++)
                {
                    int digruc = diezDigitosDelRuc[i] - '0';
                    int dighash = hash[i];
                    adicion += (digruc * dighash);
                }
                adicion = 11 - (adicion % 11);

                if (adicion == 11)
                {
                    adicion = 1;
                }
                if (adicion == 10)
                {
                    adicion = 0;
                }
                string ultimoDigito = ruc.Substring(ruc.Length - 1, 1);
                if (adicion == Convert.ToInt32(ultimoDigito))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private static bool ValidateDocument(string identificationDocument)
        {
            if (!string.IsNullOrEmpty(identificationDocument))
            {
                int addition = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int identificationDocumentLength = identificationDocument.Length;

                string identificationComponent = identificationDocument.Substring(0, identificationDocumentLength - 1);

                int identificationComponentLength = identificationComponent.Length;

                int diff = hash.Length - identificationComponentLength;

                for (int i = identificationComponentLength - 1; i >= 0; i--)
                {
                    addition += (identificationComponent[i] - '0') * hash[i + diff];
                }

                addition = 11 - (addition % 11);

                if (addition == 11)
                {
                    addition = 1;
                }
                if (addition == 10)
                {
                    addition = 0;
                }

                char last = char.ToUpperInvariant(identificationDocument[identificationDocumentLength - 1]);

                if (identificationDocumentLength == 11)
                {
                    // The identification document corresponds to a RUC.
                    return addition.Equals(last - '0');
                }
                else if (char.IsDigit(last))
                {
                    // The identification document corresponds to a DNI with a number as verification digit.
                    char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                    return last.Equals(hashNumbers[addition]);
                }
                else if (char.IsLetter(last))
                {
                    // The identification document corresponds to a DNI with a letter as verification digit.
                    char[] hashLetters = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                    return last.Equals(hashLetters[addition]);
                }
            }

            return false;
        }
        private static string DNIMasControl(string dni)
        {
            if (!string.IsNullOrEmpty(dni) && dni.Length == 8)
            {
                int addition = 0;
                int[] hash = { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int i = 0; i < dni.Length; i++)
                {
                    addition += (dni[i] - '0') * hash[i];
                }
                addition = 11 - (addition % 11);

                if (addition == 10)
                {
                    addition = 0;
                }
                else if (addition == 11)
                {
                    addition = 1;
                }
                char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                return dni + hashNumbers[addition].ToString();
            }
            else
            {
                return "";
            }
        }
        private static bool DniInvalido(string dni)
        {
            string expresion = "([0-9])\\1{7}";
            if (Regex.IsMatch(dni, expresion))
            {
                return true;
            }
            else if (dni == "00000001" || dni == "00000002" || dni == "10000000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void SoloNumero(KeyPressEventArgs e)
        {

            if (char.IsNumber(e.KeyChar) || (e.KeyChar == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        public static void NumeroDecimal(KeyPressEventArgs e, TextBox Text)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;


            if (e.KeyChar == '.' && String.IsNullOrEmpty(Text.Text))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && Text.Text.Contains('.'))
            {
                e.Handled = true;
            }
            else if (Text.Text.Length == Text.MaxLength - 1 && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            else
            {
                if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || (e.KeyChar == 8))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }
        public static void Mayuscula(KeyPressEventArgs e)
        {
            char caracter;
            caracter = Char.ToUpper(e.KeyChar);
            e.KeyChar = caracter;
        }
        public static void Minuscula(KeyPressEventArgs e)
        {
            char caracter;
            caracter = Char.ToLower(e.KeyChar);
            e.KeyChar = caracter;
        }
    }
}
