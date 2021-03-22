namespace LOGICA.Entidades.Publico
{
    public class MedioPago
    {
        public int IdMedioPago { get; set; }
        public string Descripcion { get; set; }
        public int Codigo { get; set; }//Codigo Sunat
        public bool Efectivo { get; set; }
        public bool Estado { get; set; }
    }
}
