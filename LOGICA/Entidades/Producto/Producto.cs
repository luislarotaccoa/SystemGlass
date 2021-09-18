namespace LOGICA.Entidades.Producto
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Serie2 { get; set; }
        public string Modelo { get; set; }
        public int IdDescrip1 { get; set; }
        public int IdDescrip2 { get; set; }
        /// <summary>
        /// Unidad minima de cada producto (Su unidad contenida de esta debe ser la misma)
        /// </summary>
        public int IdUnidad { get; set; } //Unidad minima de cada producto (Su unidad contenida de esta debe ser la misma)
        public int IdColor { get; set; }
        /// <summary>
        /// Peso de la unidad minima
        /// </summary>
        public decimal Peso { get; set; } 
        public bool Estado { get; set; }
    }

}
