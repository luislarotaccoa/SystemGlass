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
    public partial class FEstructura : Plantilla
    {
        public FEstructura()
        {
            InitializeComponent();
        }
        private Panel pnlContainer;
        public FEstructura(Panel _pnl)
        {
            InitializeComponent();
            pnlContainer = _pnl;
        }
        ModelCategoria MCategoria = new ModelCategoria();
        LogCategoria LC = new LogCategoria();

        ModelProducto MProducto = new ModelProducto();
        LogProducto LP = new LogProducto();

        ModelColor MColor = new ModelColor();
        LogColorCategoria LCC = new LogColorCategoria();

        ModelFamilia FModel = new ModelFamilia();
        LogFamilia LF = new LogFamilia();

        LogDescrip1 LD1 = new LogDescrip1();

        ModelDescrip2 MDescrip2 = new ModelDescrip2();
        LogDescrip2Categoria LCD2 = new LogDescrip2Categoria();

        internal static DataRow dr;
        // private DataTable dt;
        public static int idFamilia = 0, idCategoria = 0, idDescrip1 = 0;
        public static string nomCategoria, nomFamilia;
        public static bool Editar = false;
        private Evento events = Evento.Nulo;
        private DataGridView DataGridViewClic;

        
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
            lblTitulo.Text = "ESTRUCTURA";
        }
        private void Actualizar()
        {

            CargaCategoria();
        }
        private void CargaCategoria()
        {
            try
            {
                var listCategoria = LC.Listar(null, null);
                dgvCategoria.DataSource = listCategoria;
                dgvCategoria.Columns[ColCategoria.IdCategoria.ToString()].HeaderText = "ID";
                dgvCategoria.Columns[ColCategoria.IdCategoria.ToString()].Width = 30;
                dgvCategoria.Columns[ColCategoria.Estado.ToString()].Visible = false;
                dgvCategoria.Columns[ColCategoria.NomCategoria.ToString()].HeaderText = "CATEGORIA";
                dgvCategoria.Columns[ColCategoria.NomCategoria.ToString()].Width = 170;
                dgvCategoria.Columns[ColCategoria.Bilateral.ToString()].HeaderText = "BILATERAL";
            }
            //NullReferenceException
            catch (NullReferenceException)
            {

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargaFamilia(int idCat)
        {

            //try
            //{
            var listFamilia = LF.Listar(idCat);
            dgvFamilia.DataSource = listFamilia;
            dgvFamilia.Columns[ColFamilia.IdFamilia.ToString()].HeaderText = "ID";
            dgvFamilia.Columns[ColFamilia.NomFamilia.ToString()].HeaderText = "FAMILIA";
            dgvFamilia.Columns[ColFamilia.IdFamilia.ToString()].Width = 30;
            //dgvFamilia.Columns[ColFamilia.NomFamilia].Width = 200;
            dgvFamilia.Columns[ColFamilia.IdCategoria.ToString()].Visible = false;
            dgvFamilia.Columns[ColFamilia.Estado.ToString()].Visible = false;
            dgvFamilia.Columns[ColCategoria.NomCategoria.ToString()].Visible = false;

            //}
            //catch (InvalidOperationException)
            //{

            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        private void CargaColor(int idCat)
        {
            //try
            //{
            var listColor = LCC.Listar(idCat);
            dgvColor.DataSource = listColor;
            dgvColor.Columns[ColColor.IdColor.ToString()].Width = 30;
            dgvColor.Columns[ColColor.IdColor.ToString()].HeaderText = "ID";
            dgvColor.Columns[ColColor.NomColor.ToString()].HeaderText = "COLOR";
            dgvColor.Columns[ColColor.IdCategoria.ToString()].Visible = false;
            dgvColor.Columns[ColCategoria.NomCategoria.ToString()].Visible = false;
            dgvColor.Columns[ColCategoria.Bilateral.ToString()].Visible = false;
            dgvColor.Columns[ColCategoria.Estado.ToString()].Visible = false;
            //}
            //catch (InvalidOperationException)
            //{

            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void CargaDescrip1(int idFamilia)
        {
            //try
            //{
            var listD1 = LD1.Listar(idFamilia);
            dgvDescripcion1.DataSource = listD1;
            dgvDescripcion1.Columns[ColDescrip1.IdDescrip1.ToString()].HeaderText = "ID";
            dgvDescripcion1.Columns[ColDescrip1.Descripcion.ToString()].HeaderText = "DESCRIPCIÓN 1";
            dgvDescripcion1.Columns[ColDescrip1.IdDescrip1.ToString()].Width = 30;
            //dgvDescripcion1.Columns[ColDescrip1.Descripcion].Width = 200;
            dgvDescripcion1.Columns[ColDescrip1.IdFamilia.ToString()].Visible = false;
            //dgvDescripcion1.Columns[ColDescrip1.IdDescrip1].Visible = false;
            dgvDescripcion1.Columns[ColDescrip1.Estado.ToString()].Visible = false;
            dgvDescripcion1.Columns[ColFamilia.NomFamilia.ToString()].Visible = false;
            //}
            //catch (InvalidOperationException)
            //{

            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void CargaDescrip2(int idCat)
        {
            //try
            //{
            var listD2 = LCD2.Listar(idCat);
            dgvDescripcion2.DataSource = listD2;
            dgvDescripcion2.Columns[ColDescrip2.IdDescrip2.ToString()].Width = 30;
            dgvDescripcion2.Columns[ColDescrip2.IdDescrip2.ToString()].HeaderText = "ID";
            dgvDescripcion2.Columns[ColDescrip2.Descripcion.ToString()].HeaderText = "DESCRIPCIÓN 2";
            dgvDescripcion2.Columns[ColDescrip2.IdCategoria.ToString()].Visible = false;
            dgvDescripcion2.Columns[ColCategoria.NomCategoria.ToString()].Visible = false;
            dgvDescripcion2.Columns[ColCategoria.Bilateral.ToString()].Visible = false;
            dgvDescripcion2.Columns[ColCategoria.Estado.ToString()].Visible = false;
            //}
            //catch (InvalidOperationException)
            //{

            //}
            //catch (Exception e)
            //{

            //    MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void DgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                string IdCateria = dgvCategoria.CurrentRow.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString();
                MCategoria.IdCategoria = int.Parse(IdCateria);
                CargaFamilia(MCategoria.IdCategoria);
                CargaDescrip2(MCategoria.IdCategoria);
                CargaColor(MCategoria.IdCategoria);
            }
        }
        private void DgvFamilia_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFamilia.SelectedRows.Count > 0)
            {
                string IdFamilia = dgvFamilia.CurrentRow.Cells[ColFamilia.IdFamilia.ToString()].Value.ToString();
                FModel.IdFamilia = int.Parse(IdFamilia);
                CargaDescrip1(FModel.IdFamilia);
            }
            else
            {
                CargaDescrip1(0);
            }
        }
        private void dgvDescrip1_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDescripcion1.SelectedRows.Count > 0)
            {
                txtCodigo.Text = Codigo();
            }
        }
        private void dgvDescrip2_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDescripcion2.SelectedRows.Count > 0)
            {
                txtCodigo.Text = Codigo();
            }
        }
        private void dgvColor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvColor.SelectedRows.Count > 0)
            {
                txtCodigo.Text = Codigo();
            }

        }

        private void ActualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridViewClic == dgvCategoria)
            {
                VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, null, null, Evento.Agragar);
                vm.Width = DataGridViewClic.Width;
                vm.ShowDialog();
                CargaCategoria();
            }

            else if (DataGridViewClic == dgvFamilia)
            {
                if (dgvCategoria.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dRalacion = dgvCategoria.CurrentRow;
                        MCategoria.IdCategoria = Convert.ToInt32(dRalacion.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, null, dRalacion, Evento.Agragar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaFamilia(MCategoria.IdCategoria);
                        MCategoria.IdCategoria = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila a una CATEGORIA", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (DataGridViewClic == dgvDescripcion1)
            {
                if (dgvFamilia.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dRelacion = dgvFamilia.CurrentRow;
                        FModel.IdFamilia = Convert.ToInt32(dRelacion.Cells[ColFamilia.IdFamilia.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, null, dRelacion, Evento.Agragar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaDescrip1(FModel.IdFamilia);
                        FModel.IdFamilia = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila de una FAMILIA.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (DataGridViewClic == dgvDescripcion2)
            {
                if (dgvCategoria.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dRelacion = dgvCategoria.CurrentRow;
                        MCategoria.IdCategoria = Convert.ToInt32(dRelacion.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, null, dRelacion, Evento.Agragar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaDescrip2(MCategoria.IdCategoria);
                        MCategoria.IdCategoria = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila de una CATEGORIA.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (DataGridViewClic == dgvColor)
            {
                if (dgvCategoria.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dRelacion = dgvCategoria.CurrentRow;
                        MCategoria.IdCategoria = Convert.ToInt32(dRelacion.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, null, dRelacion, Evento.Agragar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaColor(MCategoria.IdCategoria);
                        MCategoria.IdCategoria = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila de una CATEGORIA.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void EditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridViewClic == dgvCategoria)
            {
                if (dgvCategoria.SelectedRows.Count > 0)
                {
                    DataGridViewRow dDatos = dgvCategoria.CurrentRow;
                    VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, dDatos, null, Evento.Modificar);
                    vm.Width = DataGridViewClic.Width;
                    vm.ShowDialog();
                    CargaCategoria();
                }
            }

            else if (DataGridViewClic == dgvFamilia)
            {
                if (dgvFamilia.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dDatos = dgvFamilia.CurrentRow;
                        MCategoria.IdCategoria = Convert.ToInt32(dDatos.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, dDatos, null, Evento.Modificar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaFamilia(MCategoria.IdCategoria);
                        MCategoria.IdCategoria = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (DataGridViewClic == dgvDescripcion1)
            {
                if (dgvDescripcion1.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dDatos = dgvDescripcion1.CurrentRow;
                        FModel.IdFamilia = Convert.ToInt32(dDatos.Cells[ColFamilia.IdFamilia.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, dDatos, null, Evento.Modificar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaDescrip1(FModel.IdFamilia);
                        FModel.IdFamilia = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (DataGridViewClic == dgvDescripcion2)
            {
                if (dgvDescripcion2.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dDatos = dgvDescripcion2.CurrentRow;
                        MDescrip2.IdCategoria = Convert.ToInt32(dDatos.Cells[ColDescrip2.IdCategoria.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, dDatos, null, Evento.Modificar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaDescrip2(MDescrip2.IdCategoria);
                        MDescrip2.IdCategoria = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (DataGridViewClic == dgvColor)
            {
                if (dgvColor.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dDatos = dgvColor.CurrentRow;
                        MColor.IdCategoria = Convert.ToInt32(dDatos.Cells[ColColor.IdCategoria.ToString()].Value.ToString());
                        VentanaModalProducto vm = new VentanaModalProducto(DataGridViewClic.Name, dDatos, null, Evento.Modificar);
                        vm.Width = DataGridViewClic.Width;
                        vm.ShowDialog();
                        CargaColor(MColor.IdCategoria);
                        MColor.IdCategoria = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewClic = ((DataGridView)sender);
                MenuMouse.Show(MousePosition);
            }
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
           OpenForm.AbrirForm(new MaestroProducto(MProducto, events), pnlContainer);
        }
        private string Codigo()
        {
            string CODIGO = "";
            int SERIE1 = 0, SERIE2 = 0, SERIE3 = 0;

            //SERIE 1
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                SERIE1 = Convert.ToInt32(dgvCategoria.CurrentRow.Cells[ColCategoria.IdCategoria.ToString()].Value);
                MProducto.IdCategoria = SERIE1;
            }

            //SERIE 2
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                if (dgvDescripcion1.SelectedRows.Count > 0 && dgvDescripcion1.CurrentRow != null)
                {
                    if (dgvDescripcion2.SelectedRows.Count > 0 && dgvDescripcion2.CurrentRow != null)
                    {
                        if (dgvColor.SelectedRows.Count > 0 && dgvColor.CurrentRow != null)
                        {
                            MProducto.IdCategoria = (int)dgvCategoria.CurrentRow.Cells[ColCategoria.IdCategoria.ToString()].Value;
                            MProducto.Bilateral = Convert.ToBoolean(dgvCategoria.CurrentRow.Cells[ColCategoria.Bilateral.ToString()].Value);
                            MProducto.Categoria = dgvCategoria.CurrentRow.Cells[ColCategoria.NomCategoria.ToString()].Value.ToString();
                            MProducto.Familia = dgvFamilia.CurrentRow.Cells[ColFamilia.NomFamilia.ToString()].Value.ToString();
                            MProducto.IdDescrip1 = (int)dgvDescripcion1.CurrentRow.Cells[ColDescrip1.IdDescrip1.ToString()].Value;
                            MProducto.Descripcion1 = dgvDescripcion1.CurrentRow.Cells[ColDescrip1.Descripcion.ToString()].Value.ToString();
                            MProducto.IdDescrip2 = (int)dgvDescripcion2.CurrentRow.Cells[ColDescrip2.IdDescrip2.ToString()].Value;
                            MProducto.Descripcion2 = dgvDescripcion2.CurrentRow.Cells[ColDescrip2.Descripcion.ToString()].Value.ToString();
                            MProducto.IdColor = (int)dgvColor.CurrentRow.Cells[ColColor.IdColor.ToString()].Value;
                            MProducto.Color = dgvColor.CurrentRow.Cells[ColColor.NomColor.ToString()].Value.ToString();
                            lblDescripcion.Text = MProducto.Descripcion;
                            if (LP.Existe(MProducto))
                            {
                                lblDescripcion.ForeColor = Color.Green;
                                btnCrear.Text = "Editar";
                                btnCrear.BackColor = Color.Orange;
                                SERIE1 = Convert.ToInt32(dgvCategoria.CurrentRow.Cells[ColCategoria.IdCategoria.ToString()].Value);
                                SERIE2 = MProducto.Serie2;
                                SERIE3 = Convert.ToInt32(dgvColor.CurrentRow.Cells[ColColor.IdColor.ToString()].Value);
                                CODIGO = Concatenacion.ConcatSerie(SERIE1, SERIE2, SERIE3);
                                events = Evento.Modificar;
                                return CODIGO;
                            }
                            else
                            {
                                SERIE2 = MProducto.Serie2;
                                btnCrear.Text = "Crear";
                                btnCrear.BackColor = Color.Green;
                                lblDescripcion.ForeColor = Color.Red;
                                events = Evento.Agragar;
                            }
                        }
                        else
                        {
                            lblDescripcion.Text = "";
                        }
                    }
                    else
                    {
                        lblDescripcion.Text = "";

                    }
                }
                else
                {
                    //lblDescripcion.Text = Concatenacion.ConcatDescripcion("", dgvDescripcion2.CurrentRow.Cells[ColDescrip2.Descripcion.ToString()].Value.ToString(), dgvColor.CurrentRow.Cells[ColColor.NomColor.ToString()].Value.ToString(), Convert.ToBoolean(dgvCategoria.CurrentRow.Cells[ColCategoria.Bilateral.ToString()].Value));
                    lblDescripcion.Text = "";
                }
            }
            //SERIE 3
            if (dgvColor.SelectedRows.Count > 0 && dgvColor.CurrentRow != null)
            {
                SERIE3 = Convert.ToInt32(dgvColor.CurrentRow.Cells[ColColor.IdColor.ToString()].Value);
            }
            CODIGO = Concatenacion.ConcatSerie(SERIE1, SERIE2, SERIE3);
            return CODIGO;

        }
    }
}
