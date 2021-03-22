namespace LOGICA.Entidades.Producto
{
    public class Contenido
    {
        public int IdContenido { get; set; }
        public int IdCategoria { get; set; }
        public int IdUnidad { get; set; }
        public decimal Factor { get; set; }
        public string MRef { get; set; }
        public int IdUnidadMinima { get; set; }
        public bool Estado { get; set; }
    }
}
