namespace VERTICAL.Modelos.Producto
{
    public class ModelEstadoProducto
    {
        decimal xFactor;
        public ModelEstadoProducto(decimal _xFactor)
        {
            this.xFactor = _xFactor;
        }
        public int IdAlmacen { get; set; }
        public int IdUnidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Factor { get; set; }
        public virtual decimal Disponible { get; set; }
        public virtual decimal Stock { get { return (Factor * Cantidad) / xFactor; } }
        public int Movimiento { get; set; }
        public bool Direccion { get; set; }
    }
    public enum ColEstados
    {
        IdAlmacen,
        IdUnidad,
        Cantidad,
        Factor,
        Disponible,
        Movimiento,
        Direccion
    }
}
