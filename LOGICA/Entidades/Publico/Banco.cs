namespace LOGICA.Entidades.Publico
{
    public class Banco
    {
        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; } //Codigo Sunat
        public bool Estado { get; set; }
        public bool Efectivo { get; set; }
    }
}
