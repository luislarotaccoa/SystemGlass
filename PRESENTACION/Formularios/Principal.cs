using FontAwesome.Sharp;
using PRESENTACION.Formularios.Cliente;
using PRESENTACION.Formularios.Empleado;
using PRESENTACION.Formularios.Producto;
using PRESENTACION.Formularios.Proveedor;
using System;
using System.Windows.Forms;
using VERTICAL.Ayudas;

namespace PRESENTACION.Formularios
{
    public partial class Principal : Form
    {

        public Principal()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
        }

        private void CerrarSesion()
        {
            Program.IdUser = 0;
            Program.Nombres = "";
            lblNombres.Text = "";
            pnlLogin.Visible = true;
            lnkIniciarsesion.Text = "Iniciar Sesión";
            lnkIniciarsesion.Visible = false;
            txtUsuario.Clear();
            txtPasswaord.Clear();
            txtUsuario.Focus();

        }
        //private void iniciarSesion()
        //{
        //    if (txtUsuario.Text.Trim() != "")
        //    {
        //        if (txtPasswaord.Text.Trim() != "")
        //        {
        //            var LU = new LogUsuario();
        //            string Mensaje = "";
        //            var u = new ModelUsuario();
        //            u.Contrasena = txtPasswaord.Text;
        //            u.NomUsuario = txtUsuario.Text;
        //            Mensaje = LU.IniciarSesion(u);
        //            if (Mensaje == "1")
        //            {
        //                if (u.Estado)
        //                {
        //                    Program.IdUser = u.IdUsuario;
        //                    Program.Nombres = u.Nombres;
        //                    lblNombres.Text = u.Nombres + "(" + u.NomUsuario + ")";
        //                    lblNombres.Visible = true;
        //                    pnlLogin.Visible = false;
        //                    lnkIniciarsesion.Text = "Cerrar Sesión";
        //                    lnkIniciarsesion.Visible = true;
        //                    pnlMenu.Enabled = true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Este Usuario esta desactivado", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //                    txtUsuario.Focus();
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show(Mensaje, "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        //                txtUsuario.Clear();
        //                txtPasswaord.Clear();
        //                txtUsuario.Focus();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Por Favor Ingrese su Contraseña.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            txtPasswaord.Focus();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por Favor Ingrese Nombre de Usuario.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtUsuario.Focus();
        //    }
        //}

        private void lnkIniciarsesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Program.IdUser == 0)
            {
                pnlLogin.Visible = true;
                lnkIniciarsesion.Visible = false;
                txtUsuario.Focus();
            }
            else
            {
                if (MessageBox.Show("Estas a punto de cerrar Sesión (Si) para confirmar", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CerrarSesion();
                }
            }
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //iniciarSesion();
        }
        private void btnCerrarLogin_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            lnkIniciarsesion.Visible = true;
            txtPasswaord.Clear();
            txtUsuario.Clear();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas Seguro de cerrar?", "Confirma", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPasswaord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                //IniciarSecion();
            }
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new FCategoria(), this.pnlContenedor);
        }

        private void estructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new FEstructura(this.pnlContenedor), this.pnlContenedor);
        }

        private void maestroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new MaestroProducto(null,Evento.Nulo), this.pnlContenedor);
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new FCliente(), this.pnlContenedor);
        }

        private void calificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new FCalificacion(), this.pnlContenedor);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new FProveedor(), this.pnlContenedor);
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm.AbrirForm(new FEmpleado(), this.pnlContenedor);
        }
    }
}
