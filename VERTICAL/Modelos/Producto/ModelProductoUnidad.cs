namespace VERTICAL.Modelos.Producto
{
    public class ModelProductoUnidad
    {
        public int IdProductoUnidad { get; set; }
        public int IdUnidad { get; set; } //Unidad que se asignará para cada unidad que se cree para un determinado producto
        public int IdProducto { get; set; }
        public string Modelo { get; set; }
        public string Unidad { get; set; }
        public decimal Factor { get; set; }
        public decimal PContado { get; set; }
        public decimal PCredito { get; set; }
        public decimal DescContado { get; set; }
        public decimal DescCredito { get; set; }
        public bool UnidadBase { get; set; }
        public int IdUnidadMinima { get; set; }
        public bool Estado { get; set; }
        public decimal PesoMin { get; set; }
        /// <summary>
        /// Peso PRODUCTO del peso de la unidad mimima por el factor de la Unidad 
        /// </summary>
        public virtual decimal Peso { get { return PesoMin * Factor; } }
        public virtual bool Nuevo { get; set; }
        public virtual bool Editar { get; set; }
    }
    public enum ColProductoUnidad
    {
        IdProductoUnidad,
        IdUnidad,
        IdProducto,
        Modelo,
        Unidad,
        Factor,
        PContado,
        PCredito,
        DescContado,
        DescCredito,
        UnidadBase,
        IdUnidadMinima,
        Estado,
        PesoMin,
        Peso,
        Nuevo,
        Editar
    }
    public enum ProcProductoUnidad
    {
        RegistrarProductoUnidad,
        ModificarProductoUnidad,
        EliminarProductoUnidad,
        ListarProductoUnidad,
        ConsultarProductoUnidad
    }
}
