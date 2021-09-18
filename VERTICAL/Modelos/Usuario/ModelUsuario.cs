namespace VERTICAL.Modelo.Usuario
{
    public class ModelUsuario
    {
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string Contrasena { get; set; }
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public bool Estado { get; set; }
        public virtual string Titular { get { return Nombres + " " + Apellidos; } }

    }
    public enum ColUsuario
    {
        IdUsuario,
        NomUsuario,
        Contrasena,
        IdEmpleado,
        Apellidos,
        Documento,
        Numero,
        Nombres,
        Estado,
        Titular
    }
    public enum ProcUsuario
    {
        RegistrarUsuario,
        ModificarUsuario,
        EliminarUsuario,
        ListarUsuario,
        ConsultarUsuario
    }
}
