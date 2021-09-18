namespace VERTICAL.Modelos.Publico
{
    public class ModelBanco
    {
        public int IdBanco { get; set; }
        public int Codigo { get; set; } //Codigo Sunat
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public bool Efectivo { get; set; }
    }
    public enum ColBanco
    {
        IdBanco,
        Nombre,
        Codigo, //Codigo Sunat
        Estado,
        Efectivo
    }
}
