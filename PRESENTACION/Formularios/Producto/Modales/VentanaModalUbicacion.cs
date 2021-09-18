using LOGICA.Logica.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VERTICAL.Ayudas;
using VERTICAL.Modelos.Producto;

namespace PRESENTACION.Formularios.Producto.Modales
{
    public partial class VentanaModalUbicacion : Form
    {
        private DataGridViewRow drDatos;
        private Evento events;

        LogUbicacion LU = new LogUbicacion();
        ModelUbicacion MUbicacion = new ModelUbicacion();
        int posX = 0;
        int posY = 0;
        private List<ModelUbicacion> list;

        public VentanaModalUbicacion(DataGridViewRow _dr, Evento _events)
        {
            InitializeComponent();
            drDatos = _dr;
            events = _events;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(txtUbicacion.Text))
            {
                MUbicacion.NomUbicacion = txtUbicacion.Text;
                Guardar();

            }
            else
            {
                errorProvider1.SetError(txtUbicacion, "Este campo es obligatorio");
                txtUbicacion.Focus();
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

                    //Si existe Ubicacion pero aun no esta asociado
                    //=> Asignar el IdUbicacion a un almacen
                    if (MUbicacion.IdUbicacion > 0)
                    {
                        var mUbicacion = new ModelUbicacion();
                        mUbicacion.IdAlmacen = Convert.ToInt32(drDatos.Cells["IdAlmacen"].Value);
                        mUbicacion.IdUbicacion = MUbicacion.IdUbicacion;
                        m = LU.RegistrarCombinacion(mUbicacion);
                        if (m == "1")
                        {
                            MessageBox.Show("La ubicacion se guardo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUbicacion.Clear();
                            txtUbicacion.Focus();
                        }
                        else
                        {
                            MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    //Si no existe Ubicacion y se escribe nueva Ubicacion
                    //Primero Registrar Ubicacion, luego asociar
                    else
                    {
                        m = LU.Registrar(MUbicacion);
                        if (m == "1")
                        {
                            var mUbicacion = new ModelUbicacion();
                            mUbicacion.IdAlmacen = Convert.ToInt32(drDatos.Cells["IdAlmacen"].Value);
                            mUbicacion.IdUbicacion = MUbicacion.IdUbicacion;
                            m = LU.RegistrarCombinacion(mUbicacion);
                            if (m == "1")
                            {
                                MessageBox.Show("La ubicacion se guardo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUbicacion.Clear();
                                txtUbicacion.Focus();
                            }
                            else
                            {
                                MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case Evento.Modificar:
                    if (MUbicacion.IdUbicacion > 0)
                    {
                        m = LU.Modificar(MUbicacion);
                        if (m == "1")
                        {
                            MessageBox.Show("La ubicacion se Actualizo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MUbicacion.IdUbicacion = 0;
                            txtUbicacion.Clear();
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

        private void VentanaModalUnidad_Load(object sender, EventArgs e)
        {
            Location = MousePosition;
            lblTitulo.Text = events == Evento.Modificar ? "EDITAR" : "NUEVO";
            if (events == Evento.Modificar && drDatos != null)
            {
                MUbicacion.IdUbicacion = Convert.ToInt32(drDatos.Cells[ColUbicacion.IdUbicacion.ToString()].Value.ToString());
                txtUbicacion.Text = drDatos.Cells[ColUbicacion.NomUbicacion.ToString()].Value.ToString();
                txtUbicacion.AutoCompleteMode = AutoCompleteMode.None;
                txtUbicacion.AutoCompleteSource = AutoCompleteSource.None;
            }
            else
            {
                txtUbicacion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtUbicacion.AutoCompleteSource = AutoCompleteSource.CustomSource;
                CargarAutoCompleteUbicacion();
            }
        }
        private void CargarAutoCompleteUbicacion()
        {
            try
            {
                list = LU.Listar(null,null);
                var source = new AutoCompleteStringCollection();
                string[] lista = new string[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    lista[i] = list[i].NomUbicacion;
                }
                source.AddRange(lista);
                txtUbicacion.AutoCompleteCustomSource = source;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtUbicacion_Leave(object sender, EventArgs e)
        {
            if (events == Evento.Agragar)
            {
                if (!string.IsNullOrEmpty(txtUbicacion.Text))
                {
                    var ub = list.Where(d => d.NomUbicacion.Trim().ToLower() == txtUbicacion.Text.Trim().ToLower()).FirstOrDefault();
                    if (ub != null)
                    {
                        MUbicacion.IdUbicacion = ub.IdUbicacion;
                    }
                    else
                    {
                        MUbicacion.IdUbicacion = 0;
                    }
                }
            }
        }

        private void txtUbicacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUbicacion.Text))
                {
                    btnGuardar.Focus();
                }
            }
        }
    }
}
