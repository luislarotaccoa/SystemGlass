using LOGICA.Logica.Cliente;
using LOGICA.Logica.Publico;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PRESENTACION.Exportar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using VERTICAL.Ayudas;
using VERTICAL.Modelos.Cliente;
using VERTICAL.Modelos.Publico;

namespace PRESENTACION.Formularios.Cliente
{
    public partial class FCliente : Plantilla
    {
        public FCliente()
        {
            InitializeComponent();
        }
        private const string pathReport = @"..\..\Forms\Clientes\Reportes\ReporteDeuda.rdlc";
        LogCliente LC = new LogCliente();
        ModelCliente MCliente = new ModelCliente();
        ModelLineaCredito MLCredito = new ModelLineaCredito();
        ModelSocioCliente MSocio = new ModelSocioCliente();
        LogSocioCliente LSC = new LogSocioCliente();
        LogDireccion LD = new LogDireccion();
        ModelDireccion DCModel = new ModelDireccion();
        LogLineaCredito LLC = new LogLineaCredito();
        //private List<Documento> lisDodumento1;
        private List<ModelCalificacion> lisCalificacion;
        //private Documento MDoc;
        private Documento MDocSocio;
        private Evento eventsCredito;
        private DataTable dtUbigeo;
        private Evento eventsDireccion;
        private List<ModelSocioCliente> listClienteSocio;
        private List<ModelDireccion> listDireccionCliente;
        private List<ModelCobranza> listDeudas;

        private Evento eventsCliente = Evento.Nulo;

        private Evento eventsSocio = Evento.Nulo;

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
            CargaDocumento();
            gbDatos.Enabled = false;
            tbcCredito.Enabled = false;
            tbcDatosAdicionales.Enabled = false;
            cmbDocumento.Focus();
            btnDesactivar.Enabled = false;
            CargarUbigeo(cmbDepartamento);
        }

        private void CargarUbigeo(ComboBox _cmbDepartamento)
        {
            try
            {
                var UL = new LogUbigeo();
                dtUbigeo = UL.Listar();
                DataTable dtDepart = dtUbigeo.DefaultView.ToTable(true, new string[] { "Departamento" });
                _cmbDepartamento.Items.Clear();
                for (int i = 0; i < dtDepart.Rows.Count; i++)
                {
                    _cmbDepartamento.Items.Add(dtDepart.Rows[i]["Departamento"].ToString());
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void ListarCliente(Documento codDocumento)
        {
            try
            {
                //Cargar cliente recientes en ventas
                var listCliente = LC.Listar(codDocumento, null);
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
        private void ListarClienteSocio(Documento codDocumento)
        {
            try
            {
                var listCliente = LC.Listar(codDocumento, null).Where(d => d.IdCliente != MCliente.IdCliente).ToList();
                if (listCliente.Count > 0)
                {
                    var source = new AutoCompleteStringCollection();
                    string[] listaruc = new string[listCliente.Count];
                    for (int i = 0; i < listCliente.Count; i++)
                    {
                        listaruc[i] = listCliente[i].NumDocumento;
                    }
                    source.AddRange(listaruc);
                    txtSocioNumero.AutoCompleteCustomSource = source;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSocioNumero.AutoCompleteCustomSource.Clear();

            }
        }

        private void CargaSocios(int idCliente)
        {
            try
            {
                listClienteSocio = LSC.Listar(idCliente, null);
                MostrarSocio();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MostrarSocio()
        {
            dgvSocio.Rows.Clear();
            for (int i = 0; i < listClienteSocio.Count; i++)
            {
                var rw = listClienteSocio[i];
                dgvSocio.Rows.Add(rw.IdCliente2, rw.IdCliente1, rw.RazSocial, rw.NumDocumento, rw.Telefono, rw.TipSocio);
            }
            dgvSocio.Columns[ColSocioCliente.RazSocial.ToString()].Width = 200;
        }
        private void CargaDireccion(int idCliente)
        {
            try
            {
                listDireccionCliente = LD.Listar(idCliente, null);
                dgvDireccion.DataSource = listDireccionCliente;
                dgvDireccion.Columns[ColDireccion.IdDireccion.ToString()].Visible = false;
                dgvDireccion.Columns[ColDireccion.IdCliente.ToString()].Visible = false;
                dgvDireccion.Columns[ColDireccion.IdUbigeo.ToString()].Visible = false;
                dgvDireccion.Columns[ColDireccion.Estado.ToString()].Visible = false;
                dgvDireccion.Columns[ColDireccion.NombreDireccion.ToString()].Width = 200;
                dgvDireccion.Columns[ColDireccion.NombreDireccion.ToString()].HeaderText = "Dirección";
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarCredito(int idCliente)
        {
            try
            {
                var lineaCredito = LLC.Listar(idCliente, null).FirstOrDefault();
                tbcCredito.Enabled = true;
                if (lineaCredito != null)
                {
                    MLCredito.IdLineaCredito = lineaCredito.IdLineaCredito;
                    txtCtoDias.Text = lineaCredito.DiasMax.ToString();
                    txtCtoMonto.Text = lineaCredito.MontoMax.ToString();

                    cmbCtoCalificacion.SelectedValue = lineaCredito.IdCalificacion;

                    chbEstadoCredito.Checked = lineaCredito.Estado;
                    chbEstadoCredito.BackColor = chbEstadoCredito.Checked ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                    chbEstadoCredito.Text = chbEstadoCredito.Checked ? "Activo" : "Desactivado";
                    ActDesCredito(false);
                    eventsCredito = Evento.Modificar;
                    chbEstadoCredito.Visible = true;
                    //ListarDeudas(idCliente, lineaCredito);
                }
                else
                {
                    MLCredito.IdLineaCredito = 0;
                    eventsCredito = Evento.Agragar;
                    LimpiarCredito();
                    ActDesCredito(true);
                    chbEstadoCredito.Visible = false;
                    txtCtoConsumido.Text = "";
                    txtCtoSaldo.Text = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void MostrarGrafico(int idCliente)
        //{
        //    var LV = new LogVentas();

        //    var listVentasGeneral = LV.ConsultaDetalleVentaCliente(idCliente);

        //    var listCredito = listVentasGeneral.Where(d => d.Credito);
        //    var listContado = listVentasGeneral.Where(d => !d.Credito);
        //    ArrayList fechas = new ArrayList();
        //    ArrayList importes = new ArrayList();

        //    if (rdMes.Checked)
        //    {
        //        var resultMes = (from item in listVentasGeneral.Where(d => d.FEmision.Year == DateTime.Now.Year)
        //                         group item by item.Mes into g
        //                         select new
        //                         {
        //                             Mes = g.Key,
        //                             Importe = g.Sum(x => x.Importe),
        //                         }).ToList();
        //        for (int i = 0; i < resultMes.Count; i++)
        //        {
        //            fechas.Add(resultMes[i].Mes);
        //            importes.Add(resultMes[i].Importe);
        //        }

        //    }

        //    else if (rdAño.Checked)
        //    {
        //        var resultMes = (from item in listVentasGeneral
        //                         group item by item.FEmision.Year into g
        //                         select new
        //                         {
        //                             A = g.Key,
        //                             Importe = g.Sum(x => x.Importe),
        //                         }).ToList();

        //        for (int i = 0; i < resultMes.Count; i++)
        //        {
        //            fechas.Add(resultMes[i].A);
        //            importes.Add(resultMes[i].Importe);
        //        }
        //    }

        //    chVentas.Series["General"].Points.DataBindXY(fechas, importes);

        //}

        //private void ListarDeudas(int idCliente, ModelLineaCredito lineaCredito)
        //{
        //    var LC = new LogicaCobranza();
        //    var LV = new LogicaVentas();
        //    dgvCredito.Rows.Clear();
        //    var listVentas = LV.ConsultaVentasCliente(idCliente).Where(d => !d.Cancelado).ToList();//Datos de Ventas que faltan cancelar
        //    if (listVentas.Count > 0)
        //    {
        //        listDeudas = LC.ConsultaDeudasCliente(idCliente);//Suma de Deudas del cliente
        //        for (int i = 0; i < listDeudas.Count; i++)
        //        {
        //            var d = listDeudas[i];
        //            var v = listVentas.Find(x => x.IdVentas == d.IdVentas);
        //            listDeudas[i].Serie = v.SerieT;
        //            listDeudas[i].Simbolo = v.Simbolo;
        //            listDeudas[i].Numero = v.Numero;
        //            listDeudas[i].FEmision = v.FEmision;
        //            listDeudas[i].TVenta = v.TipoVenta;
        //            listDeudas[i].FVencimiento = v.FVencimiento;
        //            listDeudas[i].Credito = v.Credito;
        //            listDeudas[i].Plazo = v.Plazo;
        //            listDeudas[i].Usuario = v.NomUsuario;
        //        }
        //        for (int i = 0; i < listDeudas.Count; i++)
        //        {
        //            var row = listDeudas[i];
        //            dgvCredito.Rows.Add(row.IdVentas, row.Documento, row.Condicion, row.FEmision, row.FVencimiento.ToShortDateString(), row.Importe, row.ACuenta, row.Saldo, row.Situacion);
        //        }
        //        //dgv.Focus();
        //        ConfigurarDGV();
        //        CalcularMontos(listDeudas, lineaCredito);
        //    }
        //    //decimal consumo = Deuda(idCliente);
        //}
        //private void ListarDespachos(int idCliente)
        //{
        //    var LV = new LogicaVentas();
        //    dgvDespacho.Rows.Clear();
        //    var listVentas = LV.ConsultaVentasCliente(idCliente);
        //    if (listVentas.Count > 0)
        //    {
        //        for (int i = 0; i < listVentas.Count; i++)
        //        {
        //            var row = listVentas[i];
        //            var listDetalleVentas = LV.ConsultaDetalleVenta(row.IdVentas);
        //            var importe = listDetalleVentas.Sum(d => d.Importe);
        //            dgvDespacho.Rows.Add(row.IdProforma, row.Numeracion, row.TipoVenta, row.FEmision, decimal.Round(importe, 2));
        //        }
        //    }
        //    dgvDespacho.Columns["DocumentoDespacho"].Width = 100;
        //    dgvDespacho.Columns["tventaDespacho"].Width = 80;
        //    dgvDespacho.Columns["FEmisionDespacho"].Width = 120;
        //}
        private void ConfigurarDGV()
        {
            dgvCredito.Columns["Documento"].Width = 100;
            dgvCredito.Columns["FEmision"].Width = 120;
        }
        private void CalcularMontos(List<ModelCobranza> listDeudas, ModelLineaCredito lineaCredito)
        {
            Decimal TotalDeuda = 0;
            Decimal ACuenta = 0;
            TotalDeuda = listDeudas.Where(e => e.Credito).Sum(d => d.Importe);
            ACuenta = listDeudas.Where(e => e.Credito).Sum(d => d.ACuenta);
            //txtAcuenta.Text = ACuenta + "";
            Decimal DeudaActual = TotalDeuda - ACuenta;
            txtCtoConsumido.Text = DeudaActual + "";
            txtCtoSaldo.Text = (lineaCredito.MontoMax - DeudaActual) + "";
        }
        private decimal Deuda(int idCliente)
        {
            try
            {
                var LC = new LogicaCobranza();
                return LC.ConsultaDeudaCliente(idCliente).Sum(d => d.Importe);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }
        private void CargaDocumento()
        {
            try
            {
                cmbDocumento.DataSource = Enum.GetValues(typeof(Documento));
                cmbDocumento.SelectedItem = VERTICAL.Modelos.Publico.Documento.RUC;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CargaDocumentoSocio()
        {
            try
            {
                cmbSocioDocumento.DataSource = Enum.GetValues(typeof(Documento));
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void CargaCalificacion()
        {
            LogCalificacion LC = new LogCalificacion();
            lisCalificacion = new List<ModelCalificacion>();
            try
            {
                lisCalificacion = LC.Listar(null, null);
                if (lisCalificacion.Count > 0)
                {
                    cmbCtoCalificacion.DataSource = lisCalificacion;
                    cmbCtoCalificacion.ValueMember = ColCalificacion.IdCalificacion.ToString();
                    cmbCtoCalificacion.DisplayMember = ColCalificacion.Nota.ToString();
                }
                else
                {
                    MessageBox.Show("Aun no existe tipod de documentos en la base de datos", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActDesSocio(bool act)
        {
            cmbSocioDocumento.Enabled = act;
            txtSocioNumero.Enabled = act;
            //txtSocioNombres.Enabled = act;
            txtSocioRelacion.Enabled = act;
            btnSocioCancelr.Enabled = act;
            btnSocioGuardar.Enabled = act;
        }

        private void LimpiarSocios()
        {
            txtSocioNumero.Clear();
            txtSocioNombres.Clear();
            txtSocioRelacion.Clear();
            cmbSocioDocumento.ResetText();//
        }

        private void ActDesDirecciones(bool act)
        {
            cmbDirDepart.Enabled = act;
            cmbDirProvincia.Enabled = act;
            cmbDirDistrito.Enabled = act;
            txtDirDireccion.Enabled = act;
            btnDirCancelar.Enabled = act;
            btnDirGuardar.Enabled = act;
        }

        private void LimpiarDirecciones()
        {
            cmbDirDepart.Text = "";
            cmbDirProvincia.Text = "";
            cmbDirDistrito.Text = "";
            txtDirDireccion.Clear();
            lblDirDireccion.Text = "";
        }

        private void ActDesDatos(bool act)
        {
            cmbDepartamento.Enabled = act;
            cmbProvincia.Enabled = act;
            cmbDistrito.Enabled = act;
            txtRazSocial.Enabled = act;
            txtDireccion.Enabled = act;
            txtTelefono.Enabled = act;
            txtEmail.Enabled = act;
            btnEdit.Enabled = !act;
            btnGuardar.Enabled = act;
        }

        private void LimpiarDatos()
        {
            cmbDepartamento.Text = "";
            cmbProvincia.Text = "";
            cmbDistrito.Text = "";
            txtDireccion.Clear();
            lblDireccion.Text = "";
            txtRazSocial.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        private void ActDesCredito(bool act)
        {
            txtCtoDias.Enabled = act;
            txtCtoMonto.Enabled = act;
            cmbCtoCalificacion.Enabled = act;
            btnCtoEditar.Enabled = !act;
            btnCtoGuardar.Enabled = act;
            btnCtoCancelar.Enabled = act;
            chbEstadoCredito.Enabled = act;
        }

        private void LimpiarCredito()
        {
            txtCtoDias.Clear();
            txtCtoMonto.Clear();
            txtCtoConsumido.Clear();
            txtCtoSaldo.Clear();
            cmbCtoCalificacion.Text = "";
            lblCalificacion.Text = "";
            chbEstadoCredito.Checked = false;
            chbEstadoCredito.BackColor = System.Drawing.Color.White;
            chbEstadoCredito.Text = "";
        }

        private void CargaCliente(string numDocumento, Documento doc)
        {
            if (doc > 0)
            {
                if (Validaciones.ValidarDocumento(doc, numDocumento))
                {
                    var cliente = LC.Consulta(numDocumento, (int)doc);
                    if (cliente != null)
                    {
                        MCliente.IdCliente = cliente.IdCliente;
                        MCliente.Estado = cliente.Estado;
                        MCliente.NumDocumento = cliente.NumDocumento;
                        tbcDatosAdicionales.Enabled = true;
                        CargaCalificacion();
                        CargaSocios(MCliente.IdCliente);
                        CargarCredito(MCliente.IdCliente);
                        //MostrarGrafico(MCliente.IdCliente);
                        txtRazSocial.Text = cliente.RazSocial;
                        txtDireccion.Text = cliente.Direccion;
                        cmbDepartamento.Text = cliente.Departamento;
                        cmbProvincia.Text = cliente.Provincia;
                        cmbDistrito.Text = cliente.Distrito;
                        txtEmail.Text = cliente.Email;
                        txtTelefono.Text = cliente.Telefono;
                        ClienteActivado(cliente.Estado);
                        btnDesactivar.Enabled = true;
                        gbDatos.Enabled = true;
                        ActDesDatos(false);
                        btnEdit.Focus();
                    }
                    else
                    {
                        if (eventsCliente == Evento.Nulo)
                        {
                            eventsCliente = Evento.Agragar;
                        }

                        if (Validaciones.ValidarDocumento(doc, txtNumero.Text))
                        {

                            if (VERTICAL.Modelos.Publico.Documento.RUC == doc)
                            {
                                try
                                {
                                    var url = "https://api.apis.net.pe/v1/ruc?numero=" + numDocumento;
                                    WebClient wc = new WebClient();
                                    Cursor.Current = Cursors.WaitCursor;
                                    var datos = wc.DownloadString(url);
                                    Cursor.Current = Cursors.Default;
                                    var rs = JsonConvert.DeserializeObject<DatosRuc>(datos);
                                    txtRazSocial.Text = rs.nombre;
                                    txtDireccion.Text = rs.direccion;
                                    MCliente.NumDocumento = rs.numeroDocumento;
                                    lblEstado.Text = rs.estado + "/" + rs.condicion;
                                    cmbDepartamento.Text = rs.departamento;
                                    cmbProvincia.Text = rs.provincia;
                                    //MODIFICAR CODIGO UBIGEO EN LA BASE DE DATOS
                                    DataRow[] row = dtUbigeo.Select("Codigo ='" + rs.ubigeo + "'");
                                    if (row.Length > 0)
                                    {
                                        //DataRow[] row = dtUbigeo.Select("Codigo ='21809'");// + Convert.ToInt32(rs.ubigeo) +"'");
                                        var id = row[0][0].ToString();
                                        cmbDistrito.SelectedValue = Convert.ToInt32(id);
                                    }
                                    else
                                    {
                                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "Seleccione un distrito", Color.Green);
                                        cmbDistrito.Focus();
                                    }
                                    ActDesSocio(true);
                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message + "\nIngrese los datos del cliente y el del representante y guarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtRazSocial.Focus();
                                }
                            }
                            //ClienteActivado(C.Estado);
                            else if (VERTICAL.Modelos.Publico.Documento.DNI == doc)
                            {
                                try
                                {

                                    //var url = "https://api.sunat.cloud/ruc/" + numDocumento;
                                    //var url = "https://api.reniec.cloud/dni/" + numDocumento;
                                    //var url = "https://dni.optimizeperu.com/api/persons/" + numDocumento;
                                    var url = "https://api.apis.net.pe/v1/dni?numero=" + numDocumento;

                                    WebClient wc = new WebClient();
                                    Cursor.Current = Cursors.WaitCursor;
                                    string datos = wc.DownloadString(url);
                                    Cursor.Current = Cursors.Default;
                                    if (datos != "")
                                    {
                                        var rs = JsonConvert.DeserializeObject<DatosDNI>(datos);
                                        txtRazSocial.Text = rs.nombre;
                                        MCliente.NumDocumento = rs.numeroDocumento;
                                        lblEstado.Text = rs.tipoDocumento + "";
                                    }
                                    else
                                    {
                                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "DNI nuevo, reniec no disponible, ingrese manualmente", Color.Orange);
                                        txtRazSocial.Focus();
                                    }
                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message, "Error \n ingrese manualmente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtRazSocial.Focus();
                                }
                            }

                        }
                        else
                        {
                            LabelMessage.Mensaje(timer1, lblError, "Sistema", "Documento incorrecto", Color.Red);
                            txtNumero.Focus();
                        }
                        btnDesactivar.Enabled = false;
                        gbDatos.Enabled = true;
                        tbcDatosAdicionales.Enabled = true;
                        ActDesDatos(true);
                        txtRazSocial.Focus();
                        //ActDesRepresentante(true);
                    }
                }
                else
                {
                    LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese numero válido", Color.Red);
                    txtNumero.Focus();
                }
            }
            else
            {

                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Seleccione tipo de documento", Color.Red);
                cmbDocumento.Focus();
            }
        }

        private void ClienteActivado(bool estado)
        {
            btnDesactivar.Text = estado ? "Activo" : "Desact";
            btnDesactivar.BackColor = estado ? Color.Green : Color.Red;
        }
        private void ReiniciarVentana()
        {
            LimpiarDatos();
            LimpiarSocios();
            LimpiarDirecciones();
            LimpiarCredito();
            tbcDatosAdicionales.Enabled = false;
            gbDatos.Enabled = false;
            tbcCredito.Enabled = false;
            lblTitulo.Text = "";
            btnDesactivar.Text = "";
            btnDesactivar.Enabled = false;
            btnDesactivar.BackColor = Color.White;
            MCliente.IdCliente = 0;
            MCliente.Estado = false;
            eventsCliente = Evento.Nulo;
            dgvSocio.Rows.Clear();
            dgvCredito.Rows.Clear();
            //CargaSocios(CModel.IdCliente);
            //CargaDireccion(CModel.IdCliente);
            //CargarCredito(C.IdCliente);
            //cbDocumento.Focus();
        }

        private void CargaTipoDocumento(Documento doc)
        {

            if (eventsCliente != Evento.Modificar)
            {
                ReiniciarVentana();
            }
            if (VERTICAL.Modelos.Publico.Documento.RUC == doc)
            {
                txtNumero.MaxLength = 11;
            }
            else if (VERTICAL.Modelos.Publico.Documento.DNI == doc)
            {
                txtNumero.MaxLength = 8;
            }
            else
            {
                txtNumero.MaxLength = 20;
            }
            ListarCliente(doc);
            txtNumero.Clear();
            txtNumero.Focus();
        }
        private void CargaTipoDocumentoSocio(Documento doc)
        {
            if (doc == VERTICAL.Modelos.Publico.Documento.RUC)
            {
                txtSocioNumero.MaxLength = 11;
            }
            else if (doc == VERTICAL.Modelos.Publico.Documento.DNI)
            {
                txtSocioNumero.MaxLength = 8;
            }
            else
            {
                txtSocioNumero.MaxLength = 20;
            }
            ListarClienteSocio(doc);
            txtSocioNumero.Clear();
            txtSocioNumero.Focus();
        }
        private void CargaClienteSocio(string numDocumento, Documento doc)
        {
            if (doc > 0)
            {
                if (Validaciones.ValidarDocumento(doc, numDocumento))
                {
                    var cliente = LC.Consulta(numDocumento, (int)doc);
                    if (cliente != null)
                    {
                        //Si el cliente principal no es igual al del supuesto socio
                        if (MCliente.IdCliente != cliente.IdCliente)
                        {
                            MSocio.IdCliente1 = MCliente.IdCliente;
                            MSocio.IdCliente2 = cliente.IdCliente;
                            txtSocioNombres.Text = cliente.RazSocial;
                            txtSocioRelacion.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Este cliente no puede ser socio del mismo socio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSocioNumero.Focus();
                        }
                    }
                    else
                    {
                        LabelMessage.Mensaje(timer1, lblError, "BD", "Este cliente con este numero no existe. Primero registra como cliente principal", Color.Orange);
                        txtSocioNumero.Focus();
                    }
                }
                else
                {
                    LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese numero válido", Color.Red);
                    txtSocioNumero.Focus();
                }
            }
            else
            {
                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Seleccione tipo de documento", Color.Red);
                cmbDocumento.Focus();
            }
        }
        private void Grabar(Documento doc)
        {
            string mensaje;
            switch (eventsCliente)
            {
                case Evento.Agragar:
                    if (!string.IsNullOrEmpty(txtRazSocial.Text))
                    {
                        if (MCliente.CodDocumento > 0)
                        {
                            if (MCliente.IdUbigeo > 0)
                            {
                                if (Validaciones.ValidarDocumento(doc, txtNumero.Text))
                                {
                                    MCliente.RazSocial = txtRazSocial.Text;
                                    MCliente.NumDocumento = txtNumero.Text;
                                    MCliente.Direccion = txtDireccion.Text;
                                    MCliente.Email = txtEmail.Text;
                                    MCliente.Telefono = txtTelefono.Text;
                                    mensaje = LC.Registrar(MCliente);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Cliente registrado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ListarCliente(MCliente.CodDocumento);
                                        CargaCliente(MCliente.NumDocumento, doc);
                                        tbcDatosAdicionales.Enabled = true;
                                        tbcCredito.Enabled = true;
                                        eventsCliente = Evento.Nulo;
                                        if (eventsSocio == Evento.Agragar)
                                        {
                                            ActDesSocio(true);
                                            txtSocioNumero.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese numero válido", Color.Red);
                                    txtNumero.Focus();
                                }
                            }
                            else
                            {
                                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Seleccione Ubigeo", Color.Red);
                                cmbDepartamento.Focus();
                            }
                        }
                    }
                    else
                    {
                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingresar razon social o nombres completos", Color.Red);
                        txtRazSocial.Focus();
                    }
                    break;
                case Evento.Modificar:
                    if (MCliente.IdCliente > 0)
                    {
                        if (!string.IsNullOrEmpty(txtRazSocial.Text))
                        {
                            if (Validaciones.ValidarDocumento(doc, txtNumero.Text))
                            {
                                if (MCliente.CodDocumento > 0)
                                {
                                    if (MCliente.IdUbigeo > 0)
                                    {
                                        MCliente.RazSocial = txtRazSocial.Text;
                                        MCliente.NumDocumento = txtNumero.Text;
                                        MCliente.Direccion = txtDireccion.Text;
                                        MCliente.Email = txtEmail.Text;
                                        MCliente.Telefono = txtTelefono.Text;
                                        mensaje = LC.Modificar(MCliente);
                                        if (mensaje == "1")
                                        {
                                            MessageBox.Show("Cliente actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ListarCliente(MCliente.CodDocumento);
                                            CargaCliente(MCliente.NumDocumento, doc);
                                        }
                                        else
                                        {
                                            MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "Es necesario seleccionar el distrito de la dirección", Color.Red);
                                        cmbDepartamento.Focus();
                                    }
                                }
                                else
                                {
                                    LabelMessage.Mensaje(timer1, lblError, "Sistema", "Tiene que seleccionar el tipo de documento", Color.Red);
                                    cmbDocumento.Focus();
                                }
                            }
                            else
                            {
                                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese número correcto", Color.Red);
                                txtNumero.Focus();
                            }
                        }
                        else
                        {
                            LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese razon social o nombres completos", Color.Red);
                            txtRazSocial.Focus();
                        }
                    }
                    else
                    {
                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "No existe cliente a modificar", Color.Red);
                        txtNumero.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
        private void ImprimirDeudas()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                LocalReport rdlc = new LocalReport();
                rdlc.ReportPath = Path.GetFullPath(pathReport);
                rdlc.DataSources.Add(new ReportDataSource("DSDeudasModel", listDeudas));
                rdlc.SetParameters(new ReportParameter("Cliente", txtRazSocial.Text + " - " + txtNumero.Text));//Modificar
                rdlc.SetParameters(new ReportParameter("Usuario", "Luis Larota"));//Modificar
                rdlc.SetParameters(new ReportParameter("Direccion", lblDireccion.Text + " (Telf. " + txtTelefono.Text + ")"));//Modificar
                string date = DateTime.Now.Ticks.ToString();
                string path = @"E:\Creditos";
                string file = @"\" + date + @".pdf";

                ExportarPDF.Save(rdlc, path, file, out string mensaje);
                Cursor.Current = Cursors.Default;
                if (mensaje != "1")
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    Process.Start(path);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "El error es en UI Venta metodo exportarpdf");
            }
        }
        private decimal ConsultaIgv()
        {
            try
            {
                var LI = new LogIgv();
                var lis = LI.Listar(null, null);
                var igv = lis.Find(d => d.Estado).IGV;
                return igv;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargaCliente(txtNumero.Text, MCliente.CodDocumento);
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
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDireccion.Text != "")
            {
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Grabar(MCliente.CodDocumento);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ActDesDatos(true);
            tbcDatosAdicionales.Enabled = false;
            tbcCredito.Enabled = false;
            txtRazSocial.Focus();
            eventsCliente = Evento.Modificar;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarVentana();
            txtNumero.Clear();
            txtNumero.Focus();
        }
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            string accion = MCliente.Estado ? "Desactivar" : "Activar";
            if (MessageBox.Show("Esta seguro de " + accion + " este Cliente?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = "";
                var LC = new LogCliente();
                mensaje = LC.Eliminar(MCliente.IdCliente, MCliente.Estado);
                if (mensaje == "1")
                {
                    MessageBox.Show("Se acava de " + accion + " este Cliente?", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargaCliente(MCliente.NumDocumento, MCliente.CodDocumento);
                }
                else
                {
                    MessageBox.Show(mensaje, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void cmbDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Documento documento;
            if (cmbDocumento.SelectedValue != null && Enum.TryParse<Documento>(cmbDocumento.SelectedValue.ToString(), out documento))
            {
                MCliente.CodDocumento = documento;
                //MDoc = documento;
                CargaTipoDocumento(documento);
            }
        }
        private void cmbDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
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
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDepartamento.Text) && !string.IsNullOrEmpty(cmbProvincia.Text))
            {
                DataRow[] drDist = dtUbigeo.Select("Departamento ='" + cmbDepartamento.Text.Trim() + "' and Provincia ='" + cmbProvincia.Text.Trim() + "'");
                DataTable dtDist = drDist.CopyToDataTable();
                List<ModelUbigeo> lista = new List<ModelUbigeo>();
                // cbDistrito.Items.Clear();
                for (int i = 0; i < dtDist.Rows.Count; i++)
                {
                    var dr = dtDist.Rows[i];
                    lista.Add(new ModelUbigeo
                    {
                        IdUbigeo = int.Parse(dr[ColUbigeo.IdUbigeo.ToString()].ToString()),
                        Departamento = dr[ColUbigeo.Departamento.ToString()].ToString(),
                        Provincia = dr[ColUbigeo.Provincia.ToString()].ToString(),
                        Distrito = dr[ColUbigeo.Distrito.ToString()].ToString()
                    });

                }
                cmbDistrito.DataSource = lista;
                cmbDistrito.ValueMember = ColUbigeo.IdUbigeo.ToString();
                cmbDistrito.DisplayMember = ColUbigeo.Distrito.ToString();
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }
        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrito.SelectedValue != null && int.TryParse(cmbDistrito.SelectedValue.ToString(), out int i))
            {
                MCliente.IdUbigeo = i;
                lblDireccion.Text = txtDireccion.Text + " - " + cmbDepartamento.Text + " - " + cmbProvincia.Text + " - " + cmbDistrito.Text;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eventsCliente.Equals(Evento.Nulo) && MCliente.IdCliente > 0)
            {
                if (tbcDatosAdicionales.SelectedTab == tbpSocio)
                {
                    eventsSocio = Evento.Agragar;
                    CargaDocumentoSocio();
                    ActDesSocio(true);
                    //
                }
                else if (tbcDatosAdicionales.SelectedTab == tbpDireccion)
                {
                    CargarUbigeo(cmbDirDepart);
                    eventsDireccion = Evento.Agragar;
                    ActDesDirecciones(true);
                }
            }
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbcDatosAdicionales.SelectedTab == tbpSocio)
            {
                if (dgvSocio.SelectedRows.Count > 0)
                {
                    CargaDocumentoSocio();
                    try
                    {
                        int IdClienteSocio = Convert.ToInt32(dgvSocio.CurrentRow.Cells[ColSocioCliente.IdCliente2.ToString()].Value);
                        MSocio = listClienteSocio.Find(d => d.IdCliente2 == IdClienteSocio);

                        cmbSocioDocumento.SelectedItem = MSocio.CodDocumento;
                        //cmbSocioDocumento.SelectedValue = doc;
                        txtSocioNumero.Text = MSocio.NumDocumento;
                        txtSocioNombres.Text = MSocio.RazSocial;
                        txtSocioRelacion.Text = MSocio.TipSocio;
                        ActDesSocio(true);
                        txtSocioRelacion.Focus();
                        eventsSocio = Evento.Modificar;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbcDatosAdicionales.SelectedTab == tbpDireccion)
            {
                if (dgvDireccion.SelectedRows.Count > 0)
                {
                    CargarUbigeo(cmbDirDepart);
                    try
                    {
                        int idDireccion = Convert.ToInt32(dgvDireccion.CurrentRow.Cells[ColDireccion.IdDireccion.ToString()].Value);
                        DCModel = listDireccionCliente.Find(d => d.IdDireccion == idDireccion);
                        int idUbigeo = DCModel.IdUbigeo;
                        cmbDirDepart.Text = DCModel.Departamento;
                        cmbDirProvincia.Text = DCModel.Provincia;
                        txtDirDireccion.Text = DCModel.NombreDireccion;
                        ActDesDirecciones(true);
                        eventsDireccion = Evento.Modificar;
                        cmbDirDistrito.SelectedValue = idUbigeo;
                        txtDirDireccion.Focus();
                    }
                    catch (NullReferenceException nex) {
                        MessageBox.Show(nex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbcDatosAdicionales.SelectedTab == tbpSocio)
            {
                if (dgvSocio.SelectedRows.Count > 0)
                {
                    try
                    {
                        if (MessageBox.Show("Estas seguro de eliminar esta fila?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string mensaje = "";
                            int IdClientePrincipal = Convert.ToInt32(dgvSocio.CurrentRow.Cells[ColSocioCliente.IdCliente1.ToString()].Value);
                            int IdClienteSocio = Convert.ToInt32(dgvSocio.CurrentRow.Cells[ColSocioCliente.IdCliente2.ToString()].Value);
                            mensaje = LSC.Eliminar(IdClientePrincipal, IdClienteSocio);
                            if (mensaje == "1")
                            {
                                MostrarSocio();
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
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tbcDatosAdicionales.SelectedTab == tbpDireccion)
            {

                if (dgvDireccion.SelectedRows.Count > 0)
                {
                    try
                    {
                        if (MessageBox.Show("Estas seguro de eliminar esta fila?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string mensaje = "";
                            int idDireccion = Convert.ToInt32(dgvDireccion.CurrentRow.Cells[ColDireccion.IdDireccion.ToString()].Value);
                            mensaje = LD.Eliminar(idDireccion, true);
                            if (mensaje == "1")
                            {
                                CargaDireccion(MCliente.IdCliente);
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
                    MessageBox.Show("Debe Seleccionar la fila a editar.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }


        private void btnCtoGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCtoDias.Text) && int.Parse(txtCtoDias.Text) > 0)
            {
                if (!string.IsNullOrEmpty(txtCtoMonto.Text) && decimal.Parse(txtCtoMonto.Text) > 0)
                {
                    if (MCliente.IdCliente > 0)
                    {
                        string mensaje;
                        switch (eventsCredito)
                        {
                            case Evento.Agragar:
                                if (MLCredito.IdCalificacion > 0)
                                {
                                    MLCredito.IdCliente = MCliente.IdCliente;
                                    MLCredito.DiasMax = int.Parse(txtCtoDias.Text);
                                    MLCredito.MontoMax = decimal.Parse(txtCtoMonto.Text);
                                    mensaje = LLC.Registrar(MLCredito);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Crédito abierto para este cliente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CargarCredito(MCliente.IdCliente);
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                            case Evento.Modificar:
                                if (MLCredito.IdLineaCredito > 0)
                                {
                                    MLCredito.DiasMax = int.Parse(txtCtoDias.Text);
                                    MLCredito.MontoMax = decimal.Parse(txtCtoMonto.Text);
                                    mensaje = LLC.Modificar(MLCredito);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Crédito actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CargarCredito(MCliente.IdCliente);
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                break;
                            case Evento.Eliminar:
                                if (MLCredito.IdLineaCredito > 0)
                                {
                                    MLCredito.Estado = chbEstadoCredito.Checked;
                                    if (!MLCredito.Estado)
                                    {
                                        if (MessageBox.Show("Estas seguro de desactivar el credito para este cliente?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            mensaje = LLC.Eliminar(MLCredito.IdLineaCredito, MLCredito.Estado);
                                            if (mensaje == "1")
                                            {
                                                MessageBox.Show("Crédito actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                CargarCredito(MCliente.IdCliente);
                                            }
                                            else
                                            {
                                                MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        mensaje = LLC.Eliminar(MLCredito.IdLineaCredito, MLCredito.Estado);
                                        if (mensaje == "1")
                                        {
                                            MessageBox.Show("Crédito actualizado correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            CargarCredito(MCliente.IdCliente);
                                        }
                                        else
                                        {
                                            MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    LabelMessage.Mensaje(timer1, lblError, "Sistema", "El monto maximo no puede ser vacío ni 0", Color.Red);
                    txtCtoMonto.Focus();
                }
            }
            else
            {
                LabelMessage.Mensaje(timer1, lblError, "Sistema", "El máximo de días no puede ser vacío ni 0", Color.Red);
                txtCtoDias.Focus();
            }
        }
        private void btnCtoEditar_Click(object sender, EventArgs e)
        {
            ActDesCredito(true);
            txtCtoDias.Focus();
        }
        private void btnCtoCancelar_Click(object sender, EventArgs e)
        {
            CargarCredito(MCliente.IdCliente);
            //if (eventsCredito != Helps.Events.Modified)
            //{
            //    LimpiarCredito();
            //    txtCtoDias.Focus();
            //}
            //else if (eventsCredito == Helps.Events.Modified)
            //{
            //    ActDesCredito(false);
            //}
        }
        private void chbEstadoCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (eventsCredito == Evento.Modificar)
            {
                eventsCredito = Evento.Eliminar;
            }
            chbEstadoCredito.BackColor = chbEstadoCredito.Checked ? Color.Green : Color.Red;
            chbEstadoCredito.Text = chbEstadoCredito.Checked ? "Activo" : "Desactivado";
        }


        private void cmbCtoCalificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCtoCalificacion.SelectedValue != null && int.TryParse(cmbCtoCalificacion.SelectedValue.ToString(), out int i))
            {
                lblCalificacion.Text = lisCalificacion.Find(x => x.IdCalificacion == i).Descripcion;
                MLCredito.IdCalificacion = i;
            }
        }
        private void cmbCtoCalificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void btnSocioGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSocioNumero.Text) && Validaciones.ValidarDocumento(MDocSocio, txtSocioNumero.Text))
            {
                if (!string.IsNullOrEmpty(txtSocioNombres.Text))
                {
                    if (MSocio.IdCliente1 > 0)//CLIENTE PRINCIPAL
                    {
                        if (MSocio.IdCliente2 > 0)
                        {
                            switch (eventsSocio)
                            {
                                case Evento.Agragar:
                                    string mensaje;
                                    MSocio.TipSocio = txtSocioRelacion.Text;
                                    mensaje = LSC.Registrar(MSocio);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Socio registrado correctamente", "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LimpiarSocios();
                                        ActDesSocio(false);
                                        MostrarSocio();
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    break;
                                case Evento.Modificar:
                                    if (MSocio.IdCliente1 > 0)
                                    {
                                        MSocio.IdCliente1 = MCliente.IdCliente;
                                        MSocio.TipSocio = txtSocioRelacion.Text;
                                        mensaje = LSC.Modificar(MSocio);
                                        if (mensaje == "1")
                                        {
                                            MessageBox.Show("Representante registrado correctamente", "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            LimpiarSocios();
                                            ActDesSocio(false);
                                            MostrarSocio();
                                        }
                                        else
                                        {
                                            MessageBox.Show(mensaje, "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No ha cargado cliente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese numero del socio", Color.Red);
                            txtSocioNumero.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cargue el cliente a quien quieres agregar el representante", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese numero de documento del cliente y precione Enter, para cargar", Color.Red);
                    txtSocioNumero.Focus();
                }
            }
            else
            {
                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Selecciones tipo de documento", Color.Red);
                txtSocioNumero.Focus();
            }

        }
        private void btnSocioCancelr_Click(object sender, EventArgs e)
        {
            LimpiarSocios();
            ActDesSocio(false);
        }
        private void TxtSocioNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Documento documento;
                if (cmbSocioDocumento.SelectedValue != null && Enum.TryParse<Documento>(cmbSocioDocumento.SelectedValue.ToString(), out documento))
                {
                    CargaClienteSocio(txtSocioNumero.Text, documento);
                }
            }
        }
        private void cmbSocioDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Documento documento;
            if (cmbSocioDocumento.SelectedValue != null && Enum.TryParse<Documento>(cmbSocioDocumento.SelectedValue.ToString(), out documento))
            {
                MDocSocio = documento;
                CargaTipoDocumentoSocio(documento);
            }
        }


        private void txtDirDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDirDireccion.Text != "")
            {
                lblDirDireccion.Text = txtDirDireccion.Text + " - " + cmbDirDepart.Text + " - " + cmbDirProvincia.Text + " - " + cmbDirDistrito.Text;
            }
        }
        private void btnDirGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDirDireccion.Text))
            {
                if (MCliente.IdCliente > 0)//CLIENTE PRINCIPAL
                {
                    if (DCModel.IdUbigeo > 0)
                    {
                        switch (eventsDireccion)
                        {
                            case Evento.Agragar:
                                string mensaje;
                                DCModel.IdCliente = MCliente.IdCliente;
                                DCModel.NombreDireccion = txtDirDireccion.Text;
                                mensaje = LD.Registrar(DCModel);
                                if (mensaje == "1")
                                {
                                    MessageBox.Show("Dirección registrado correctamente", "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimpiarDirecciones();
                                    ActDesDirecciones(false);
                                    CargaDireccion(MCliente.IdCliente);
                                }
                                else
                                {
                                    MessageBox.Show(mensaje, "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                break;
                            case Evento.Modificar:
                                if (DCModel.IdDireccion > 0)
                                {
                                    DCModel.IdCliente = MCliente.IdCliente;
                                    DCModel.NombreDireccion = txtDirDireccion.Text;
                                    mensaje = LD.Modificar(DCModel);
                                    if (mensaje == "1")
                                    {
                                        MessageBox.Show("Direccion actualizado correctamente", "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LimpiarDirecciones();
                                        ActDesDirecciones(false);
                                        CargaDireccion(MCliente.IdCliente);
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje, "base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No ha cargado direccion", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese numero del socio", Color.Red);
                        cmbDirDistrito.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Cargue el cliente a quien quieres agregar el una Dirección", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Ingrese una dirección correcta", Color.Red);
                txtDirDireccion.Focus();
            }
        }
        private void btnDirCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDirecciones();
            ActDesDirecciones(false);
        }
        private void cmbDirDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDirDepart.Text))
            {
                //List<Ubigeo> lista = new List<Ubigeo>();
                DataRow[] drProv = dtUbigeo.Select("Departamento ='" + cmbDirDepart.Text.Trim() + "'");
                DataTable dtProv = drProv.CopyToDataTable().DefaultView.ToTable(true, new string[] { "Provincia" });
                cmbDirProvincia.Items.Clear();
                cmbDirProvincia.Text = "";
                cmbDirDistrito.Text = "";
                for (int i = 0; i < dtProv.Rows.Count; i++)
                {
                    cmbDirProvincia.Items.Add(dtProv.Rows[i]["Provincia"].ToString());
                }

                lblDirDireccion.Text = txtDirDireccion.Text + " - " + cmbDirDepart.Text + " - " + cmbDirProvincia.Text + " - " + cmbDirDistrito.Text;
            }
        }
        private void cmbDirProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbDirDepart.Text) && !string.IsNullOrEmpty(cmbDirProvincia.Text))
            {
                DataRow[] drDist = dtUbigeo.Select("Departamento ='" + cmbDirDepart.Text.Trim() + "' and Provincia ='" + cmbDirProvincia.Text.Trim() + "'");
                DataTable dtDist = drDist.CopyToDataTable();
                List<ModelUbigeo> lista = new List<ModelUbigeo>();
                // cbDistrito.Items.Clear();
                for (int i = 0; i < dtDist.Rows.Count; i++)
                {
                    var dr = dtDist.Rows[i];
                    lista.Add(new ModelUbigeo
                    {
                        IdUbigeo = int.Parse(dr[ColUbigeo.IdUbigeo.ToString()].ToString()),
                        Departamento = dr[ColUbigeo.Departamento.ToString()].ToString(),
                        Provincia = dr[ColUbigeo.Provincia.ToString()].ToString(),
                        Distrito = dr[ColUbigeo.Distrito.ToString()].ToString()
                    });

                }
                cmbDirDistrito.DataSource = lista;
                cmbDirDistrito.ValueMember = ColUbigeo.IdUbigeo.ToString();
                cmbDirDistrito.DisplayMember = ColUbigeo.Distrito.ToString();
                lblDirDireccion.Text = txtDirDireccion.Text + " - " + cmbDirDepart.Text + " - " + cmbDirProvincia.Text + " - " + cmbDirDistrito.Text;
            }
        }
        private void cmbDirDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDirDistrito.SelectedValue != null && int.TryParse(cmbDirDistrito.SelectedValue.ToString(), out int i))
            {
                DCModel.IdUbigeo = i;
                lblDirDireccion.Text = txtDirDireccion.Text + " - " + cmbDirDepart.Text + " - " + cmbDirProvincia.Text + " - " + cmbDirDistrito.Text;
            }
        }

        private void tbcDatosAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcDatosAdicionales.SelectedTab == tbpDireccion)
            {
                CargaDireccion(MCliente.IdCliente);
                dgvDireccion.Focus();
            }
        }
        private void rdMes_CheckedChanged(object sender, EventArgs e)
        {
            //MostrarGrafico(MCliente.IdCliente);
        }
        private void rdAño_CheckedChanged(object sender, EventArgs e)
        {
            //MostrarGrafico(MCliente.IdCliente);
        }
        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void tbcCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcCredito.SelectedIndex == 2)
            {
                if (MCliente.IdCliente > 0)
                {
                    //ListarDespachos(MCliente.IdCliente);
                }
                dgvDespDetalles.Columns["Codigo"].Width = 65;
                dgvDespDetalles.Columns["Descripcion"].Width = 200;
                dgvDespDetalles.Columns["Unidad"].Width = 65;
                dgvDespDetalles.Columns["Modelo"].Width = 65;
            }
        }
        private void dgvDespacho_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDespacho.SelectedRows.Count > 0)
            {
                if (dgvDespacho.CurrentRow != null)
                {
                    try
                    {
                        int IdProforma = Convert.ToInt32(dgvDespacho.CurrentRow.Cells["IdProforma"].Value);
                        //var LDP = new LogDetalleProforma();
                        //var listDetalleProforma = LDP.ConsultaDetalleProforma(IdProforma, ConsultaIgv());
                        //if (listDetalleProforma.Count > 0)
                        {
                            //  CargarDetalleProforma(listDetalleProforma);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Sistema, BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        //private void CargarDetalleProforma(List<DetalleProformaModel> listDetalleProforma)
        //{
        //    dgvDespDetalles.Rows.Clear();
        //    for (int i = 0; i < listDetalleProforma.Count; i++)
        //    {
        //        var d = listDetalleProforma[i];
        //        dgvDespDetalles.Rows.Add(d.Codigo, d.Descripcion, d.Modelo, d.Unidad, d.Cantidad, Decimal.Round(d.PVENTA, 4), Decimal.Round(d.TOTAL, 4), d.Almacen);
        //    }
        //}
    }
}
