namespace LOGICA.Entidades.IOProducto
{
    public class DetalleOCompra
    {
        public int IdDetalleOCompra { get; set; }
        public int IdOCompra { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public int IdContenido { get; set; }
        public decimal PCompra { get; set; }
        public bool Estado { get; set; }
    }
}
