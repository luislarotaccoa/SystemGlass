using LOGICA.Logica.Empleado;
using LOGICA.Logica.Publico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using VERTICAL.Ayudas;
using VERTICAL.Modelos.Empleado;
using VERTICAL.Modelos.Publico;

namespace PRESENTACION.Formularios.Empleado
{
    public partial class FEmpleado : Plantilla
    {
        public FEmpleado()
        {
            InitializeComponent();
        }
        ModelEmpleado MEmpleado = new ModelEmpleado();
        LogEmpleado LE = new LogEmpleado();
        LogUbigeo UL = new LogUbigeo();
        DataTable dtUbigeo;
        private Evento eventsEmpleado = Evento.Nulo;
        public override void cargaVentana()
        {
            cargarSexo();
            Actualizar();
            CargarUbigeo();
        }
        public void Actualizar()
        {
            CargarDocumnetos();
        }
        public override void cerrar()
        {
            Close();
        }
        public override void titulo()
        {
            lblTitulo.Text = "Mantenimiento Empleado";
        }
        public void CargarDocumnetos()
        {
            try
            {
                cmbDocumento.DataSource = Enum.GetValues(typeof(Documento));
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarNumeros(string documento)
        {
            var list = LE.Listar(documento, null);
            var source = new AutoCompleteStringCollection();
            string[] listaruc = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                listaruc[i] = list[i].NumDocumento;
            }
            source.AddRange(listaruc);
            txtNumero.AutoCompleteCustomSource = source;
        }
        public bool CargarEmpleado(Documento documento, string numero)
        {
            int idEmpleado = 0;
            bool retorno = false;
            var IdEmpleado = LE.Consulta(numero, documento);
            if (IdEmpleado != null)
            {
                idEmpleado = IdEmpleado.IdEmpleado;
                var empleado = LE.Consulta(idEmpleado);

                if (empleado != null)
                {
                    MEmpleado.IdEmpleado = empleado.IdEmpleado;
                    MEmpleado.IdUbigeo = empleado.IdUbigeo;
                    txtApellidos.Text = empleado.Apellidos;
                    txtNombres.Text = empleado.Nombres;
                    cmbSexo.SelectedItem = empleado.Sexo;
                    txtFecha.Value = empleado.FechaNacimiento;
                    txtEstadoCivil.Text = empleado.EstCivil;
                    txtEspecialidad.Text = empleado.Especialidad;
                    cmbDepartamento.Text = empleado.Departamento;
                    cmbProvincia.Text = empleado.Provincia;
                    cmbDistrito.Text = empleado.Distrito;
                    lblDireccion.Text = empleado.Direccion;
                    txtDireccion.Text = empleado.Direccion;
                    txtEmail.Text = empleado.Email;
                    txtTelefono.Text = empleado.Telefono;
                    retorno= true;
                }
            }
            return retorno;
        }
        private void CargarUbigeo()
        {
            try
            {
                dtUbigeo = UL.Listar();
                DataTable dtDepart = dtUbigeo.DefaultView.ToTable(true, new string[] { "Departamento" });
                cmbDepartamento.Items.Clear();
                for (int i = 0; i < dtDepart.Rows.Count; i++)
                {
                    cmbDepartamento.Items.Add(dtDepart.Rows[i]["Departamento"].ToString());
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void Grabar()
        {
            string mensaje;
            switch (eventsEmpleado)
            {
                case Evento.Agragar:
                    if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtApellidos.Text))
                    {
                        if (!string.IsNullOrEmpty(txtNumero.Text))
                        {
                            if (!string.IsNullOrEmpty(cmbDocumento.Text))
                            {
                                if (MEmpleado.IdUbigeo > 0)
                                {
                                    MEmpleado.Apellidos = txtApellidos.Text;
                                    MEmpleado.Nombres = txtNombres.Text;
                                    MEmpleado.NumDocumento = txtNumero.Text;
                                    MEmpleado.CodDocumento = (Documento)cmbDocumento.SelectedValue;
                                    MEmpleado.Sexo = (Sexo)cmbSexo.SelectedValue;
                                    MEmpleado.FechaNacimiento = txtFecha.Value;
                                    MEmpleado.Direccion = txtDireccion.Text;
                                    MEmpleado.EstCivil = txtEstadoCivil.Text;
                                    MEmpleado.Email = txtEmail.Text;
                                    MEmpleado.Especialidad = txtEspecialidad.Text;
                                    MEmpleado.Telefono = txtTelefono.Text;
                                    mensaje = LE.Registrar(MEmpleado);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Empleado registrado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Actualizar();
                                        CargarEmpleado(MEmpleado.CodDocumento, MEmpleado.NumDocumento);
                                        gbHorario.Enabled = true;
                                        gbArea.Enabled = true;
                                        ActDesDatos(false);
                                        eventsEmpleado = Evento.Nulo;
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    errorProvider1.SetError(cmbDepartamento, "Seleccione Ubigeo");
                                    cmbDepartamento.Focus();
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(txtNumero, "Tiene que ingresar numero de documento");
                                txtNumero.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(cmbDocumento, "Tiene que ingresar tipo de documento");
                            cmbDocumento.Focus();
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtApellidos, "Tiene que ingresar Nombres Completos");
                        txtApellidos.Focus();
                    }
                    break;
                case Evento.Modificar:
                    if (!string.IsNullOrEmpty(txtApellidos.Text) && !string.IsNullOrEmpty(txtNombres.Text))
                    {

                        if (MEmpleado.IdEmpleado > 0)
                        {
                            if (MEmpleado.IdUbigeo > 0)
                            {
                                MEmpleado.Apellidos = txtApellidos.Text;
                                MEmpleado.Nombres = txtNombres.Text;
                                MEmpleado.NumDocumento = txtNumero.Text;
                                MEmpleado.CodDocumento = (Documento)cmbDocumento.SelectedValue;
                                MEmpleado.Sexo = (Sexo)cmbSexo.SelectedValue;
                                MEmpleado.FechaNacimiento = txtFecha.Value;
                                MEmpleado.Direccion = txtDireccion.Text;
                                MEmpleado.EstCivil = txtEstadoCivil.Text;
                                MEmpleado.Email = txtEmail.Text;
                                MEmpleado.Especialidad = txtEspecialidad.Text;
                                MEmpleado.Telefono = txtTelefono.Text;
                                mensaje = LE.Modificar(MEmpleado);
                                if (mensaje == "1")
                                {
                                    MessageBox.Show("Empleado actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Actualizar();
                                    CargarEmpleado(MEmpleado.CodDocumento, MEmpleado.NumDocumento);
                                    ActDesDatos(false);
                                    eventsEmpleado = Evento.Nulo;
                                }
                                else
                                {
                                    MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(cmbDepartamento, "Es necesario seleccionar el distrito de la dirección");
                                cmbDepartamento.Focus();
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtNumero, "N0 existe datos para modificar");
                            txtNumero.Focus();
                        }

                    }
                    else
                    {
                        errorProvider1.SetError(txtApellidos, "Ingrese nombres completos");
                        txtApellidos.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
        private void cargarSexo()
        {
            cmbSexo.DataSource = Enum.GetValues(typeof(Sexo));
        }
        private void CargaTipoDocumento(Documento doc)
        {

            if (eventsEmpleado != Evento.Modificar)
            {
                //ReiniciarVentana();
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
            ListarEmpleado(doc);
            txtNumero.Clear();
            txtNumero.Focus();
        }
        private void ListarEmpleado(Documento codDocumento)
        {
            try
            {
                var listCliente = LE.Listar(codDocumento, null);
                if (listCliente.Count > 0)
                {
                    var source = new AutoCompleteStringCollection();
                    string[] listaruc = new string[listCliente.Count];
                    for (int i = 0; i < listCliente.Count; i++)
                    {
                        listaruc[i] = listCliente[i].NumDocumento;
                    }
                    source.AddRange(listaruc);
                    txtNumero.AutoCompleteCustomSource = source;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumero.AutoCompleteCustomSource.Clear();
            }
        }
        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MEmpleado.CodDocumento > 0)
                {
                    if (txtNumero.Text.Length > 7)
                    {
                        if (!CargarEmpleado(MEmpleado.CodDocumento, txtNumero.Text))
                        {
                            gbDatos.Enabled = true;
                            ActDesDatos(true);
                            txtApellidos.Focus();
                            eventsEmpleado = Evento.Agragar;
                        }
                        else
                        {
                            gbDatos.Enabled = true;
                            ActDesDatos(false);
                        }
                    }
                }
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDireccion.Text != "")
            {
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDepartamento.Text))
            {
                //List<Ubigeo> lista = new List<Ubigeo>();
                DataRow[] drProv = dtUbigeo.Select("Departamento ='" + cmbDepartamento.Text.Trim() + "'");
                DataTable dtProv = drProv.CopyToDataTable().DefaultView.ToTable(true, new string[] { "Provincia" });
                cmbProvincia.Items.Clear();
                cmbProvincia.Text = "";
                cmbDistrito.Text = "";
                for (int i = 0; i < dtProv.Rows.Count; i++)
                {
                    cmbProvincia.Items.Add(dtProv.Rows[i]["Provincia"].ToString());
                }
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }

        private void cbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDepartamento.Text) && !string.IsNullOrEmpty(cmbProvincia.Text))
            {
                DataRow[] drDist = dtUbigeo.Select("Departamento ='" + cmbDepartamento.Text.Trim() + "' and Provincia ='" + cmbProvincia.Text.Trim() + "'");
                DataTable dtDist = drDist.CopyToDataTable();
                List<ModelUbigeo> lista = new List<ModelUbigeo>();
                // cbDistrito.Items.Clear();
                for (int i = 0; i < dtDist.Rows.Count; i++)
                {
                    lista.Add(new ModelUbigeo
                    {
                        IdUbigeo = int.Parse(dtDist.Rows[i][ColUbigeo.IdUbigeo.ToString()].ToString()),
                        Departamento = dtDist.Rows[i][ColUbigeo.Departamento.ToString()].ToString(),
                        Provincia = dtDist.Rows[i][ColUbigeo.Provincia.ToString()].ToString(),
                        Distrito = dtDist.Rows[i][ColUbigeo.Distrito.ToString()].ToString()
                    });
                }
                foreach (DataRow item in dtDist.Rows)
                {

                }
                cmbDistrito.DataSource = lista;
                cmbDistrito.ValueMember = "IdUbigeo";
                cmbDistrito.DisplayMember = "Distrito";
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }

        private void cbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrito.SelectedValue != null && int.TryParse(cmbDistrito.SelectedValue.ToString(), out int i))
            {
                MEmpleado.IdUbigeo = i;
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }
        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Documento documento;
            if (cmbDocumento.SelectedValue != null && Enum.TryParse<Documento>(cmbDocumento.SelectedValue.ToString(), out documento))
            {
                MEmpleado.CodDocumento = documento;
                //MDoc = documento;
                CargaTipoDocumento(documento);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActDesDatos(true);
            gbArea.Enabled = false;
            gbHorario.Enabled = false;
            txtApellidos.Focus();
            eventsEmpleado = Evento.Modificar;
        }
        private void ActDesDatos(bool act)
        {
            cmbDepartamento.Enabled = act;
            cmbProvincia.Enabled = act;
            cmbDistrito.Enabled = act;
            txtApellidos.Enabled = act;
            txtNombres.Enabled = act;
            txtDireccion.Enabled = act;
            txtFecha.Enabled = act;
            cmbSexo.Enabled = act;
            txtTelefono.Enabled = act;
            txtEspecialidad.Enabled = act;
            txtEstadoCivil.Enabled = act;
            txtEmail.Enabled = act;
            btnEditar.Enabled = !act;
            btnGuardar.Enabled = act;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            ActDesDatos(false);
            btnEditar.Enabled = false;
            gbDatos.Enabled = true;
            txtNumero.Clear();
            txtNumero.Focus();
        }
        private void LimpiarDatos()
        {
            MEmpleado.IdEmpleado = 0;
            MEmpleado.IdUbigeo = 0;
            cmbDepartamento.Text = "";
            cmbProvincia.Text = "";
            cmbDistrito.Text = "";
            txtDireccion.Clear();
            lblDireccion.Text = "";
            txtApellidos.Clear();
            txtNombres.Clear();
            txtTelefono.Clear();
            txtEstadoCivil.Clear();
            txtEspecialidad.Clear();
            txtEmail.Clear();
        }
    }
}
