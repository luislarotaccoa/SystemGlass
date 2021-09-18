using LOGICA.Logica.Producto;
using System;
using System.Collections;
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
    public partial class MaestroProducto : Plantilla
    {
        LogProductoUnidad LPU = new LogProductoUnidad();
        LogProducto LP = new LogProducto();
        LogUnidad LU = new LogUnidad();
        LogUnidadCategoria LUC = new LogUnidadCategoria();

        private List<ModelProductoUnidad> listProductoUnidad = new List<ModelProductoUnidad>();
        private List<ModelProducto> listProducto = new List<ModelProducto>();
        private List<ModelUnidad> listUnidades = new List<ModelUnidad>();

        static private ModelProducto PModel;
        static private Evento eventosExterno;

        string modeloTemporal;
        string unidadTemporal;
        private List<ModelAlmacen> listAlmacen;

        public MaestroProducto(ModelProducto _producto, Evento _events)
        {
            InitializeComponent();
            PModel = _producto;
            eventosExterno = _events;
        }

        public override void cargaVentana()
        {
            CargarAlmacen(1);
            if (Evento.Agragar == eventosExterno || Evento.Modificar == eventosExterno)
            {
                txtCodigo.Enabled = false;
                btnKardex.Enabled = false;
                txtCodigo.Text = PModel.Codigo;
                CargarProducto(PModel.Codigo);
            }
            else if (eventosExterno == Evento.Nulo)
            {
                PModel = new ModelProducto();
            }
        }
        public override void cerrar()
        {
            this.Close();
        }
        public override void titulo()
        {
            if (Evento.Agragar == eventosExterno)
            {
                lblTitulo.Text = "MAESTRO DE PRODUCTO (NUEVO)";
            }
            else if (Evento.Modificar == eventosExterno)
            {
                lblTitulo.Text = "MAESTRO DE PRODUCTO (MODIFICAR)";
            }
            else
            {
                lblTitulo.Text = "MAESTRO DE PRODUCTO (CONSULTA)";
            }
        }

        private void MostrarGrafico(int idProducto, int idContenido)
        {
            //var LV = new LogVentas();

            //var listVentasGeneral = LV.ConsultaVentaProducto(idProducto, idContenido);

            //ArrayList fechas = new ArrayList();
            //ArrayList cantidades = new ArrayList();

            //var resultMes = (from item in listVentasGeneral.Where(d => d.FEmision.Year == DateTime.Now.Year)
            //                 group item by item.Mes into g
            //                 select new
            //                 {
            //                     Mes = g.Key,
            //                     Cantidad = g.Sum(x => x.Cantidad),
            //                 }).ToList();
            //for (int i = 0; i < resultMes.Count; i++)
            //{
            //    fechas.Add(resultMes[i].Mes);
            //    cantidades.Add(resultMes[i].Cantidad);
            //}

            //chVentas.Series["General"].Points.DataBindXY(fechas, cantidades);

        }
        public void CorgarPromedio(int IdProducto, int idcontenido)
        {
            //var LC = new LogUnidad();
            //var _Factor = LC.Consulta(idcontenido).Factor;

            //var DIL = new LogDetalleIngreso();
            //var d = DIL.Promedio(IdProducto);
            //decimal _Promedio = 0m;
            //if (d != null)
            //{
            //    decimal Promedio = d.Promedio;
            //    decimal Factor = d.Factor;
            //    _Promedio = (Promedio * _Factor) / Factor;
            //}
            //txtCostoPromedio.Text = string.Format("{0:0.0000}", _Promedio);
        }
        private void CargarProducto(string codigo)
        {
            if (validar(codigo))
            {
                string[] texto = codigo.Trim().Split('.');

                int idCategoria = Convert.ToInt32(texto[0]);
                int serie2 = Convert.ToInt32(texto[1]);
                int idColor = Convert.ToInt32(texto[2]);
                try
                {
                    CargaUnidad(idCategoria);
                    //Editar desde la estructura o editar desde la consulta
                    if (eventosExterno == Evento.Modificar || eventosExterno == Evento.Nulo)
                    {
                        listProducto = LP.Consulta(idCategoria, serie2, idColor);

                        if (listProducto.Count > 0)
                        {
                            PModel = listProducto[0];
                            txtCategoria.Text = PModel.Categoria;
                            txtFamilia.Text = PModel.Familia;
                            txtDescripcion.Text = PModel.Descripcion;
                            ////Cargar la lista de unidades del producto
                            //listProductoUnidad = LPU.Listar(PModel.IdProducto,null);
                            //listProductoUnidad = LPU.Listar();
                            CargarModelo(listProducto);
                        }
                        else
                        {
                            LabelMessage.Mensaje(timer1, lblError, "Sistema", "Este codigo no existe", Color.Red);
                            txtCodigo.Focus();
                            Cancelar();
                        }
                    }
                    //Nuevo registro
                    else if (eventosExterno == Evento.Agragar)
                    {
                        txtCategoria.Text = PModel.Categoria;
                        txtDescripcion.Text = PModel.Descripcion;
                        txtFamilia.Text = PModel.Familia;

                        var munidad = listUnidades.Find(d => d.IdUnidad == d.IdUnidadMinima);
                        if (munidad != null)
                        {
                            string unidadminima = munidad.AUnidad;
                            int idUnidad = munidad.IdUnidad;

                            int iddescrip1 = PModel.IdDescrip1;
                            int iddescrip2 = PModel.IdDescrip2;
                            dgvModelo.Rows.Add("", unidadminima, 0, true, 0, idUnidad, true, false, serie2, iddescrip1, iddescrip2, idColor);
                            //dgvModelo.Columns["unidad"].ReadOnly = true;
                        }
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LabelMessage.Mensaje(timer1, lblError, "Sistema", "Este codigo no es correcto", Color.Red);
                txtCodigo.Focus();
            }
        }
        private void CargarModelo(List<ModelProducto> list)
        {
            try
            {
                dgvModelo.Rows.Clear();
                for (int i = 0; i < list.Count; i++)
                {
                    var p = list[i];
                    var lisPU = LPU.Listar(p.IdProducto, null);
                    for (int j = 0; j < lisPU.Count; j++)
                    {
                        listProductoUnidad.Add(lisPU[j]);
                    }
                    dgvModelo.Rows.Add(p.Modelo, p.Unidad, p.Peso, p.Estado, p.IdProducto, p.IdUnidad, p.Nuevo, p.Edicion, p.Serie2, p.IdDescrip1, p.IdDescrip2, p.IdColor);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUnidades(List<ModelProductoUnidad> lista, string modelo, decimal pesoBase)
        {
            try
            {
                List<ModelProductoUnidad> _lista = lista.Where(a => a.Modelo == modelo).ToList();
                dgvUnidad.Rows.Clear();
                for (int i = 0; i < _lista.Count; i++)
                {
                    _lista[i].PesoMin = pesoBase;
                    AgregarFilas(_lista[i], listUnidades);
                }
            }
            catch (InvalidOperationException)
            {

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void CargarAlmacen(int idUsuario)
        {
            try
            {
                var LA = new LogAlmacen();
                listAlmacen = LA.Listar(null, null);
                //for (int i = 0; i < listAlmacen.Count; i++)
                //{
                //    dgvAlmacen.Columns.Add(new DataGridViewCheckBoxColumn()
                //    {
                //        Name = listAlmacen[i].IdAlmacen.ToString(),
                //        HeaderText = listAlmacen[i].Nombre
                //    });
                //}
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDisponibleProducto(int idProducto, int idunidad)
        {
            dgvEstado.Rows.Clear();
            if (idProducto > 0)
            {
                //Solicitar el factor de la unidad (idcontenido) para multiplicar o dividir segun el caso para opterner resultados
                var LP = new LogProducto();
                var LC = new LogUnidad();
                var factor = LC.Consulta(idunidad).Factor;
                var list = LP.ListarEstados(idProducto, factor);
                var listSuma = list.Where(e => e.Movimiento == 1 && e.Direccion);//(1)(1)
                var LstGrupoSumado = listSuma.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listResta = list.Where(e => e.Movimiento == 1 && !e.Direccion);//(1)(0)
                var LstGrupoRestado = listResta.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listSeparado = list.Where(e => e.Movimiento == 2); //(2)(0)
                var LstGrupoSeparado = listSeparado.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listComprometidos = list.Where(e => e.Movimiento == 3); //(3)(0)
                var LstGrupoComprometidos = listComprometidos.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listDispoSuma = list.Where(e => e.Movimiento == 4 && e.Direccion); //(4)(1) => malogrados,mostrario,retenido 
                var LstGrupoDispoSuma = listDispoSuma.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listDispoResta = list.Where(e => e.Movimiento == 4 && !e.Direccion);//(4)(0) => malogrados,mostrario,retenido
                var LstGrupoDispoResta = listDispoResta.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();


                for (int i = 0; i < listAlmacen.Count(); i++)
                {
                    decimal Disponible = 0;
                    int idAlmacenS = listAlmacen[i].IdAlmacen;
                    decimal SumaStock = 0, RestaS = 0, Separado = 0, Compromedidos = 0, SumaTI = 0, RestaTI = 0;
                    decimal Stock = 0, TI = 0;
                    if (LstGrupoSumado.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        SumaStock = LstGrupoSumado.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    if (LstGrupoRestado.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        RestaS = LstGrupoRestado.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    Stock = SumaStock - RestaS;
                    if (LstGrupoSeparado.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        Separado = LstGrupoSeparado.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    if (LstGrupoComprometidos.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        Compromedidos = LstGrupoComprometidos.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    if (LstGrupoDispoSuma.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        SumaTI = LstGrupoDispoSuma.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    if (LstGrupoDispoResta.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        RestaTI = LstGrupoDispoResta.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }

                    TI = SumaTI - RestaTI;
                    //Stock
                    //Disponible
                    //Comprometido
                    //Separado
                    Disponible = Stock - Separado - Compromedidos + TI;

                    if (Disponible != 0)
                    {
                        dgvEstado.Rows.Add(listAlmacen[i].Nombre, decimal.Round(Stock, 4), decimal.Round(Disponible, 4), decimal.Round(Compromedidos, 4), decimal.Round(Separado, 4));
                    }
                }
                dgvEstado.ClearSelection();
            }

        }
        private void CargarCompras(int idProducto, int idUnidad)
        {
            dgvCompra.Rows.Clear();
            if (idProducto > 0)
            {
                //Solicitar el factor de la unidad (idcontenido) para multiplicar o dividir segun el caso para opterner resultados
                var LP = new LogProducto();
                var LU = new LogUnidad();
                var factor = LU.Consulta(idUnidad).Factor;
                var list = LP.ListaCompra(idProducto, factor);
                for (int i = 0; i < list.Count; i++)
                {
                    var row = list[i];
                    dgvCompra.Rows.Add(row.IdIngreso, row.Fecha, row._Cantidad, row.Unidad, row.Moneda, row._Costo, row.TCambio, row.Almacen, row.Documento, row.Proveedor);
                }
                dgvCompra.ClearSelection();
            }

        }
        private void AgregarFilas(ModelProductoUnidad pum, List<ModelUnidad> listNueva)
        {
            dgvUnidad.Rows.Add(pum.IdProductoUnidad, pum.IdUnidadMinima, pum.IdProducto, pum.IdUnidad, pum.Modelo, null, pum.Factor, pum.PContado, pum.DescContado, pum.PCredito, pum.DescCredito, pum.Factor*pum.PesoMin, pum.UnidadBase, pum.Estado, pum.Nuevo, pum.Editar);

            DataGridViewComboBoxCell comboboxCell = dgvUnidad.Rows[dgvUnidad.Rows.Count - 1].Cells["unidad"] as DataGridViewComboBoxCell;
            comboboxCell.DataSource = listNueva;
            comboboxCell.DisplayMember = "AUnidad";
            comboboxCell.ValueMember = "IdUnidad";
            comboboxCell.Value = pum.IdUnidad;
        }
        private void add_itemsModelos(AutoCompleteStringCollection sc)
        {
            var lista = listUnidades.Where(s => s.Bilateral).ToList();
            if (lista.Count > 0)
            {
                string[] listaruc = new string[lista.Count];
                for (int i = 0; i < lista.Count; i++)
                {
                    listaruc[i] = lista[i].AUnidad;
                }
                sc.AddRange(listaruc);
            }
        }
        private void Grabar()
        {
            if (listProducto.Count > 0)
            {
                var listaModeloNuevo = listProducto.Where(s => s.Nuevo).ToList();
                var listaModeloEdicion = listProducto.Where(s => s.Edicion).ToList();
                var listaUnidadNuevoNuevo = listProductoUnidad.Where(s => s.Nuevo && s.IdProducto == 0).ToList();
                var listaUnidadEdicionNuevo = listProductoUnidad.Where(s => s.Nuevo && s.IdProducto > 0).ToList();
                var listaUnidadEdicion = listProductoUnidad.Where(s => s.Editar && !s.Nuevo).ToList();
                string mensaje = "OK";
                //Si el modelo es nuevo
                if (listaModeloNuevo.Count > 0)
                {
                    for (int i = 0; i < listaModeloNuevo.Count; i++)
                    {
                        try
                        {
                            //13.42
                            //Registra modelos nuevos
                            var p = listaModeloNuevo[i];
                            mensaje = LP.Registrar(p);
                            if (mensaje == "1")
                            {
                                try
                                {
                                    var _listaProductoUnidad = listaUnidadNuevoNuevo.Where(e => e.Modelo == p.Modelo).ToList();
                                    //Si no se definió la unidad basa
                                    if (!_listaProductoUnidad.Exists(s => s.UnidadBase))
                                    {
                                        //Define la unidad base a la unidad minima por defecto
                                        _listaProductoUnidad[0].UnidadBase = true;
                                    }
                                    //Registro masivo unidades
                                    LPU.Registrar(_listaProductoUnidad, p.IdProducto);
                                    mensaje = "OK";
                                }
                                catch (Exception e)
                                {
                                    mensaje = e.Message;
                                    // break;
                                }
                            }
                            else
                            {
                                MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            mensaje = ex.Message;
                        }
                    }
                }
                //Si el modelo tiene cambios
                if (listaModeloEdicion.Count > 0)
                {
                    for (int i = 0; i < listaModeloEdicion.Count; i++)
                    {
                        try
                        {
                            mensaje = LP.Modificar(listaModeloEdicion[i]);
                            if (mensaje == "1")
                            {
                                mensaje = "OK";
                            }
                        }
                        catch (Exception e)
                        {
                            mensaje = e.Message;
                        }
                    }
                }
                //Si el modelo ya existe pero la unidad es nueva
                if (listaUnidadEdicionNuevo.Count > 0)
                {
                    try
                    {
                        if (!listProductoUnidad.Exists(e => e.UnidadBase))
                        {
                            listaUnidadEdicionNuevo[0].UnidadBase = true;
                        }
                        LPU.Registrar(listaUnidadEdicionNuevo, listaUnidadEdicionNuevo[0].IdProducto);//Carga masiva
                        mensaje = "OK";
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                //Si las unidades tubieron cambios
                if (listaUnidadEdicion.Count > 0)
                {
                    if (!listProductoUnidad.Exists(e => e.UnidadBase))
                    {
                        listaUnidadEdicion[0].UnidadBase = true;
                    }
                    for (int i = 0; i < listaUnidadEdicion.Count; i++)
                    {
                        try
                        {
                            mensaje = LPU.Modificar(listaUnidadEdicion[i]);
                            if (mensaje == "1")
                            {
                                mensaje = "OK";
                            }
                        }
                        catch (Exception e)
                        {
                            mensaje = e.Message;
                        }

                    }
                }
                if (mensaje == "OK")
                {
                    MessageBox.Show("Los cambios se guardaron correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (eventosExterno != Evento.Nulo)
                    {
                        cerrar();
                    }
                    else
                    {
                        listProductoUnidad = new List<ModelProductoUnidad>();
                        listProducto = new List<ModelProducto>();
                        CargarProducto(txtCodigo.Text);
                    }
                }
                else
                {
                    MessageBox.Show(mensaje, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay una lista para guardar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Cancelar()
        {
            listProductoUnidad = new List<ModelProductoUnidad>();
            listProducto = new List<ModelProducto>();
            CargarModelo(listProducto);
            DataGridViewComboBoxColumn comboboxColumn = dgvUnidad.Columns["Unidad"] as DataGridViewComboBoxColumn;
            CargarUnidades(listProductoUnidad, "", 0);
            dgvCompra.Rows.Clear();
            txtFamilia.Clear();
            txtCostoPromedio.Clear();
            txtCategoria.Clear();
            txtDescripcion.Clear();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
        }
        private void BorrarUnidad()
        {
            string modelo = dgvModelo.CurrentRow.Cells[ColProducto.Modelo.ToString()].Value.ToString();
            decimal pesoBase = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);
            string idUnidad = dgvUnidad.CurrentRow.Cells[ColUnidad.IdUnidad.ToString()].Value.ToString();
            ModelProductoUnidad _Exist = null;
            if (listProductoUnidad.Exists(s => s.Modelo == modelo && s.IdUnidad == Convert.ToInt32(idUnidad)))
            {
                _Exist = listProductoUnidad.Where(s => s.Modelo == modelo && s.IdUnidad == Convert.ToInt32(idUnidad)).FirstOrDefault();
                listProductoUnidad.Remove(_Exist);
                DataGridViewComboBoxColumn comboboxColumn = dgvUnidad.Columns["Unidad"] as DataGridViewComboBoxColumn;
                CargarUnidades(listProductoUnidad, modelo, pesoBase);
            }
        }
        private bool validar(string text)
        {
            //txtCodigo.Text = string.Format("000.000.000");

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                string[] n = text.Split('.');
                if (n.Length == 3)
                {
                    if (n[0].Length == 3 && Convert.ToInt32(n[0]) > 0)
                    {
                        if (n[1].Length == 3 && Convert.ToInt32(n[1]) > 0)
                        {
                            if (n[2].Length == 3 && Convert.ToInt32(n[2]) > 0)
                            {
                                return true;

                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        private void CargaUnidad(int idCat)
        {
            try
            {
                listUnidades = LU.Listar(idCat);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GuardarModeloAlaLista()
        {
            listProducto = new List<ModelProducto>();
            for (int i = 0; i < dgvModelo.Rows.Count; i++)
            {
                DataGridViewRow dr = dgvModelo.Rows[i];
                if (!string.IsNullOrEmpty(dr.Cells["modelo"].Value.ToString()))
                {
                    ModelProducto mp = new ModelProducto()
                    {
                        IdProducto = Convert.ToInt32(dr.Cells["idProducto"].Value),
                        Modelo = dr.Cells["modelo"].Value.ToString(),
                        Unidad = dr.Cells["unidadMinima"].Value.ToString(),
                        Estado = Convert.ToBoolean(dr.Cells["estado"].Value),
                        Nuevo = Convert.ToBoolean(dr.Cells["nuevo"].Value),
                        Edicion = Convert.ToBoolean(dr.Cells["edicion"].Value),
                        IdUnidad = Convert.ToInt32(dr.Cells["idUnidadBase"].Value),
                        Serie2 = Convert.ToInt32(dr.Cells["serie2"].Value),
                        IdDescrip1 = Convert.ToInt32(dr.Cells["idDescripcion1"].Value),
                        IdDescrip2 = Convert.ToInt32(dr.Cells["idDescripcion2"].Value),
                        IdColor = Convert.ToInt32(dr.Cells["idColor"].Value),
                    };
                    decimal peso = 0;
                    if (dr.Cells["pesoBase"].Value != null)
                    {
                        if (!string.IsNullOrEmpty(dr.Cells["pesoBase"].Value.ToString()))
                        {
                            peso = Convert.ToDecimal(dr.Cells["pesoBase"].Value);
                        }
                    }
                    mp.Peso = peso;
                    listProducto.Add(mp);
                }
                else
                {
                    if (dgvModelo.Rows.Count > 1)
                    {
                        dgvModelo.Rows.Remove(dr);
                    }
                }
            }
        }
        private void GuardarUnidadAlaLista(string modelo, decimal pesoMin)
        {
            listProductoUnidad.RemoveAll(e => e.Modelo == modelo);
            for (int i = 0; i < dgvUnidad.Rows.Count; i++)
            {
                DataGridViewRow dr = dgvUnidad.Rows[i];
                if (!string.IsNullOrEmpty(dr.Cells["pContado"].Value.ToString()))
                {
                    ModelProductoUnidad mp = new ModelProductoUnidad()
                    {
                        IdProductoUnidad = Convert.ToInt32(dr.Cells["idProductoUnidad"].Value),
                        IdUnidadMinima = Convert.ToInt32(dr.Cells["idUnidadMinima"].Value),
                        IdProducto = Convert.ToInt32(dr.Cells["idProducto_u"].Value),
                        IdUnidad = Convert.ToInt32(dr.Cells["idUnidad"].Value),
                        Modelo = dr.Cells["modelo_u"].Value.ToString(),
                        Unidad = dr.Cells["unidad"].Value.ToString(),
                        Factor = Convert.ToDecimal(dr.Cells["factor"].Value),
                        PContado = Convert.ToDecimal(dr.Cells["pContado"].Value),
                        DescContado = Convert.ToDecimal(dr.Cells["descContado"].Value),
                        PCredito = Convert.ToDecimal(dr.Cells["pCredito"].Value),
                        DescCredito = Convert.ToDecimal(dr.Cells["descCredito"].Value),
                        PesoMin = pesoMin,
                        UnidadBase = Convert.ToBoolean(dr.Cells["unidadDefecto"].Value),
                        Estado = Convert.ToBoolean(dr.Cells["estado_u"].Value),
                        Nuevo = Convert.ToBoolean(dr.Cells["nuevo_u"].Value),
                        Editar = Convert.ToBoolean(dr.Cells["editar_u"].Value)
                    };
                    DataGridViewComboBoxCell comboboxCell = dgvUnidad.Rows[i].Cells["unidad"] as DataGridViewComboBoxCell;
                    mp.IdUnidad = (int)comboboxCell.Value;
                    listProductoUnidad.Add(mp);
                }
                else
                {
                    dgvUnidad.Rows.Remove(dr);
                }
            }
        }
        private void AgergarUnidadSinUnidad()
        {
            if (dgvModelo.CurrentRow.Cells["modelo"].Value != null)
            {
                string modelo = dgvModelo.CurrentRow.Cells["modelo"].Value.ToString();
                int idUnidadBase = Convert.ToInt32(dgvModelo.CurrentRow.Cells["idUnidadBase"].Value);
                int idproducto = Convert.ToInt32(dgvModelo.CurrentRow.Cells["idproducto"].Value);
                decimal peso = 0;
                if (dgvModelo.CurrentRow.Cells["pesoBase"].Value != null)
                {
                    if (!string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["pesoBase"].Value.ToString()))
                    {
                        peso = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);
                    }
                }
                List<ModelUnidad> listaUsada = new List<ModelUnidad>();

                for (int i = 0; i < listUnidades.Count; i++)
                {
                    listaUsada.Add(listUnidades[i]);
                }
                for (int i = 0; i < dgvUnidad.Rows.Count; i++)
                {
                    var r = dgvUnidad.Rows[i];

                    int idUnidad = Convert.ToInt32(r.Cells["idUnidad"].Value);

                    var u = listUnidades.Find(e => e.IdUnidad == idUnidad);
                    listaUsada.Remove(u);
                }
                int idproductounidad = 0;
                int idunidad = 0;
                if (listaUsada.Count > 0)
                {
                    if (listaUsada.Exists(s => s.IdUnidad == idUnidadBase))
                    {
                        idunidad = idUnidadBase;
                    }
                    else
                    {
                        idunidad = listaUsada[0].IdUnidad;
                    }
                    dgvUnidad.Rows.Add(idproductounidad, idUnidadBase, idproducto, idunidad, modelo, null, 0, 0, 0, 0, 0, peso, false, true, true, false);
                    DataGridViewComboBoxCell comboboxCell = dgvUnidad.Rows[dgvUnidad.Rows.Count - 1].Cells["unidad"] as DataGridViewComboBoxCell;
                    comboboxCell.DisplayMember = "AUnidad";
                    comboboxCell.ValueMember = "IdUnidad";
                    comboboxCell.DataSource = listaUsada;
                    comboboxCell.Value = idunidad;
                }
            }
        }
        public void RecivirDatosProducto(string Codigo, string Modelo)
        {
            txtCodigo.Text = Codigo;
            listProductoUnidad = new List<ModelProductoUnidad>();
            listProducto = new List<ModelProducto>();
            CargarProducto(Codigo);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }
        private void btnCancelr_Click(object sender, EventArgs e)
        {
            if (listProductoUnidad.Count > 0)
            {
                if (eventosExterno == Evento.Nulo)
                {
                    Cancelar();
                }
                else
                {
                    cerrar();
                }
            }
        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listProductoUnidad = new List<ModelProductoUnidad>();
                listProducto = new List<ModelProducto>();
                CargarProducto(txtCodigo.Text);
            }
            else if (e.KeyCode == Keys.F9)
            {
                ConsultaProducto frm = new ConsultaProducto();
                frm.pasado += new ConsultaProducto.Pasar(RecivirDatosProducto);
                frm.Owner = this;
                frm.Show();
            }
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Formatos.FormatCodigo(ref txtCodigo);
        }

        private void dgvModelo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvModelo.SelectedRows.Count > 0)
            {
                if (Convert.ToBoolean(dgvModelo.CurrentRow.Cells["edicion"].Value))
                {
                    dgvModelo.Rows[dgvModelo.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                else
                {
                    dgvModelo.Rows[dgvModelo.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(2, 115, 206);
                }
                string modelo = "";
                decimal pesoBase = 0;
                if (dgvModelo.CurrentRow != null)
                {
                    if (dgvModelo.CurrentRow.Cells["modelo"].Value != null)
                    {
                        modelo = dgvModelo.CurrentRow.Cells["modelo"].Value.ToString();
                        pesoBase = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);
                        if (dgvUnidad.SelectedRows.Count > 0)
                        {
                            if (dgvUnidad.CurrentRow != null)
                            {
                                //Mostrar los estadoes del producto
                                //int idUnidad = Convert.ToInt32(dgvUnidad.CurrentRow.Cells["u_idcontenido"].Value);
                                //CargarDisponibleProducto(idProducto, idUnidad);
                            }
                            else
                                dgvEstado.Rows.Clear();
                        }
                        else
                            dgvEstado.Rows.Clear();
                    }
                    CargarUnidades(listProductoUnidad, modelo, pesoBase);
                    if (dgvUnidad.Rows.Count > 0)
                    {
                        dgvUnidad.CurrentCell = dgvUnidad.Rows[0].Cells["pContado"];
                    }
                }
                else
                    dgvEstado.Rows.Clear();
            }
            else
                dgvEstado.Rows.Clear();
        }
        private void dgvModelo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                if (dgvModelo.CurrentRow.Index == dgvModelo.Rows.Count - 1 && dgvModelo.CurrentRow.Cells["modelo"].Value != null)
                {
                    if (!string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["modelo"].Value.ToString()))
                    {
                        var unidad = listUnidades.Find(d => d.IdUnidad == d.IdUnidadMinima);//La unidad minima es igual a la unidad contenida
                        string unidadminima = unidad.AUnidad;
                        int idUnidad = unidad.IdUnidad;

                        int serie2 = PModel.Serie2;
                        int idDescrip1 = PModel.IdDescrip1;
                        int idDescrip2 = PModel.IdDescrip2;
                        int idColor = PModel.IdColor;
                        //        Modelo, UnidadMinima, Peso, Estado, IdProducto, IdContenido, Nuevo
                        dgvModelo.Rows.Add("", unidadminima, 0, true, 0, idUnidad, true, false, serie2, idDescrip1, idDescrip2, idColor);
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvModelo.Rows.Count > 1)
                {
                    if (dgvModelo.CurrentRow.Index == dgvModelo.Rows.Count - 1 && dgvModelo.CurrentRow.Cells["modelo"].Value == null)
                    {
                        dgvModelo.Rows.Remove(dgvModelo.CurrentRow);
                    }
                    else if (string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["modelo"].Value.ToString()))
                    {
                        dgvModelo.Rows.Remove(dgvModelo.CurrentRow);
                    }
                }
            }
        }
        private void dgvModelo_Leave(object sender, EventArgs e)
        {
            GuardarModeloAlaLista();
        }
        private void dgvModelo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // dgvUnidad.Rows.Add();
        }
        private void dgvModelo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Type type = e.Control.GetType();
            if (type.BaseType.Name.ToLower() == "TextBox".ToLower())
            {
                int columna = dgvModelo.CurrentCell.ColumnIndex;
                TextBox textBox = e.Control as TextBox;
                textBox.KeyPress -= new KeyPressEventHandler(dgvModelo_CellKeypress);
                textBox.KeyPress += new KeyPressEventHandler(dgvModelo_CellKeypress);

                if (textBox != null)
                {
                    if (columna == dgvModelo.Columns["modelo"].Index)
                    {
                        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
                        add_itemsModelos(sc);
                        textBox.AutoCompleteCustomSource = sc;

                    }
                    else
                    {
                        textBox.AutoCompleteMode = AutoCompleteMode.None;
                        textBox.AutoCompleteSource = AutoCompleteSource.None;
                    }
                }

            }
        }
        private void dgvModelo_CellKeypress(object sender, KeyPressEventArgs e)
        {
            int columna = dgvModelo.CurrentCell.ColumnIndex;
            if (columna == dgvModelo.Columns["pesoBase"].Index)
            {
                Validaciones.NumeroDecimal(e, (TextBox)sender);
                //ValidarMayuscula(e);
            }
        }
        private void dgvModelo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvModelo.Columns["modelo"].Index)
            {
                //Si la Casilla ya tenia datos y salgo borrandolo, devuelve el mismo valor
                if (dgvModelo.CurrentCell.Value == null)
                {
                    dgvModelo.CurrentCell.Value = modeloTemporal;
                }
                //Si la casilla fue modificado
                else if (modeloTemporal != dgvModelo.CurrentCell.Value.ToString())
                {
                    //Pero si la casilla es nueva y fue modificado no considera como modificado
                    if (!Convert.ToBoolean(dgvModelo.CurrentRow.Cells["Nuevo"].Value))
                    {
                        dgvModelo.CurrentRow.Cells["edicion"].Value = true;
                        dgvModelo.CurrentRow.DefaultCellStyle.BackColor = Color.Orange;
                        dgvModelo.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                    }
                }
            }
            //SI EL PESO BASE SE MODIFICA CAMBIA LOS DE LAS UNIDADES
            if (e.ColumnIndex == dgvModelo.Columns["pesoBase"].Index)
            {
                if (dgvUnidad.Rows.Count > 0)
                {
                    if (dgvModelo.SelectedRows.Count > 0)
                    {
                        if (dgvModelo.CurrentRow.Cells["modelo"].Value != null)
                        {
                            if (!string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["modelo"].Value.ToString()))
                            {
                                if (dgvModelo.CurrentRow.Cells["pesoBase"].Value != null && !string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["pesoBase"].Value.ToString()))
                                {
                                    //Si la Casilla ya tenia datos y salgo borrandolo, devuelve el mismo valor
                                    if (dgvModelo.CurrentCell.Value == null)
                                    {
                                        dgvModelo.CurrentCell.Value = modeloTemporal;
                                    }
                                    //Si la casilla fue modificado
                                    else if (modeloTemporal != dgvModelo.CurrentCell.Value.ToString())
                                    {
                                        //Pero si la casilla es nueva y fue modificado no considera como modificado
                                        if (!Convert.ToBoolean(dgvModelo.CurrentRow.Cells["Nuevo"].Value))
                                        {
                                            dgvModelo.CurrentRow.Cells["edicion"].Value = true;
                                            dgvModelo.CurrentRow.DefaultCellStyle.BackColor = Color.Orange;
                                            dgvModelo.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                                        }
                                    }
                                    string modelo = dgvModelo.CurrentRow.Cells["modelo"].Value.ToString();
                                    decimal pesoMin = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);

                                    CargarUnidades(listProductoUnidad, modelo, pesoMin);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void dgvModelo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvModelo.CurrentCell.Value != null)
            {
                modeloTemporal = dgvModelo.CurrentCell.Value.ToString();
                //Pero si la casilla es nueva y fue modificado no considera como modificado
                if (!Convert.ToBoolean(dgvModelo.CurrentRow.Cells["Nuevo"].Value))
                {
                    dgvModelo.CurrentRow.Cells["edicion"].Value = true;
                    dgvModelo.CurrentRow.DefaultCellStyle.BackColor = Color.Orange;
                    dgvModelo.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
        }
        private void dgvModelo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvModelo.IsCurrentCellDirty)
            {
                dgvModelo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            //dgvUnidad.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvUnidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUnidad.Columns["unidadDefecto"].Index)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvUnidad.Rows[e.RowIndex].Cells[dgvUnidad.Columns["unidadDefecto"].Index];
                cell.Value = true;
                radioButtonChanged();
            }
        }
        private void dgvUnidad_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex != dgvUnidad.Columns["unidad"].Index && e.ColumnIndex != dgvUnidad.Columns["pContado"].Index)
            {
                return;
            }
            //if (dgvUnidad.CurrentRow.Cells["unidad"].ColumnIndex == e.ColumnIndex)
            //{
            //    dgvUnidad.BeginEdit(true);
            //}
        }
        private void dgvUnidad_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvUnidad.Columns["unidadDefecto"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                // TODO: The radio button flickers on mouse over.
                // I tried setting DoubleBuffered on the parent panel, but the flickering persists.
                // If someone figures out how to resolve this, please leave a comment.

                Rectangle rectRadioButton = new Rectangle();
                // TODO: Would be nice to not use magic numbers here.
                rectRadioButton.Width = 14;
                rectRadioButton.Height = 14;
                rectRadioButton.X = e.CellBounds.X + (e.CellBounds.Width - rectRadioButton.Width) / 2;
                rectRadioButton.Y = e.CellBounds.Y + (e.CellBounds.Height - rectRadioButton.Height) / 2;

                ButtonState buttonState;
                if (e.Value == DBNull.Value || (bool)(e.Value) == false)
                {
                    buttonState = ButtonState.Normal;
                }
                else
                {
                    buttonState = ButtonState.Checked;
                }
                ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, buttonState);

                e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus);

                e.Handled = true;
            }
        }
        private void dgvUnidad_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;
            //Verificar si la casilla es ComboBox
            if (dgvCombo != null)
            {
                //
                // se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
                // evitando asi que se ejecuten varias veces el evento
                //
                dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);
                dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            }
        }
        private void dgvUnidad_Click(object sender, EventArgs e)
        {
            if (dgvModelo.SelectedRows.Count > 0 && dgvUnidad.Rows.Count < 1)
            {
                AgergarUnidadSinUnidad();
            }
        }
        private void dgvUnidad_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            radioButtonChanged();
            if (dgvUnidad.IsCurrentCellDirty)
            {
                dgvUnidad.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            //dgvUnidad.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvUnidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (!string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["modelo"].Value.ToString()))
                {
                    if (dgvUnidad.CurrentRow == dgvUnidad.Rows[dgvUnidad.Rows.Count - 1])
                    {
                        AgergarUnidadSinUnidad();
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgvUnidad.CurrentRow.Index == dgvUnidad.Rows.Count - 1 && (Convert.ToDecimal(dgvUnidad.CurrentRow.Cells["pContado"].Value) < 1 || Convert.ToDecimal(dgvUnidad.CurrentRow.Cells["pCredito"].Value) < 1))
                {
                    dgvUnidad.Rows.Remove(dgvUnidad.CurrentRow);
                }
            }
        }
        private void dgvUnidad_Leave(object sender, EventArgs e)
        {
            if (dgvModelo.SelectedRows.Count > 0 && dgvUnidad.RowCount > 0)
            {
                decimal pesoMin = 0;
                string modelo = dgvModelo.CurrentRow.Cells["modelo"].Value.ToString();
                if (dgvModelo.CurrentRow.Cells["pesoBase"].Value != null)
                    if (!string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["pesoBase"].Value.ToString()))
                        pesoMin = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);

                GuardarUnidadAlaLista(modelo, pesoMin);
            }
        }
        private void dgvUnidad_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvUnidad.Columns["factor"].Index)
            {
                DataGridViewRow row = dgvUnidad.CurrentRow;
                decimal factor = Convert.ToDecimal(row.Cells["factor"].Value);
                decimal peso_minima = 0;
                if (dgvModelo.CurrentRow.Cells["pesoBase"].Value != null && !string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["pesoBase"].Value.ToString()))
                {
                    peso_minima = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);
                }
                row.Cells["peso"].Value = peso_minima * factor;

            }
            if (e.ColumnIndex != dgvUnidad.Columns["unidadDefecto"].Index)
            {
                if (unidadTemporal != null)
                {
                    //Si la Casilla ya tenia datos y salgo borrandolo, devuelve el mismo valor
                    if (dgvUnidad.CurrentCell.Value == null)
                    {
                        dgvUnidad.CurrentCell.Value = unidadTemporal;
                    }
                    //Si la casilla fue modificado
                    else if (unidadTemporal != dgvUnidad.CurrentCell.Value.ToString())
                    {
                        //Pero si la casilla es nueva y fue modificado no considera como modificado
                        if (!Convert.ToBoolean(dgvUnidad.CurrentRow.Cells["nuevo_u"].Value))
                        {
                            dgvUnidad.CurrentRow.Cells["editar_u"].Value = true;
                            //dgvUnidad.CurrentRow.DefaultCellStyle.BackColor = System.Drawing.Color.Orange;
                            dgvUnidad.CurrentRow.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Orange;
                        }
                    }
                }
            }
        }
        private void dgvUnidad_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvUnidad.CurrentCell.Value != null)
            {
                unidadTemporal = dgvUnidad.CurrentCell.Value.ToString();
                
                //Pero si la casilla es nueva y fue modificado no considera como modificado
                if (!Convert.ToBoolean(dgvUnidad.CurrentRow.Cells["nuevo_u"].Value))
                {
                    dgvUnidad.CurrentRow.Cells["editar_u"].Value = true;
                    dgvUnidad.CurrentRow.DefaultCellStyle.BackColor = Color.Orange;
                    dgvUnidad.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
        }
        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            DataGridViewRow row = dgvUnidad.CurrentRow;
            if (combo.SelectedValue != null)
            {
                int idunidad;
                if (Int32.TryParse(combo.SelectedValue.ToString(), out idunidad))
                {
                    row.Cells["idUnidad"].Value = idunidad;
                    decimal factor = Convert.ToDecimal(row.Cells["factor"].Value);
                    decimal peso_minima = 0;
                    if (dgvModelo.CurrentRow.Cells["pesoBase"].Value != null && !string.IsNullOrEmpty(dgvModelo.CurrentRow.Cells["pesoBase"].Value.ToString()))
                    {
                        peso_minima = Convert.ToDecimal(dgvModelo.CurrentRow.Cells["pesoBase"].Value);
                    }
                    row.Cells["peso"].Value = peso_minima * factor;
                }
            }
        }
        private void dgvUnidad_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvModelo.SelectedRows.Count > 0)
            {
                if (dgvModelo.CurrentRow != null)
                {
                    if (dgvModelo.CurrentRow.Cells["modelo"].Value != null)
                    {
                        int idProducto = Convert.ToInt32(dgvModelo.CurrentRow.Cells["IdProducto"].Value);
                        if (dgvUnidad.SelectedRows.Count > 0)
                        {
                            if (dgvUnidad.CurrentRow != null)
                            {
                                int idcontenido = Convert.ToInt32(dgvUnidad.CurrentRow.Cells["u_idcontenido"].Value);
                                CargarDisponibleProducto(idProducto, idcontenido);
                                CargarCompras(idProducto, idcontenido);
                                CorgarPromedio(idProducto, idcontenido);
                                MostrarGrafico(idProducto, idcontenido);
                            }
                            else
                                dgvEstado.Rows.Clear();
                        }
                        else
                            dgvEstado.Rows.Clear();
                    }
                    else
                        dgvEstado.Rows.Clear();
                }
                else
                    dgvEstado.Rows.Clear();
            }
            else
                dgvEstado.Rows.Clear();
        }
        private void dgvUnidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // Detecta si se ha seleccionado el header de la grilla
            //
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex != dgvUnidad.Columns["unidadDefecto"].Index)
            {

                //
                // Se toma la fila seleccionada
                //
                DataGridViewRow row = dgvUnidad.Rows[e.RowIndex];

                //
                // Se selecciona la celda del checkbox
                //
                DataGridViewCheckBoxCell cellSelecion = row.Cells["unidadDefecto"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                    row.DefaultCellStyle.BackColor = Color.Green;
                else
                    row.DefaultCellStyle.BackColor = Color.White;

            }
        }



        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUnidad.SelectedRows.Count > 0)
            {
                if (Convert.ToBoolean(dgvUnidad.CurrentRow.Cells["Nuevo"].Value))
                {
                    BorrarUnidad();
                }
                else
                {
                    string mensaje = "";
                    if (DialogResult == MessageBox.Show("Estas seguro de Borar esta fila", "Confirmar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        mensaje = LPU.Eliminar(Convert.ToInt32(dgvUnidad.CurrentRow.Cells[ColProductoUnidad.IdProductoUnidad.ToString()].Value), Convert.ToBoolean(dgvUnidad.CurrentRow.Cells[ColProductoUnidad.Estado.ToString()].Value));
                        if (mensaje == "1")
                        {
                            BorrarUnidad();
                        }
                    }
                }
            }
        }
        private void Menu_Opening(object sender, CancelEventArgs e)
        {

        }
        private void radioButtonChanged()
        {
            if (dgvUnidad.CurrentCell.ColumnIndex == dgvUnidad.Columns["unidadDefecto"].Index)
            {
                foreach (DataGridViewRow row in dgvUnidad.Rows)
                {
                    // Make sure not to uncheck the radio button the user just clicked.
                    if (row.Index != dgvUnidad.CurrentCell.RowIndex)
                    {
                        if (Convert.ToBoolean(row.Cells["unidadDefecto"].Value))
                        {
                            row.Cells["editar_u"].Value = true;
                        }
                        row.Cells["unidadDefecto"].Value = false;
                    }
                }
            }
        }

    }
}
