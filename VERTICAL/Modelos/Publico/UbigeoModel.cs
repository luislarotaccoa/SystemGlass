namespace VERTICAL.Modelos.Publico
{
    public class ModelUbigeo
    {
        public int IdUbigeo { get; set; }
        public string Codigo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public float Y { get; set; }
        public float X { get; set; }
    }
    public enum ColUbigeo
    {
        IdUbigeo,
        Codigo,
        Departamento,
        Provincia,
        Distrito,
        Y,
        X
    }
}
