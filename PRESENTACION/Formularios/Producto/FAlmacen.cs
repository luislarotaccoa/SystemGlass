using LOGICA.Logica.Producto;
using PRESENTACION.Formularios.Producto.Modales;
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
using VERTICAL.Modelos.Producto;

namespace PRESENTACION.Formularios.Producto
{
    public partial class FAlmacen : Plantilla
    {
        ModelAlmacen AModel = new ModelAlmacen();
        LogAlmacen LA = new LogAlmacen();
        private List<ModelAlmacen> listAlmacen;

        public FAlmacen()
        {
            InitializeComponent();
        }
        private void Actualizar()
        {
            try
            {
                listAlmacen = LA.Listar(null, null);
                dgvAlmacen.DataSource = listAlmacen;
                dgvAlmacen.Columns[ColAlmacen.IdAlmacen.ToString()].Visible = false;
                dgvAlmacen.Columns[ColAlmacen.Serie.ToString()].Width = 50;
                dgvAlmacen.Columns[ColAlmacen.Nombre.ToString()].HeaderText = "Almacen";
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
        public override void cerrar()
        {
            this.Close();
        }
        public override void titulo()
        {
            lblTitulo.Text = "Almacenes";
        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaModalAlmacen vm = new VentanaModalAlmacen(null, Evento.Agragar);
            vm.ShowDialog();
            Actualizar();
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAlmacen.SelectedRows.Count > 0)
            {
                DataGridViewRow dDatos = dgvAlmacen.CurrentRow;
                VentanaModalAlmacen vm = new VentanaModalAlmacen(dDatos, Evento.Modificar);
                vm.ShowDialog();
                Actualizar();
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
            if (dgvAlmacen.SelectedRows.Count > 0)
            {
                try
                {
                    string mensaje = "";
                    string accion = AModel.Estado ? "Desactivar" : "Activar";
                    if (MessageBox.Show("Esta seguro de " + accion + " la fila seleccionada?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string IdAlmacen = dgvAlmacen.CurrentRow.Cells["IdAlmacen"].Value.ToString();
                        bool estado = Convert.ToBoolean(dgvAlmacen.CurrentRow.Cells["Estado"].Value);

                        AModel.Estado = estado;
                        AModel.IdAlmacen = int.Parse(IdAlmacen);
                        mensaje = LA.Eliminar(AModel.IdAlmacen, AModel.Estado);
                        if (mensaje == "1")
                        {
                            Actualizar();
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
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void MenuAlmacen_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAlmacen.SelectedRows.Count > 0)
            {
                bool estado = Convert.ToBoolean(dgvAlmacen.CurrentRow.Cells["Estado"].Value);
                if (!estado)
                {
                    desactivarToolStripMenuItem.Text = "Activar";
                }
                else
                {
                    desactivarToolStripMenuItem.Text = "Desactivar";
                }
            }
        }
        private void dgvAlmacen_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void CargarUbicacion(int idAlmacen)
        {
            var LU = new LogUbicacion();
            dgvUbicacion.DataSource = LU.Listar(idAlmacen);
            dgvUbicacion.Columns[ColUbicacion.Estado.ToString()].Visible = false;
            dgvUbicacion.Columns[ColUbicacion.IdAlmacen.ToString()].Visible = false;
            dgvUbicacion.Columns[ColUbicacion.Serie.ToString()].Visible = false;
            dgvUbicacion.Columns[ColUbicacion.Nombre.ToString()].Visible = false;
            dgvUbicacion.Columns[ColUbicacion.Direccion.ToString()].Visible = false;
            dgvUbicacion.Columns[ColUbicacion.IdUbicacion.ToString()].HeaderText = "ID";
            dgvUbicacion.Columns[ColUbicacion.IdUbicacion.ToString()].Width = 30;
            dgvUbicacion.Columns[ColUbicacion.NomUbicacion.ToString()].HeaderText = "Ubicaion";
        }
        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvAlmacen.SelectedRows.Count > 0)
            {
                DataGridViewRow dDatos = dgvAlmacen.CurrentRow;
                VentanaModalUbicacion vm = new VentanaModalUbicacion(dDatos, Evento.Agragar);
                vm.ShowDialog();
                CargarUbicacion(AModel.IdAlmacen);
            }
        }
        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvUbicacion.SelectedRows.Count > 0)
            {
                DataGridViewRow dDatos = dgvUbicacion.CurrentRow;
                VentanaModalUbicacion vm = new VentanaModalUbicacion(dDatos, Evento.Modificar);
                vm.ShowDialog();
                CargarUbicacion(AModel.IdAlmacen);
            }
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAlmacen.SelectedRows.Count > 0)
            {
                try
                {
                    string almacen = dgvAlmacen.CurrentRow.Cells[ColAlmacen.Nombre.ToString()].Value.ToString();
                    string ubicacion = dgvUbicacion.CurrentRow.Cells[ColUbicacion.NomUbicacion.ToString()].Value.ToString();

                    if (MessageBox.Show("Se Eliminará la Ubicacion: " + ubicacion + " del Almacen: " + almacen, "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idAlmacen = Convert.ToInt32(dgvUbicacion.CurrentRow.Cells[ColUbicacion.IdAlmacen.ToString()].Value);
                        int idUbicacion = Convert.ToInt32(dgvUbicacion.CurrentRow.Cells[ColUbicacion.IdUbicacion.ToString()].Value);
                        var LU = new LogUbicacion();
                        string mensaje = LU.Eliminar(idAlmacen, idUbicacion);
                        if (mensaje == "1")
                        {
                            CargarUbicacion(idAlmacen);
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

        }
        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CargarUbicacion(AModel.IdAlmacen);
        }
    }
}

