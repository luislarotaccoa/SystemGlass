namespace LOGICA.Entidades.Venta
{
    public class DetalleProforma
    {
        public int IdDetalleProforma { get; set; }
        public int IdProforma { get; set; }
        public int IdProducto { get; set; }
        public int IdContenido { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PUnitario { get; set; }
        public decimal Descuento { get; set; }
        public int IdAlmacen { get; set; }
        public bool Estado { get; set; }
    }
    
}
