namespace LOGICA.Entidades.IOProducto
{
    public class DetalleEntrega
    {
        public int IdDetalleEntrega { get; set; }
        public int IdEntrega { get; set; }
        public int IdDetalleProforma { get; set; }
        public decimal Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}
