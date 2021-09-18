namespace VERTICAL.Modelo.Usuario
{
    public class ModelRolProceso
    {
        public int IdRolProceso { get; set; }
        public int IdRoles { get; set; }
        public int IdProceso { get; set; }
        public string Permisos { get; set; }
        public string Rol { get; set; }
        public string Proceso { get; set; }
        public bool Estado { get; set; }
        public virtual bool Nuevo { get; set; }
        public virtual bool Edit { get; set; }
    }
    public enum ColRolProceso
    {
        IdRolProceso,
        IdRoles,
        IdProceso,
        Permisos,
        Rol,
        Proceso,
        Estado,
        Nuevo,
        Edit
    }
    public enum ProcRolProceso
    {
        RegistrarRolProceso,
        ModificarRolProceso,
        EliminarRolProceso,
        ListarRolProceso,
        ConsultarRolProceso
    }
}
