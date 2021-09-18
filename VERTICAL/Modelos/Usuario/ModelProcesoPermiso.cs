namespace VERTICAL.Modelo.Usuario
{
    public class ModelProcesoPermiso
    {
        public int IdProceso { get; set; }
        public int IdPermiso { get; set; }
        public string Proceso { get; set; }//Archivo
        public string Permiso { get; set; }//LEER,
        public bool Estado { get; set; }
    }
    public enum ColProcesoPermiso
    {
        IdProceso,
        IdPermiso,
        Proceso,
        Permiso,
        Estado
    }
    public enum ProcProcesoPermiso
    {
        RegistrarProcesoPermiso,
        ModificarProcesoPermiso,
        EliminarProcesoPermiso,
        ListarProcesoPermiso,
        ConsultarProcesoPermiso
    }
}
