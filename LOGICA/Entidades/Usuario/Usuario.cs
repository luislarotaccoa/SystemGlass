namespace LOGICA.Entidades.Usuario
{
public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string Contrasena { get; set; }
        public int IdEmpleado { get; set; }
        public bool Estado { get; set; }
    }
}
