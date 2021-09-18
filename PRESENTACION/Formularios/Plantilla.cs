using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PRESENTACION.Formularios
{
    public partial class Plantilla : Form
    {
        
        int PosY = 0;
        int PosX = 0;
        private Rectangle sizeGripRectangle;
        private const int tolerance = 15;
        public Plantilla()
        {
            InitializeComponent();
        }
        public virtual void cerrar()
        {

        }
        public virtual void titulo()
        {

        }
        public virtual void cargaVentana()
        {

        }
        private void Plantilla_Load(object sender, EventArgs e)
        {
            cargaVentana();
            titulo();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            cerrar();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnRestore.IconChar = IconChar.WindowRestore;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnRestore.IconChar = IconChar.WindowMaximize;
            }
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pnlTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                PosX = e.X;
                PosY = e.Y;
            }
            else
            {
                Left = Left + (e.X - PosX);
                Top = Top + (e.Y - PosY);
            }
        }
        private void Plantilla_Shown(object sender, EventArgs e)
        {
           // lblTitulo.Location = Vertical.Ayudas.Centraciones.CentrarControles(lblTitulo, pnlTitulo);
        }
        private void Plantilla_Resize(object sender, EventArgs e)
        {
            //lblTitulo.Location = Vertical.Ayudas.Centraciones.CentrarControles(lblTitulo, pnlTitulo);
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            SolidBrush blueBrush = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        protected override void WndProc(ref Message msj)
        {
            const int CoordenadaWFP = 0x84; //Ubicacion de la parte derecha inferior del form
            const int DesIzquierda = 16;
            const int DesDerecha = 17;
            if (msj.Msg == CoordenadaWFP)
            {
                int x = (int)(msj.LParam.ToInt64() & 0xFFFF);
                int y = (int)((msj.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point CoordenadaArea = PointToClient(new Point(x, y));
                Size TamañoAreaForm = ClientSize;

                if (CoordenadaArea.X >= TamañoAreaForm.Width - 16 && CoordenadaArea.Y >= TamañoAreaForm.Height - 16 && TamañoAreaForm.Height >= 16)
                {
                    msj.Result = (IntPtr)(IsMirrored ? DesIzquierda : DesDerecha);
                    return;
                }
            }
            base.WndProc(ref msj);
        }

        private void Plantilla_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void pnlTitulo_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            timer1.Stop();
        }
    }
}
