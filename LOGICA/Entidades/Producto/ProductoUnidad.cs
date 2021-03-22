namespace LOGICA.Entidades.Producto
{
    public class ProductoUnidad
    {
        public int IdProductoUnidad { get; set; }
        public int IdProducto { get; set; }
        public int IdContenido { get; set; } //Unidad que se asignará para cada unidad que se cree para un determinado producto
        public decimal DescContado { get; set; }
        public decimal DescCredito { get; set; }
        public decimal PContado { get; set; }
        public decimal PCredito { get; set; }
        public bool UnidadBase { get; set; }
        public bool Estado { get; set; }
    }
 }
