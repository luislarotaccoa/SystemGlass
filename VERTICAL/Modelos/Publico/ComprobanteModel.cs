namespace VERTICAL.Modelos.Publico
{
    public class ModelComprobante
    {
        public int IdComprobante { get; set; }
        public int Codigo { get; set; }
        public string NomComprobante { get; set; }
        public bool Estado { get; set; }
        public string Tipo { get; set; }
        public bool Declarable { get; set; }
        public bool Venta { get; set; }
        public bool Ingreso { get; set; }
    }
    public enum ColComprobante
    {
        IdComprobante,
        Codigo,
        NomComprobante,
        Estado,
        Tipo,
        Declarable, 
        Venta,
        Ingreso
    }
}
