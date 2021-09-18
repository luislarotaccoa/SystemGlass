namespace VERTICAL.Modelos.Publico
{
    public class ModelMedioPago
    {
        public int IdMedioPago { get; set; }
        public int Codigo { get; set; }//Codigo Sunat
        public string Descripcion { get; set; }
        public bool Efectivo { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColMedioPago
    {
        IdMedioPago,
        Descripcion,
        Codigo,//Codigo Sunat
        Efectivo,
        Estado
    }
}
