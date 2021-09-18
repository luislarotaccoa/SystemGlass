using VERTICAL.Ayudas;

namespace VERTICAL.Modelos.Producto
{
    public class ModelProducto
    {

        public int IdProducto { get; set; }
        public int IdDescrip1 { get; set; }
        public int IdDescrip2 { get; set; }
        public int IdColor { get; set; }
        /// <summary>
        /// Unidad minima de cada producto (Su unidad contenida de esta debe ser la misma)
        /// </summary>
        public int IdUnidad { get; set; } //Unidad minima de cada producto (Su unidad contenida de esta debe ser la misma)
        public int IdCategoria { get; set; }
        public string Categoria { get; set; } //NomCategoria
        public bool Bilateral { get; set; }
        public int IdFamilia { get; set; }
        public string Familia { get; set; } //NomFamilia
        public string Descripcion1 { get; set; }
        public string Descripcion2 { get; set; }
        public int Serie2 { get; set; }
        public decimal Peso { get; set; }
        public string Color { get; set; }//NomColor
        public bool Estado { get; set; }
        public virtual string Codigo { get {return Concatenacion.ConcatSerie(IdCategoria, Serie2, IdColor); } } //000.000.000
        public virtual string Descripcion { get { return Bilateral ? Descripcion1 + " " + Color + " " + Descripcion2 : Descripcion1 + " " + Descripcion2 + " " + Color; } }
        public string Modelo { get; set; }
        public string Unidad { get; set; } //Abreviatura
        public decimal Precio { get; set; }
        public virtual bool Nuevo { get; set; }
        public virtual bool Edicion { get; set; }
        public virtual decimal Costo { get; set; }
        public virtual decimal Factor { get; set; }
        public int IdUnidadMinima { get; set; }
    }
    public enum ColProducto
    {
        IdProducto,
        IdDescrip1,
        IdDescrip2,
        IdColor,
        IdUnidad,
        Unidad,
        IdCategoria,
        Categoria,
        Bilateral,
        IdFamilia,
        Familia,
        Descripcion1,
        Descripcion2,
        Serie2,
        Modelo,
        Peso,
        Factor,
        Color,
        Estado,
        Codigo,
        Descripcion,
        Nuevo,
        Edicion,
        Costo,
        IdUnidadMinima,
        Precio
    }
    public enum ProcProducto
    {
        RegistrarProducto,
        ModificarProducto,
        EliminarProducto,
        ListarProducto,
        ConsultaProducto,
        ExisteProducto,
        ListarProductos,
        ListarEstados,
        ListarProductoConsulta
    }
}
