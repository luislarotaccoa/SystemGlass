using System.Drawing;
using System.Windows.Forms;

namespace VERTICAL.Ayudas
{
    public class Centraciones
    {
        public static Point CentrarControles(Control control, Control controlEn)
        {
            return new Point(controlEn.Width / 2 - control.Width / 2, controlEn.Height / 2 - control.Height / 2);
        }
    }
}
