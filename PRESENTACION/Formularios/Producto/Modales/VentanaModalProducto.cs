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

namespace PRESENTACION.Formularios.Producto.Modales
{
    public partial class VentanaModalProducto : Form
    {
        private string tabla_dgv;
        private DataGridViewRow drDatos;
        private DataGridViewRow drRelacion;
        private Evento events;

        private const string dgvCategoria = "dgvCategoria";
        private const string dgvFamilia = "dgvFamilia";
        private const string dgvDescripcion1 = "dgvDescripcion1";
        private const string dgvDescripcion2 = "dgvDescripcion2";
        private const string dgvColor = "dgvColor";

        public VentanaModalProducto()
        {
            InitializeComponent();
        }
        public VentanaModalProducto(string _tabla_dgv, DataGridViewRow _dr, DataGridViewRow _drRelacion, Evento _events)
        {
            InitializeComponent();
            tabla_dgv = _tabla_dgv;
            drDatos = _dr;
            drRelacion = _drRelacion;
            events = _events;
        }
        int posX = 0;
        int posY = 0;

        ModelCategoria MCategoria = new ModelCategoria();
        LogCategoria LC = new LogCategoria();

        ModelFamilia MFamilia = new ModelFamilia();
        LogFamilia LF = new LogFamilia();

        ModelDescrip1 MDescrip1 = new ModelDescrip1();
        LogDescrip1 LD1 = new LogDescrip1();

        ModelDescrip2 MDescrip2 = new ModelDescrip2();
        LogDescrip2 LD2 = new LogDescrip2();

        LogDescrip2Categoria LDC2 = new LogDescrip2Categoria();

        ModelColor MColor = new ModelColor();
        LogColor LCL = new LogColor();

        LogColorCategoria LCC = new LogColorCategoria();

        private List<ModelColor> listColor;
        private List<ModelDescrip2> lisD2;

        private void LblCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void ColorModal_Load(object sender, EventArgs e)
        {
            string titulo, descripcion = "";
            if (tabla_dgv == dgvCategoria)
            {
                if (events == Evento.Modificar && drDatos != null)
                {
                    titulo = "EDITAR CATEGORÍA";
                    MCategoria.IdCategoria = Convert.ToInt32(drDatos.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                    descripcion = drDatos.Cells[ColCategoria.NomCategoria.ToString()].Value.ToString();
                }
                else
                {
                    titulo = "NUEVO CATEGORÍA";
                }
            }
            else if (tabla_dgv == dgvFamilia)
            {
                if (events == Evento.Modificar && drDatos != null)
                {
                    titulo = "EDITAR FAMILIA";
                    MFamilia.IdCategoria = Convert.ToInt32(drDatos.Cells[ColFamilia.IdCategoria.ToString()].Value.ToString());
                    MFamilia.IdFamilia = Convert.ToInt32(drDatos.Cells[ColFamilia.IdFamilia.ToString()].Value.ToString());
                    descripcion = drDatos.Cells[ColFamilia.NomFamilia.ToString()].Value.ToString();
                }
                else
                {
                    titulo = "NUEVO FAMILIA PARA CATEGORÍA " + drRelacion.Cells[ColCategoria.NomCategoria.ToString()].Value.ToString();
                    MFamilia.IdCategoria = Convert.ToInt32(drRelacion.Cells[ColFamilia.IdCategoria.ToString()].Value.ToString());
                }
            }
            else if (tabla_dgv == dgvDescripcion1)
            {

                if (events == Evento.Modificar && drDatos != null)
                {
                    titulo = "EDITAR DESCRIPCION 1";
                    MDescrip1.IdFamilia = Convert.ToInt32(drDatos.Cells[ColDescrip1.IdFamilia.ToString()].Value.ToString());
                    MDescrip1.IdDescrip1 = Convert.ToInt32(drDatos.Cells[ColDescrip1.IdDescrip1.ToString()].Value.ToString());
                    descripcion = drDatos.Cells[ColDescrip1.Descripcion.ToString()].Value.ToString();
                }
                else
                {
                    titulo = "NUEVO DESCRIPCION 1 PARA FAMILIA " + drRelacion.Cells[ColFamilia.NomFamilia.ToString()].Value.ToString();
                    MDescrip1.IdFamilia = Convert.ToInt32(drRelacion.Cells[ColDescrip1.IdFamilia.ToString()].Value.ToString());
                }
            }
            //Doble proceso
            else if (tabla_dgv == dgvDescripcion2)
            {

                if (events == Evento.Modificar && drDatos != null)
                {
                    //D2.IdCategoria = Convert.ToInt32(dr.Cells[ColCategoriaDescrip2.IdCategoria].Value.ToString());
                    titulo = "EDITAR DESCRIPCION 2";
                    MDescrip2.IdDescrip2 = Convert.ToInt32(drDatos.Cells[ColDescrip2.IdDescrip2.ToString()].Value.ToString());
                    descripcion = drDatos.Cells[ColDescrip2.Descripcion.ToString()].Value.ToString();
                    txtDescripcion.AutoCompleteMode = AutoCompleteMode.None;
                    txtDescripcion.AutoCompleteSource = AutoCompleteSource.None;
                }
                else
                {
                    titulo = "NUEVO DESCRIPCION 2 PARA CATEGORÍA " + drRelacion.Cells[ColCategoria.NomCategoria.ToString()].Value.ToString();
                    MDescrip2.IdCategoria = Convert.ToInt32(drRelacion.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                    //Cargar Descripcion de descripcion 2
                    txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    CargarAutoCompleteDescrip2(MDescrip2.IdCategoria);
                }
            }
            else if (tabla_dgv == dgvColor)
            {
                if (events == Evento.Modificar && drDatos != null)
                {
                    titulo = "EDITAR COLOR";
                    MColor.IdColor = Convert.ToInt32(drDatos.Cells[ColColor.IdColor.ToString()].Value.ToString());
                    descripcion = drDatos.Cells[ColColor.NomColor.ToString()].Value.ToString();
                    txtDescripcion.AutoCompleteMode = AutoCompleteMode.None;
                    txtDescripcion.AutoCompleteSource = AutoCompleteSource.None;
                }
                else
                {
                    titulo = "NUEVO COLOR PARA CATEGORÍA " + drRelacion.Cells[ColCategoria.NomCategoria.ToString()].Value.ToString();
                    MColor.IdCategoria = Convert.ToInt32(drRelacion.Cells[ColCategoria.IdCategoria.ToString()].Value.ToString());
                    //Cargar Descripcion de Color
                    txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    CargarAutoCompleteColor(MColor.IdCategoria);
                }
            }
            else
            {
                titulo = "";
            }
            lblNombre.Text = titulo;
            txtDescripcion.Text = descripcion;
            //Location = new System.Drawing.Point(CCategoriaColor.dgvColorLocation.X * 2, MousePosition.Y);
            Location = MousePosition;
        }
        private void Label1_MouseMove(object sender, MouseEventArgs e)
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
        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {
            if (events == Evento.Agragar)
            {
                if (!string.IsNullOrEmpty(txtDescripcion.Text))
                {

                    if (tabla_dgv == dgvColor)
                    {
                        if (listColor.Exists(d => d.NomColor == txtDescripcion.Text))
                        {
                            MColor.IdColor = listColor.Find(d => d.NomColor == txtDescripcion.Text).IdColor;
                        }
                        else
                        {
                            MColor.IdColor = 0;
                        }
                    }
                    else if (tabla_dgv == dgvDescripcion2)
                    {
                        if (lisD2.Exists(d => d.Descripcion == txtDescripcion.Text))
                        {
                            MDescrip2.IdDescrip2 = lisD2.Find(d => d.Descripcion == txtDescripcion.Text).IdDescrip2;
                        }
                        else
                        {
                            MDescrip2.IdDescrip2 = 0;
                        }
                    }
                }
            }
        }
        private void CargarAutoCompleteDescrip2(int idCategoria)
        {
            try
            {
                List<ModelDescrip2> lisCatD2 = LDC2.Listar(idCategoria);
                lisD2 = LD2.Listar(null,null);
                for (int i = 0; i < lisD2.Count; i++)
                {
                    if (lisCatD2.Exists(d => d.IdDescrip2 == lisD2[i].IdDescrip2))
                    {
                        lisD2.Remove(lisD2[i]);
                    }
                }

                if (lisD2.Count > 0)
                {
                    try
                    {
                        var source = new AutoCompleteStringCollection();
                        string[] listadescrip2 = new string[lisD2.Count];
                        for (int i = 0; i < lisD2.Count; i++)
                        {
                            listadescrip2[i] = lisD2[i].Descripcion;
                        }
                        source.AddRange(listadescrip2);
                        txtDescripcion.AutoCompleteCustomSource = source;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarAutoCompleteColor(int idCategoria)
        {
            try
            {
                List<ModelColor> lisCatColor = LCC.Listar(idCategoria);
                listColor = LCL.Listar(null,null);

                for (int i = 0; i < listColor.Count; i++)
                {
                    if (lisCatColor.Exists(d => d.IdColor == listColor[i].IdColor))
                    {
                        listColor.Remove(listColor[i]);
                    }
                }

                if (listColor.Count > 0)
                {
                    try
                    {
                        var source = new AutoCompleteStringCollection();
                        string[] listacolor = new string[listColor.Count];
                        for (int i = 0; i < listColor.Count; i++)
                        {
                            listacolor[i] = listColor[i].NomColor;
                        }
                        source.AddRange(listacolor);
                        txtDescripcion.AutoCompleteCustomSource = source;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (tabla_dgv == dgvCategoria)
                    {
                        MCategoria.NomCategoria = txtDescripcion.Text;
                        m = LC.Registrar(MCategoria);
                    }
                    else if (tabla_dgv == dgvFamilia)
                    {
                        MFamilia.NomFamilia = txtDescripcion.Text;
                        m = LF.Registrar(MFamilia);
                    }
                    else if (tabla_dgv == dgvDescripcion1)
                    {
                        MDescrip1.Descripcion = txtDescripcion.Text;
                        m = LD1.Registrar(MDescrip1);
                    }
                    else if (tabla_dgv == dgvDescripcion2)
                    {
                        //Si existe la descrip2 pero aun no esta asociado
                        //=> Asignar el IdDescrip2 en un evento de txtDescripcion
                        if (MDescrip2.IdDescrip2 > 0)
                        {
                            m = LDC2.Registrar(MDescrip2);
                        }
                        //Si no existe la descrip2 y se escribe nueva Descrip2
                        //Primero Registrar descrip2, luego asociar
                        else
                        {
                            MDescrip2.Descripcion = txtDescripcion.Text;
                            m = LD2.Registrar(MDescrip2);
                            if (m == "1")
                            {
                                m = LDC2.Registrar(MDescrip2);
                            }
                        }
                    }
                    else if (tabla_dgv == dgvColor)
                    {
                        //Si existe Color pero aun no esta asociado
                        //=> Asignar el IdColor en un evento de txtDescripcion
                        if (MColor.IdColor > 0)
                        {
                            m = LCC.Registrar(MColor);
                        }
                        //Si no existe COLOR y se escribe nuevo COLOR
                        //Primero Registrar COLOR, luego asociar
                        else
                        {
                            MColor.NomColor = txtDescripcion.Text;
                            m = LCL.Registrar(MColor);
                            if (m == "1")
                            {
                                m = LCC.Registrar(MColor);
                            }
                        }
                    }
                    else
                    {
                        m = "No hay operación";
                    }

                    if (m == "1")
                    {
                        MessageBox.Show("El " + tabla_dgv + " se guardo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescripcion.Clear();
                        txtDescripcion.Focus();
                    }
                    else
                    {
                        MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case Evento.Modificar:
                    if (tabla_dgv == dgvCategoria)
                    {
                        MCategoria.NomCategoria = txtDescripcion.Text;
                        m = LC.Modificar(MCategoria);
                    }
                    else if (tabla_dgv == dgvFamilia)
                    {
                        MFamilia.NomFamilia = txtDescripcion.Text;
                        m = LF.Modificar(MFamilia);
                    }
                    else if (tabla_dgv == dgvDescripcion1)
                    {
                        MDescrip1.Descripcion = txtDescripcion.Text;
                        m = LD1.Modificar(MDescrip1);
                    }
                    else if (tabla_dgv == dgvDescripcion2)
                    {
                        MDescrip2.Descripcion = txtDescripcion.Text;
                        m = LD2.Modificar(MDescrip2);
                    }
                    else if (tabla_dgv == dgvColor)
                    {
                        MColor.NomColor = txtDescripcion.Text;
                        m = LCL.Modificar(MColor);
                    }
                    else
                    {
                        m = "No hay operación";
                    }

                    if (m == "1")
                    {
                        MessageBox.Show("El " + tabla_dgv + " se Actualizo correctamente", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(m, "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
        }
        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    btnGuardar.Focus();
                }
            }
        }
    }
}
