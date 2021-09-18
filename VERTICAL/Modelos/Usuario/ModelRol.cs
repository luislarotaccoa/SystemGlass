namespace VERTICAL.Modelo.Usuario
{
    public class ModelRol
    {
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColRol
    {
        IdRol,
        Rol,
        Estado
    }
    public enum ProcRol
    {
        RegistrarRol,
        ModificarRol,
        EliminarRol,
        ListarRol,
        ConsultarRol
    }
}
