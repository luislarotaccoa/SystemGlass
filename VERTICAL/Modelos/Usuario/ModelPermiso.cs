namespace VERTICAL.Modelo.Usuario
{
    public class ModelPermiso
    {
        public int IdPermiso { get; set; }
        public string Descripcion { get; set; }
        public virtual bool Permisos { get; set; }
    }
    public enum ColPermiso
    {
        IdPermiso,
        Descripcion,
        Permisos
    }
    public enum ProcPermiso
    {
        RegistrarPermiso,
        ModificarPermiso,
        EliminarPermiso,
        ListarPermiso,
        ConsultarPermiso
    }
}
