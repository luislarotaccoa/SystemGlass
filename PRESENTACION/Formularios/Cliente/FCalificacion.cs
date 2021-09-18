using LOGICA.Logica.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VERTICAL.Ayudas;
using VERTICAL.Modelos.Cliente;

namespace PRESENTACION.Formularios.Cliente
{
    public partial class FCalificacion : Plantilla
    {
        private ModelCalificacion MCalificacion = new ModelCalificacion();
        private LogCalificacion LC = new LogCalificacion();
        Evento events;
        private List<ModelCalificacion> list;

        public FCalificacion()
        {
            InitializeComponent();
        }
        private void Actualizar()
        {
            try
            {
                list = LC.Listar(null,null);
                dgv.DataSource = list;
                dgv.Columns["IdCalificacion"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public override void cargaVentana()
        {
            Actualizar();
        }
        public override void titulo()
        {
            lblTitulo.Text = "Calificaciones";
        }
        public override void cerrar()
        {
            Close();
        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gb.Enabled = true;
            gb.Text = "Nuevo";
            Limpiar();
            events = Evento.Agragar;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                try
                {
                    string IdCali = dgv.CurrentRow.Cells[ColCalificacion.IdCalificacion.ToString()].Value.ToString();
                    MCalificacion.IdCalificacion = int.Parse(IdCali);
                    var list = LC.Listar(null,null);
                    var calificacio = list.Find(d => d.IdCalificacion == MCalificacion.IdCalificacion);
                    txtId.Text = calificacio.IdCalificacion + "";
                    txtNota.Text = calificacio.Nota;
                    txtDescripcion.Text = calificacio.Descripcion;
                    gb.Enabled = true;
                    gb.Text = "Modificar";
                    txtNota.Focus();
                    events = Evento.Modificar;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnCancelr_Click(object sender, EventArgs e)
        {
            gb.Enabled = false;
            txtId.Clear();
            txtNota.Clear();
            txtDescripcion.Clear();
            txtNota.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!string.IsNullOrEmpty(txtNota.Text))
            {
                if (!string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MCalificacion.Nota = txtNota.Text;
                    MCalificacion.Descripcion = txtDescripcion.Text;
                    string m;
                    //Insertar
                    if (events == Evento.Agragar)
                    {
                        m = LC.Registrar(MCalificacion);
                        if (m == "1")
                        {
                            MessageBox.Show("La unidad se guardo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                            txtNota.Focus();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNota.Focus();
                        }
                    }
                    //Editar unidad
                    else if (events == Evento.Modificar)
                    {
                        m = LC.Modificar(MCalificacion);
                        if (m == "1")
                        {
                            MessageBox.Show("La unidad se Actualizo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MCalificacion.IdCalificacion = 0;
                            Limpiar();
                            dgv.Focus();
                            gb.Enabled = false;
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(txtDescripcion, "Este campo es obligatorio");
                    txtDescripcion.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(txtNota, "Este campo es obligatorio");
                txtNota.Focus();
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtNota.Clear();
            txtDescripcion.Clear();
            //txtNota.Focus();

        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgv.DataSource = LC.Buscar(list, txtBuscar.Text);
            }
            catch (Exception ex)
            {

                errorProvider1.SetError(txtBuscar, ex.Message);
            }
        }
        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                try
                {
                    string mensaje = "";
                    string accion = MCalificacion.Estado ? "Desactivar" : "Activar";
                    if (MessageBox.Show("Esta seguro de " + accion + " la fila seleccionada?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idCalificacion = Convert.ToInt32(dgv.CurrentRow.Cells[ColCalificacion.IdCalificacion.ToString()].Value);
                        bool estado = Convert.ToBoolean(dgv.CurrentRow.Cells[ColCalificacion.Estado.ToString()].Value);

                        mensaje = LC.Eliminar(idCalificacion, estado);
                        if (mensaje == "1")
                        {
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Debe Seleccionar la fila a Desactivar o Activar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void MenuMouse_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                MCalificacion.Estado = Convert.ToBoolean(dgv.CurrentRow.Cells["Estado"].Value);
                if (!MCalificacion.Estado)
                {
                    activateToolStripMenuItem.Text = "Activar";
                }
                else
                {
                    activateToolStripMenuItem.Text = "Desactivar";
                }
            }
        }
    }
}
