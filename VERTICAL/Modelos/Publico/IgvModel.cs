namespace VERTICAL.Modelos.Publico
{
    public class ModelIgv
    {
        public int IdIgv { get; set; }
        public int Año { get; set; }
        public decimal IGV { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColIgv
    {
        IdIgv,
        Año,
        IGV,
        Estado
    }
}
