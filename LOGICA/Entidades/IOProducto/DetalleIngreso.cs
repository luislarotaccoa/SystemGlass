namespace LOGICA.Entidades.IOProducto
{
    public class DetalleIngreso
    {
        public int IdDetalleIngreso { get; set; }
        public int IdIngreso { get; set; }
        public int IdDetalleOCompra { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Promedio { get; set; }
        public bool Promediado { get; set; }
    }
}
