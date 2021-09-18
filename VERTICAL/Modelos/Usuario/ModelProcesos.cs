namespace VERTICAL.Modelo.Usuario
{
    public class ModelProcesos
    {
        public int IdProceso { get; set; }
        public int Nodo { get; set; }
        public string Proceso { get; set; }
        public bool Estado { get; set; }
        public virtual bool Asignada { get; set; }
    }
    public enum ColProcesos
    {
        IdProceso,
        Nodo,
        Proceso,
        Estado,
        Asignada
    }
    public enum ProcProceso
    {
        RegistrarProceso,
        ModificarProceso,
        EliminarProceso,
        ListarProceso,
        ConsultarProceso
    }
}
