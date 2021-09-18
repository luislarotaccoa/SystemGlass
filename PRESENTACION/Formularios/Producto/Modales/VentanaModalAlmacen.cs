using LOGICA.Logica.Producto;
using System;
using System.Windows.Forms;
using VERTICAL.Ayudas;
using VERTICAL.Modelos.Producto;

namespace PRESENTACION.Formularios.Producto.Modales
{
    public partial class VentanaModalAlmacen : Form
    {
        private DataGridViewRow drDatos;
        private Evento events;

        LogAlmacen LA = new LogAlmacen();
        ModelAlmacen MAlmacen = new ModelAlmacen();
        int posX = 0;
        int posY = 0;
        public VentanaModalAlmacen(DataGridViewRow _dr, Evento _events)
        {
            InitializeComponent();
            drDatos = _dr;
            events = _events;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(txtAlmacen.Text))
            {
                if (!string.IsNullOrEmpty(txtSerie.Text))
                {
                    MAlmacen.Nombre = txtAlmacen.Text;
                    MAlmacen.Serie = Convert.ToInt32(txtSerie.Text);
                    MAlmacen.Direccion = txtDireccion.Text;
                    Guardar();
                }
                else
                {
                    errorProvider1.SetError(txtSerie, "Este campo es obligatorio");
                    txtSerie.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(txtAlmacen, "Este campo es obligatorio");
                txtAlmacen.Focus();
            }
        }

        private void Guardar()
        {
            string m;

            switch (events)
            {
                case Evento.Nulo:
                    break;
                case Evento.Agragar:
                    m = LA.Registrar(MAlmacen);
                    if (m == "1")
                    {
                        MessageBox.Show("El Almacen se guardó correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSerie.Clear();
                        txtAlmacen.Clear();
                        txtDireccion.Clear();
                        txtSerie.Focus();
                    }
                    else
                    {
                        MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Evento.Modificar:
                    if (MAlmacen.IdAlmacen > 0)
                    {
                        m = LA.Modificar(MAlmacen);
                        if (m == "1")
                        {
                            MessageBox.Show("El Almacen se Actualizó correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MAlmacen.IdAlmacen = 0;
                            txtSerie.Clear();
                            txtAlmacen.Clear();
                            txtDireccion.Clear();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case Evento.Eliminar:
                    break;
                default:
                    break;
            }
        }

        private void VentanaModal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left += (e.X - posX);
                Top += (e.Y - posY);
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VentanaModalAlmacen_Load(object sender, EventArgs e)
        {
            Location = MousePosition;
            lblTitulo.Text = events == Evento.Modificar ? "EDITAR" : "NUEVO";
            txtSerie.Focus();
            if (events == Evento.Modificar && drDatos != null)
            {
                MAlmacen.IdAlmacen = Convert.ToInt32(drDatos.Cells[ColAlmacen.IdAlmacen.ToString()].Value);
                txtSerie.Text = drDatos.Cells[ColAlmacen.Serie.ToString()].Value.ToString();
                txtAlmacen.Text = drDatos.Cells[ColAlmacen.Nombre.ToString()].Value.ToString();
                txtDireccion.Text = drDatos.Cells[ColAlmacen.Direccion.ToString()].Value.ToString();
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                focus();
            }
        }
        private void focus()
        {
            if (txtSerie.Text != "")
            {
                if (txtAlmacen.Text != "")
                {
                    if (txtDireccion.Text != "")
                    {
                        btnGuardar.Focus();
                    }
                    else
                    {
                        txtDireccion.Focus();
                    }
                }
                else
                {
                    txtAlmacen.Focus();
                }
            }
        }
    }
}
