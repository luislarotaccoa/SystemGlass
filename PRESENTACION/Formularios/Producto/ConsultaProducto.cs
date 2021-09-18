using LOGICA.Logica.Producto;
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
    public partial class ConsultaProducto : Form
    {
        public ConsultaProducto()
        {
            InitializeComponent();
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
        }
        ModelProducto MProducto = new ModelProducto();
        LogProducto LP = new LogProducto();
        private int altura;

        public delegate void Pasar(string Codigo, string Modelo);
        public event Pasar pasado;

        private void EnviarDatos()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string Codigo = "";
                int IdCategoria = Convert.ToInt32(dgv.CurrentRow.Cells[ColCategoria.IdCategoria.ToString()].Value);
                int Serie2 = Convert.ToInt32(dgv.CurrentRow.Cells[ColProducto.Serie2.ToString()].Value);
                int IdColor = Convert.ToInt32(dgv.CurrentRow.Cells[ColProducto.IdColor.ToString()].Value);
                string Modelo = dgv.CurrentRow.Cells[ColProducto.Modelo.ToString()].Value.ToString();

                Codigo = Concatenacion.ConcatSerie(IdCategoria,Serie2,IdColor);
                pasado(Codigo, Modelo);
            }
            else
            {
                MessageBox.Show("Selecciones una fila");
            }
        }
        private void CargarProducto()
        {
            try
            {
                listProducto = LP.ListaConsulta();
                //Cargar disponibles de productos 
                //if (listProducto.Count > 0)
                //{
                //    for (int i = 0; i < listProducto.Count; i++)
                //    {
                //        listProducto[i].Saldo = DisponibleProducto(listProducto[i].IdProducto, listProducto[i].Factor);
                //    }
                //}
                dgv.DataSource = listProducto;
                ConfigDgv();
                //Buscar Productos Vendidos en dos dias (productos recientes)
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            var list = LP.Buscar(listProducto, txtBuscar.Text);
            dgv.DataSource = list;
            //if (txtBuscar.Text == "")
            //{
            //    ConfigDgv();
            //}
            int tam = (dgv.Rows.Count + 1) * 22;
            if (altura > tam)
            {
                Height = tam + 65;
            }
            else
            {
                Height = altura;
            }
        }

        private void ConfigDgv()
        {
            dgv.Columns[ColProducto.Codigo.ToString()].Width = 35;
            dgv.Columns[ColProducto.Descripcion.ToString()].Width = 80;
            dgv.Columns[ColProducto.IdProducto.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdDescrip1.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdDescrip2.ToString()].Visible = false;
            dgv.Columns[ColProducto.Descripcion1.ToString()].Visible = false;
            dgv.Columns[ColProducto.Descripcion2.ToString()].Visible = false;
            dgv.Columns[ColProducto.Serie2.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdColor.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdCategoria.ToString()].Visible = false;
            dgv.Columns[ColProducto.Categoria.ToString()].Visible = false;
            dgv.Columns[ColProducto.Familia.ToString()].Visible = false;
            dgv.Columns[ColProducto.Bilateral.ToString()].Visible = false;
            dgv.Columns[ColProducto.Color.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdUnidad.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdFamilia.ToString()].Visible = false;
            dgv.Columns[ColProducto.Factor.ToString()].Visible = false;
            dgv.Columns[ColProducto.Peso.ToString()].Visible = false;
            dgv.Columns[ColProducto.Nuevo.ToString()].Visible = false;
            dgv.Columns[ColProducto.Edicion.ToString()].Visible = false;
            dgv.Columns[ColProducto.Costo.ToString()].Visible = false;
            dgv.Columns[ColProducto.IdUnidadMinima.ToString()].Visible = false;
            dgv.Columns[ColProducto.Estado.ToString()].Visible = false;
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                EnviarDatos();
                //https://es.stackoverflow.com/questions/248279/como-desactivar-el-salto-de-fila-al-presionar-enter-en-un-datagridview-en-c
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            EnviarDatos();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgv.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    EnviarDatos();
                }
                else
                {
                    dgv.Rows[0].Selected = true;
                    dgv.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        int PosY = 0;
        int PosX = 0;
        internal static bool abierto = false;
        private List<ModelProducto> listProducto;

        private void barraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                PosX = e.X;
                PosY = e.Y;
            }
            else
            {
                Left = Left + (e.X - PosX);
                Top = Top + (e.Y - PosY);
            }
        }

        private void ConsultaProducto_Load(object sender, EventArgs e)
        {
            Location = new Point(120, 350);
            altura = Height;
            abierto = true;
            CargarAlmacen();
            CargarProducto();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            abierto = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ConsultaProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            abierto = false;
        }
        private List<ModelAlmacen> listAlmacen;
        private decimal DisponibleProducto(int idProducto, decimal factor)
        {
            decimal _Saldo = 0;
            if (idProducto > 0)
            {
                var LP = new LogProducto();
                var listDisponibleProducto = new List<ModelEstadoProducto>();
                var list = LP.Estados(idProducto, factor);

                var listSuma = list.Where(e => e.Movimiento == 1 && e.Direccion);
                var LstGrupoSumado = listSuma.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listResta = list.Where(e => e.Movimiento == 1 && !e.Direccion);
                var LstGrupoRestado = listResta.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listSeparado = list.Where(e => e.Movimiento == 2);
                var LstGrupoSeparado = listSeparado.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listComprometidos = list.Where(e => e.Movimiento == 3);
                var LstGrupoComprometidos = listComprometidos.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listDispoSuma = list.Where(e => e.Movimiento == 4 && e.Direccion);
                var LstGrupoDispoSuma = listDispoSuma.GroupBy(l => l.IdAlmacen).Select(
                    la => new
                    {
                        IdAlmacen = la.Key,
                        SumaCantidad = la.Sum(s => s.Stock)
                    }).ToList();

                var listDispoResta = list.Where(e => e.Movimiento == 4 && !e.Direccion);
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
                    decimal SumaS = 0, RestaS = 0, Separado = 0, Compromedidos = 0, SumaD = 0, RestaD = 0;
                    if (LstGrupoSumado.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        SumaS = LstGrupoSumado.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    if (LstGrupoRestado.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        RestaS = LstGrupoRestado.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
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
                        SumaD = LstGrupoDispoSuma.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    if (LstGrupoDispoResta.Find(x => x.IdAlmacen == idAlmacenS) != null)
                    {
                        RestaD = LstGrupoDispoResta.Find(x => x.IdAlmacen == idAlmacenS).SumaCantidad;
                    }
                    Disponible = (SumaS - RestaS) - Separado - Compromedidos - RestaD + SumaD;
                    if (Disponible != 0)
                    {
                        listDisponibleProducto.Add(new ModelEstadoProducto(factor) { Disponible = Disponible, IdAlmacen = listAlmacen[i].IdAlmacen });
                    }
                }
                _Saldo = listDisponibleProducto.Sum(x => x.Disponible);
            }
            return _Saldo;
        }
        private void CargarAlmacen()
        {
            try
            {
                LogAlmacen LA = new LogAlmacen();
                listAlmacen = LA.Listar(null,null);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
