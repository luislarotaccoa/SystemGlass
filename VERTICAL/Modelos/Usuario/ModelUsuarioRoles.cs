namespace VERTICAL.Modelo.Usuario
{
    public class ModelUsuarioRol
    {
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColUsuarioRol
    {
        IdUsuario,
        NomUsuario,
        IdRol,
        Rol,
        Estado
    }
}
