namespace LOGICA.Entidades.IOProducto
{
    public class DetalleConsumo
    {
        public int IdDetalleConsumo { get; set; }
        public int IdConsumo { get; set; }
        public int IdProducto { get; set; }
        public int IdContenido { get; set; }
        public decimal Cantidad { get; set; }

    }
}
