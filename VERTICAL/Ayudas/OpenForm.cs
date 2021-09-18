using System.Drawing;
using System.Windows.Forms;

namespace VERTICAL.Ayudas
{
    public class OpenForm
    {
        public static void AbrirForm(Form _form, Panel panel)
        {
            int _Y = 20;
            Control[] c = panel.Controls.Find(_form.Name, true);
            if (c.Length > 0)
            {
                if ((c[0] as Form).WindowState == FormWindowState.Minimized)
                {
                    (c[0] as Form).WindowState = FormWindowState.Normal;
                }
                else
                {
                    (c[0] as Form).BringToFront();
                }
            }
            else
            {
                int count = panel.Controls.Count;
                int _X = (panel.Width - _form.Width) / 2;
                if (count > 0)
                {
                    _Y += 27;
                    _X += 7;
                }
                _form.TopLevel = false;
                panel.Controls.Add(_form);
                panel.Tag = _form;
                _form.BringToFront();
                Point p = new Point(_X, _Y);
                _form.Location = p;
                _form.Show();
            }
        }
    }
}
