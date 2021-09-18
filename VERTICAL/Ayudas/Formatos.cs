using System;
using System.Windows.Forms;

namespace VERTICAL.Ayudas
{
    public class Formatos
    {
        public static void FormatCodigo(ref TextBox text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text.Text))
                {
                    int v = 0;
                    string n = text.Text;
                    string[] t;
                    if (n.Contains("."))
                    {
                        t = n.Trim().Split('.');
                        if (t.Length == 2)
                        {
                            if (string.IsNullOrEmpty(t[1]))
                            {
                                text.Text = n;
                            }
                            else
                            {
                                v = Convert.ToInt32(t[1]);
                                string c = string.Format("{0:000}", v);
                                text.Text = t[0] + "." + c;
                            }
                        }
                        else if (t.Length == 3)
                        {
                            if (string.IsNullOrEmpty(t[2]))
                            {
                                text.Text = n;
                            }
                            else
                            {
                                v = Convert.ToInt32(t[2]);
                                string c = string.Format("{0:000}", v);
                                text.Text = t[0] + "." + t[1] + "." + c;
                            }
                        }
                    }
                    else
                    {
                        v = Convert.ToInt32(text.Text);
                        text.Text = string.Format("{0:000}", v);
                    }
                    text.SelectionStart = text.Text.Length;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string FormatCodigo1(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    int v = 0;
                    string n = text;
                    string[] t;
                    string c = "";
                    t = n.Trim().Split('.');
                    if (t.Length == 3)
                    {
                        for (int i = 0; i < t.Length; i++)
                        {
                            v = Convert.ToInt32(t[i]);
                            string c1 = string.Format("{0:000}", v);
                            if (i < 2)
                            {
                                c += c1 + ".";
                            }
                            else
                            {
                                c += c1;
                            }
                        }
                    }

                    return c;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
