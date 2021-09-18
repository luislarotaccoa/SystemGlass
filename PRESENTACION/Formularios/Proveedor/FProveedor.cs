using LOGICA.Logica.Proveedor;
using LOGICA.Logica.Publico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using VERTICAL.Ayudas;
using VERTICAL.Modelos.Cliente;
using VERTICAL.Modelos.Proveedor;
using VERTICAL.Modelos.Publico;

namespace PRESENTACION.Formularios.Proveedor
{
    public partial class FProveedor : Plantilla
    {

        private LogProveedor LP = new LogProveedor();
        private DataTable dtUbigeo;

        private Evento eventsProveedor = Evento.Nulo;
        private Evento eventsContacto = Evento.Nulo;

        LogContacto CPL = new LogContacto();
        private ModelProveedor MProveedor;
        private ModelContacto MContacto;

        private string numero;
        public FProveedor(string _numero)
        {
            InitializeComponent();
            numero = _numero;
        }
        public FProveedor()
        {
            InitializeComponent();
        }
        public override void cerrar()
        {
            Close();
        }
        public override void titulo()
        {
            base.titulo();
        }
        public override void cargaVentana()
        {
            MProveedor = new ModelProveedor();
            CargaDocumento();
            gbDatos.Enabled = false;
            tbcDatosAdicionales.Enabled = false;
            btnDesactivar.Enabled = false;
            CargarUbigeo();
            if (numero != null)
            {
                txtNumero.Text = numero;
                txtNumero.Focus();
            }
        }
        private void CargarUbigeo()
        {
            try
            {
                var LU = new LogUbigeo();
                dtUbigeo = LU.Listar();
                DataTable dtDepart = dtUbigeo.DefaultView.ToTable(true, new string[] { "Departamento" });
                cbDepartamento.Items.Clear();
                foreach (DataRow item in dtDepart.Rows)
                {
                    cbDepartamento.Items.Add(item["Departamento"].ToString());
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void cargarProveedor(Documento doc)
        {
            try
            {
                var listProveedor = LP.Listar(null, doc);
                if (listProveedor.Count > 0)
                {
                    var source = new AutoCompleteStringCollection();
                    string[] listaruc = new string[listProveedor.Count];
                    for (int i = 0; i < listProveedor.Count; i++)
                    {
                        listaruc[i] = listProveedor[i].Numero;
                    }
                    source.AddRange(listaruc);
                    txtNumero.AutoCompleteCustomSource = source;
                }
                else
                {
                    txtNumero.AutoCompleteCustomSource.Clear();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumero.AutoCompleteCustomSource.Clear();

            }
        }
        private void CargaDocumento()
        {
            try
            {
                cbDocumento.DataSource = Enum.GetValues(typeof(Documento));
                cbDocumento.SelectedItem = Documento.RUC;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarContacto()
        {
            dgvContacto.Rows.Clear();
            txtNombresContacto.Clear();
            txtArea.Clear();
            txtEmailContacto.Clear();
            txtTelfContacto.Clear();
        }
        private void LimpiarDatos()
        {
            cbDepartamento.Text = "";
            cbProvincia.Text = "";
            cbDistrito.Text = "";
            txtDireccion.Clear();
            lblDireccion.Text = "";
            txtRazSocial.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }
        private void CargaTipoDocumento(Documento doc)
        {
            if (eventsProveedor != Evento.Modificar)
            {
                ReiniciarVentana();
            }
            if (Documento.RUC == doc)
            {
                txtNumero.MaxLength = 11;
            }
            else if (Documento.DNI == doc)
            {
                txtNumero.MaxLength = 8;
            }
            else
            {
                txtNumero.MaxLength = 20;
            }
            cargarProveedor(doc);
            txtNumero.Clear();
            txtNumero.Focus();
        }
        private void ReiniciarVentana()
        {
            LimpiarDatos();
            LimpiarContacto();
            ActDesContacto(false);
            tbcDatosAdicionales.Enabled = false;
            gbDatos.Enabled = false;
            lblTitulo.Text = "";
            btnDesactivar.Text = "";
            btnDesactivar.Enabled = false;
            btnDesactivar.BackColor = System.Drawing.Color.White;
            eventsProveedor = Evento.Nulo;
        }
        private void CargaContacto(int IdProveedor)
        {
            try
            {
                var listContactos = CPL.Listar(IdProveedor,null);
                dgvContacto.Rows.Clear();
                for (int i = 0; i < listContactos.Count; i++)
                {
                    var rw = listContactos[i];
                    dgvContacto.Rows.Add(rw.IdContacto, rw.IdProveedor, rw.Nombres, rw.Area, rw.Email, rw.Telefono,rw.Estado);
                }
                dgvContacto.Columns[ColContacto.Nombres.ToString()].Width = 150;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Grabar(Documento doc)
        {
            string mensaje;
            switch (eventsProveedor)
            {
                case Evento.Agragar:
                    if (!string.IsNullOrEmpty(txtRazSocial.Text))
                    {
                        if (MProveedor.IdUbigeo > 0)
                        {
                            if (Validaciones.ValidarDocumento(doc, txtNumero.Text))
                            {
                                MProveedor.RazonSocial = txtRazSocial.Text;
                                MProveedor.Numero = txtNumero.Text;
                                MProveedor.Direccion = txtDireccion.Text;
                                MProveedor.Email = txtEmail.Text;
                                MProveedor.Telefono = txtTelefono.Text;
                                mensaje = LP.Registrar(MProveedor);
                                if (mensaje == "1")
                                {
                                    MessageBox.Show("Proveedor registrado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cargarProveedor(MProveedor.CodDocumento);
                                    CargaProveedor(MProveedor.CodDocumento, MProveedor.Numero);
                                    tbcDatosAdicionales.Enabled = true;
                                    eventsProveedor = Evento.Nulo;
                                }
                                else
                                {
                                    MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txtNumero, "Ingrese numero válido");
                                txtNumero.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(cbDepartamento, "Seleccione Ubigeo");
                            cbDepartamento.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtRazSocial, "Tiene que ingresar razon social o nombres completos");
                        txtRazSocial.Focus();
                    }
                    break;
                case Evento.Modificar:
                    if (!string.IsNullOrEmpty(txtRazSocial.Text))
                    {
                        if (Validaciones.ValidarDocumento(doc, txtNumero.Text))
                        {
                            if (MProveedor.CodDocumento > 0)
                            {
                                if (MProveedor.IdUbigeo > 0)
                                {
                                    MProveedor.RazonSocial = txtRazSocial.Text;
                                    MProveedor.Numero = txtNumero.Text;
                                    MProveedor.Direccion = txtDireccion.Text;
                                    MProveedor.Email = txtEmail.Text;
                                    MProveedor.Telefono = txtTelefono.Text;
                                    mensaje = LP.Modificar(MProveedor);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Proveedor actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cargarProveedor(MProveedor.CodDocumento);
                                        CargaProveedor(MProveedor.CodDocumento, MProveedor.Numero);
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(cbDepartamento, "Es necesario seleccionar el distrito de la dirección");
                                    cbDepartamento.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(cbDocumento, "Tiene que seleccionar el tipo de documento");
                                cbDocumento.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtNumero, "Ingrese número correcto");
                            txtNumero.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtRazSocial, "Ingrese razon social o nombres completos");
                        txtRazSocial.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
        private void CargaProveedor(Documento doc, string numero)
        {
            if (doc > 0)
            {
                if (Validaciones.ValidarDocumento(doc, numero))
                {
                    var LP = new LogProveedor();
                    var proveedor = LP.Consulta(numero, doc);
                    gbDatos.Enabled = true;
                    if (proveedor != null)
                    {
                        MProveedor = proveedor;
                        CargaContacto(proveedor.IdProveedor);
                        ActDesDatos(false);
                        txtRazSocial.Text = proveedor.RazonSocial;
                        txtDireccion.Text = proveedor.Direccion;
                        cbDepartamento.Text = proveedor.Departamento;
                        cbProvincia.Text = proveedor.Provincia;
                        cbDistrito.Text = proveedor.Distrito;
                        txtEmail.Text = proveedor.Email;
                        txtTelefono.Text = proveedor.Telefono;
                        ProveedorActivado(proveedor.Estado);
                        btnDesactivar.Enabled = true;
                        tbcDatosAdicionales.Enabled = true;
                        btnEditar.Focus();
                    }
                    else
                    {
                        if (eventsProveedor == Evento.Nulo)
                        {
                            eventsProveedor = Evento.Agragar;
                        }
                        if (Documento.RUC == doc)
                        {
                            try
                            {
                                if (Validaciones.ValidarDocumento(Documento.RUC, txtNumero.Text))
                                {
                                    var url = "https://api.apis.net.pe/v1/ruc?numero=" + numero;
                                    WebClient wc = new WebClient();
                                    Cursor.Current = Cursors.WaitCursor;
                                    var datos = wc.DownloadString(url);
                                    Cursor.Current = Cursors.Default;
                                    var rs = JsonConvert.DeserializeObject<DatosRuc>(datos);
                                    txtRazSocial.Text = rs.nombre;
                                    txtDireccion.Text = rs.direccion;
                                    MProveedor.Numero = rs.numeroDocumento;
                                    lblEstado.Text = rs.estado + "/" + rs.condicion;
                                    cbDepartamento.Text = rs.departamento;
                                    cbProvincia.Text = rs.provincia;
                                    //MODIFICAR CODIGO UBIGEO EN LA BASE DE DATOS
                                    DataRow[] row = dtUbigeo.Select("Codigo ='" + rs.ubigeo + "'");
                                    if (row.Length > 0)
                                    {
                                        var id = row[0][0].ToString();
                                        cbDistrito.SelectedValue = Convert.ToInt32(id);
                                    }
                                    else
                                    {
                                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "Seleccione un distrito", Color.Green);
                                        cbDistrito.Focus();
                                    }
                                    //ActDesSocio(true);
                                }
                                else
                                {
                                    errorProvider1.SetError(txtNumero, "Ruc incorrecto, debe tener 11 caracteres");
                                    txtNumero.Focus();
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message + "\nIngrese los datos del proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtRazSocial.Focus();
                            }
                        }
                        //ClienteActivado(C.Estado);
                        btnDesactivar.Enabled = false;
                        ActDesDatos(true);
                        txtRazSocial.Focus();
                        //ActDesRepresentante(true);
                    }
                }
                else
                {
                    errorProvider1.SetError(txtNumero, "Ingrese numero válido");
                    txtNumero.Focus();
                }
            }
            else
            {

                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Seleccione tipo de documento", Color.Red);
                cbDocumento.Focus();
            }
        }
        private void ProveedorActivado(bool estado)
        {
            btnDesactivar.Text = estado ? "Activo" : "Desact";
            btnDesactivar.BackColor = estado ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }
        private void ActDesDatos(bool act)
        {
            cbDepartamento.Enabled = act;
            cbProvincia.Enabled = act;
            cbDistrito.Enabled = act;
            txtRazSocial.Enabled = act;
            txtDireccion.Enabled = act;
            txtTelefono.Enabled = act;
            txtEmail.Enabled = act;
            btnEditar.Enabled = !act;
            btnGuardar.Enabled = act;
        }
        private void ActDesContacto(bool act)
        {
            txtNombresContacto.Enabled = act;
            txtArea.Enabled = act;
            txtEmailContacto.Enabled = act;
            txtTelfContacto.Enabled = act;
            btnCancelarContacto.Enabled = act;
            btnGuardarContacto.Enabled = act;
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                errorProvider1.Clear();
                CargaProveedor(MProveedor.CodDocumento, txtNumero.Text);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Grabar(MProveedor.CodDocumento);
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbDepartamento.Text))
            {
                //List<Ubigeo> lista = new List<Ubigeo>();
                DataRow[] drProv = dtUbigeo.Select("Departamento ='" + cbDepartamento.Text.Trim() + "'");
                DataTable dtProv = drProv.CopyToDataTable().DefaultView.ToTable(true, new string[] { "Provincia" });
                cbProvincia.Items.Clear();
                cbProvincia.Text = "";
                cbDistrito.Text = "";
                foreach (DataRow item in dtProv.Rows)
                {
                    cbProvincia.Items.Add(item["Provincia"].ToString());
                }
                lblDireccion.Text = txtDireccion.Text + " - " + cbDepartamento.Text + " - " + cbProvincia.Text + " - " + cbDistrito.Text;
            }
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbDepartamento.Text) && !string.IsNullOrEmpty(cbProvincia.Text))
            {
                DataRow[] drDist = dtUbigeo.Select("Departamento ='" + cbDepartamento.Text.Trim() + "' and Provincia ='" + cbProvincia.Text.Trim() + "'");
                DataTable dtDist = drDist.CopyToDataTable();
                List<ModelUbigeo> lista = new List<ModelUbigeo>();
                // cbDistrito.Items.Clear();
                foreach (DataRow item in dtDist.Rows)
                {
                    lista.Add(new ModelUbigeo
                    {
                        IdUbigeo = int.Parse(item["IdUbigeo"].ToString()),
                        Departamento = item["Departamento"].ToString(),
                        Provincia = item["Provincia"].ToString(),
                        Distrito = item["Distrito"].ToString()
                    });
                }
                cbDistrito.DataSource = lista;
                cbDistrito.ValueMember = "IdUbigeo";
                cbDistrito.DisplayMember = "Distrito";
                lblDireccion.Text = txtDireccion.Text + " - " + cbDepartamento.Text + " - " + cbProvincia.Text + " - " + cbDistrito.Text;
            }
        }

        private void cbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDistrito.SelectedValue != null && int.TryParse(cbDistrito.SelectedValue.ToString(), out int i))
            {
                MProveedor.IdUbigeo = i;
                lblDireccion.Text = txtDireccion.Text + " - " + cbDepartamento.Text + " - " + cbProvincia.Text + " - " + cbDistrito.Text;
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDireccion.Text != "")
            {
                lblDireccion.Text = txtDireccion.Text + " - " + cbDepartamento.Text + " - " + cbProvincia.Text + " - " + cbDistrito.Text;
            }
        }

        private void txtRazSocial_TextChanged(object sender, EventArgs e)
        {
            if (txtRazSocial.Text != "")
            {
                lblTitulo.Text = txtRazSocial.Text.ToUpper();
                lblTitulo.Location = Centraciones.CentrarControles(lblTitulo, pnlTitulo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarVentana();
            txtNumero.Clear();
            txtNumero.Focus();
        }

        private void cbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Documento documento;
            if (cbDocumento.SelectedValue != null && Enum.TryParse<Documento>(cbDocumento.SelectedValue.ToString(), out documento))
            {
                MProveedor.CodDocumento = documento;
                //MDoc = documento;
                CargaTipoDocumento(documento);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActDesDatos(true);
            tbcDatosAdicionales.Enabled = false;
            txtRazSocial.Focus();
            eventsProveedor = Evento.Modificar;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            string accion = MProveedor.Estado ? "Desactivar" : "Activar";
            if (MessageBox.Show("Esta seguro de " + accion + " este Proveedor?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = "";
                var LC = new LogProveedor();
                mensaje = LC.Eliminar(MProveedor.IdProveedor, MProveedor.Estado);
                if (mensaje == "1")
                {
                    MessageBox.Show("Esta acava de " + accion + " este Proveedor?", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaProveedor(MProveedor.CodDocumento, MProveedor.Numero);
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MProveedor.IdProveedor > 0)
            {
                MContacto = new ModelContacto();
                ActDesContacto(true);
                MContacto.IdProveedor = MProveedor.IdProveedor;
                eventsContacto = Evento.Agragar;
                txtNombresContacto.Focus();
            }
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvContacto.SelectedRows.Count > 0)
            {
                if (dgvContacto.CurrentRow != null)
                {
                    ActDesContacto(true);
                    MContacto = new ModelContacto();
                    MContacto.IdContacto = Convert.ToInt32(dgvContacto.CurrentRow.Cells[ColContacto.IdContacto.ToString()].Value);
                    MContacto.IdProveedor = Convert.ToInt32(dgvContacto.CurrentRow.Cells[ColContacto.IdProveedor.ToString()].Value);
                    txtNombresContacto.Text = dgvContacto.CurrentRow.Cells[ColContacto.Nombres.ToString()].Value.ToString();
                    txtArea.Text = dgvContacto.CurrentRow.Cells[ColContacto.Area.ToString()].Value.ToString();
                    txtEmailContacto.Text = dgvContacto.CurrentRow.Cells["EmailContacto"].Value.ToString();
                    txtTelfContacto.Text = dgvContacto.CurrentRow.Cells[ColContacto.Telefono.ToString()].Value.ToString();
                    eventsContacto = Evento.Modificar;
                    txtNombresContacto.Focus();
                }
            }
        }
        private void GrabarContacto(Evento events)
        {
            string mensaje;
            if (!string.IsNullOrEmpty(txtNombresContacto.Text))
            {
                if (!string.IsNullOrEmpty(txtArea.Text))
                {
                    if (!string.IsNullOrEmpty(txtTelfContacto.Text))
                    {
                        switch (events)
                        {
                            case Evento.Agragar:

                                if (MContacto.IdProveedor > 0)
                                {
                                    MContacto.Nombres = txtNombresContacto.Text;
                                    MContacto.Area = txtArea.Text;
                                    MContacto.Email = txtEmailContacto.Text;
                                    MContacto.Telefono = txtTelfContacto.Text;
                                    mensaje = CPL.Registrar(MContacto);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Contacto registrado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CargaContacto(MContacto.IdProveedor);
                                        LimpiarContacto();
                                        ActDesContacto(false);
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(txtNumero, "Cargue el proveedor");
                                    txtNumero.Focus();
                                }
                                break;
                            case Evento.Modificar:
                                if (MContacto.IdContacto > 0)
                                {
                                    MContacto.Nombres = txtNombresContacto.Text;
                                    MContacto.Area = txtArea.Text;
                                    MContacto.Email = txtEmailContacto.Text;
                                    MContacto.Telefono = txtTelfContacto.Text;
                                    mensaje = CPL.Modificar(MContacto);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Proveedor actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CargaContacto(MContacto.IdProveedor);
                                        LimpiarContacto();
                                        ActDesContacto(false);
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(cbDocumento, "Tiene que seleccionar el tipo de documento");
                                    cbDocumento.Focus();
                                }

                                break;
                            default:
                                break;
                        }
                        LimpiarContacto();
                        ActDesContacto(false);
                    }
                    else
                    {
                        errorProvider1.SetError(txtTelfContacto, "Ingrese numero de telefono del contacto");
                        txtTelfContacto.Focus();
                    }
                }
                else
                {
                    errorProvider1.SetError(txtArea, "Ingrese area de trabajo del contacto");
                    txtArea.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(txtNombresContacto, "Nombres completos del contacto");
                txtNombresContacto.Focus();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvContacto.SelectedRows.Count > 0)
            {
                if (dgvContacto.CurrentRow != null)
                {
                    if (MessageBox.Show("Se eliminará la fila seleccionada", "Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int idcontacto = Convert.ToInt32(dgvContacto.CurrentRow.Cells[ColContacto.IdContacto.ToString()].Value);
                        int idproveedor = Convert.ToInt32(dgvContacto.CurrentRow.Cells[ColContacto.IdProveedor.ToString()].Value);
                        try
                        {
                            string mensaje = CPL.Eliminar(idcontacto, true);
                            if (mensaje == "1")
                            {
                                MessageBox.Show("Se elmino el contacto", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargaContacto(idproveedor);
                            }
                            else
                            {
                                MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }

        private void btnSocioGuardar_Click(object sender, EventArgs e)
        {
            GrabarContacto(eventsContacto);
        }

        private void btnCancelarContacto_Click(object sender, EventArgs e)
        {
            LimpiarContacto();
            ActDesContacto(false);
        }
    }
}
