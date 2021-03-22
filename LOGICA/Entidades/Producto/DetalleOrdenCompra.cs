namespace LOGICA.Entidades.Producto
{
    public class DetalleOrdenCompra
    {
        public int IdDetalleOrdenCompra { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdProducto { get; set; }
        public int IdUnidad { get; set; } //IdContenido
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}
