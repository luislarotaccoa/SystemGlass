namespace LOGICA.Entidades.Producto
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Serie2 { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public string Modelo { get; set; }
        public int IdDescripcion1 { get; set; }
        public int IdDescripcion2 { get; set; }
        public int IdColor { get; set; }
        /// <summary>
        /// Unidad minima de cada producto (Su unidad contenida de esta debe ser la misma)
        /// </summary>
        public int IdContenido { get; set; } //Unidad minima de cada producto (Su unidad contenida de esta debe ser la misma)
        /// <summary>
        /// Peso de la unidad minima
        /// </summary>
        public decimal Peso { get; set; } 
        public bool Estado { get; set; }
    }

}
