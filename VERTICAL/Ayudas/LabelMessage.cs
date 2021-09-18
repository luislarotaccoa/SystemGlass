using System.Drawing;
using System.Windows.Forms;

namespace VERTICAL.Ayudas
{
    public class LabelMessage
    {
        public static void Mensaje(Timer timer, Label lbl, string remite,string mensaje, Color color)
        {
            lbl.Text = remite.ToUpper()+": "+mensaje;
            lbl.Visible = true;
            lbl.ForeColor = color;
            timer.Interval = 5000;
            timer.Start();
        }
    }
}
