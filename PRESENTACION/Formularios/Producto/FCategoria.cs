using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VERTICAL.Modelos.Producto;
using VERTICAL.Ayudas;
using LOGICA.Logica.Producto;

namespace PRESENTACION.Formularios.Producto
{
    public partial class FCategoria : Plantilla
    {
        public FCategoria()
        {
            InitializeComponent();
            btnRestore.Visible = false;
            btnMinimized.Visible = false;
        }
        LogCategoria LC = new LogCategoria();

        private Evento events = Evento.Nulo;
        private List<ModelCategoria> listCategoria;
        private ModelCategoria MCategoria;

        public override void cargaVentana()
        {
            MCategoria = new ModelCategoria();
            Actualizar();
        }
        public override void titulo()
        {
            lblTitulo.Text = "Categorias";
        }
        public override void cerrar()
        {
            this.Close();
        }

        private void Actualizar()
        {
            try
            {
                listCategoria = LC.Listar(null, null);
                dgv.DataSource = listCategoria;
                dgv.Columns[ColCategoria.IdCategoria.ToString()].HeaderText = "ID";
                dgv.Columns[ColCategoria.IdCategoria.ToString()].Width = 30;
                dgv.Columns[ColCategoria.NomCategoria.ToString()].Width = 180;
                dgv.Columns[ColCategoria.NomCategoria.ToString()].HeaderText = "Categoría";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gb.Enabled = true;
            txtId.Clear();
            txtCategoria.Clear();
            txtCategoria.Focus();
            events = Evento.Agragar;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                try
                {
                    int idCategoria = Convert.ToInt32(dgv.CurrentRow.Cells[ColCategoria.IdCategoria.ToString()].Value);
                    MCategoria = listCategoria.Find(d => d.IdCategoria == idCategoria);
                    txtId.Text = MCategoria.IdCategoria + "";
                    txtCategoria.Text = MCategoria.NomCategoria;
                    chBilateral.Checked = MCategoria.Bilateral;
                    gb.Enabled = true;
                    txtCategoria.Focus();
                    events = Evento.Modificar;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void desactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                try
                {
                    string accion = MCategoria.Estado ? "Desactivar" : "Activar";
                    if (MessageBox.Show("Esta seguro de " + accion + " la fila seleccionada?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string IdCategoria = dgv.CurrentRow.Cells["IdCategoria"].Value.ToString();
                        bool estado = Convert.ToBoolean(dgv.CurrentRow.Cells["Estado"].Value);

                        MCategoria.Estado = estado;
                        MCategoria.IdCategoria = int.Parse(IdCategoria);
                        events = Evento.Eliminar;
                        Guardar();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Debe Seleccionar la fila a Desactivar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnCancelr_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            gb.Enabled = false;
            txtId.Clear();
            txtCategoria.Clear();
            chBilateral.Checked = false;
            events = Evento.Nulo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoria.Text))
            {
                MCategoria.NomCategoria = txtCategoria.Text;
                MCategoria.Bilateral = chBilateral.Checked;
                Guardar();

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
                    m = LC.Registrar(MCategoria);
                    if (m == "1")
                    {
                        LabelMessage.Mensaje(timer1, lblError, "BD","La categoria se guardo correctamente", Color.Green);
                        txtCategoria.Clear();
                        chBilateral.Checked = false;
                        txtCategoria.Focus();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Evento.Modificar:
                    if (MCategoria.IdCategoria > 0)
                    {
                        m = LC.Modificar(MCategoria);
                        if (m == "1")
                        {
                            LabelMessage.Mensaje(timer1, lblError, "BD", "La categoria se guardo correctamente", Color.Green); 
                            Cancelar();
                            Actualizar();
                        }
                        else
                        {
                            MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case Evento.Eliminar:
                    if (MCategoria.IdCategoria > 0)
                    {
                        m = LC.Eliminar(MCategoria.IdCategoria, !MCategoria.Estado);
                        if (m == "1")
                        {
                            string accion = MCategoria.Estado ? "desactivó" : "activó";
                            MessageBox.Show("La fila seleccionada se " + accion + " correctamente", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Actualizar();
                        }
                    }
                    break;

            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dgv.DataSource = LC.Buscar(listCategoria, txtBuscar.Text);
        }

        private void MenuMouse_Opening(object sender, CancelEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                try
                {
                    bool estado = Convert.ToBoolean(dgv.CurrentRow.Cells["Estado"].Value);
                    if (!estado)
                    {
                        desactivarToolStripMenuItem.Text = "Activar";
                    }
                    else
                    {
                        desactivarToolStripMenuItem.Text = "Desactivar";
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        private void chBilateral_CheckedChanged(object sender, EventArgs e)
        {
            chBilateral.Text = chBilateral.Checked ? "True" : "False";
        }

        private void txtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCategoria.Text != "")
                {
                    btnGuardar.Focus();
                }
            }
        }

    }
}
