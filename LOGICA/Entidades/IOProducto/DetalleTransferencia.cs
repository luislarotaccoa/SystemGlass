namespace LOGICA.Entidades.IOProducto
{
    public class DetalleTransferencia
    {
        public int IdDetalleTransferencia { get; set; }
        public int IdTransferencia { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public int IdContenido { get; set; }
    }
}
