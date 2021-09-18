namespace VERTICAL.Modelos.Cliente
{
    public class ModelCalificacion
    {
        public int IdCalificacion { get; set; }
        public string Nota { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColCalificacion
    {
        IdCalificacion,
        Nota,
        Descripcion,
        Estado
    }
    public enum ProcCalificacion
    {
        RegistrarCalificacion,
        ModificarCalificacion,
        EliminarCalificacion,
        ListarCalificacion,
        ConsultarCalificacion
    }
}
