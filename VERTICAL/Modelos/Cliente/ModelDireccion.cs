namespace VERTICAL.Modelos.Cliente
{
    public class ModelDireccion
    {
        public int IdDireccion { get; set; }
        public int IdCliente { get; set; }
        public int IdUbigeo { get; set; }
        public string NombreDireccion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColDireccion
    {
        IdDireccion,
        IdCliente,
        IdUbigeo,
        NombreDireccion,
        Departamento,
        Provincia,
        Distrito,
        Estado
    }
    public enum ProcDireccion
    {
        RegistrarDireccion,
        ModificarDireccion,
        EliminarDireccion,
        ListarDireccion,
        ConsultarDireccion
    }
}
