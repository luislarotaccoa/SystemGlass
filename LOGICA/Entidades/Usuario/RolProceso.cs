namespace LOGICA.Entidades.Usuario
{
    public class RolProceso
    {
        public int IdRolProceso { get; set; }
        public int IdRoles { get; set; }
        public int IdProceso { get; set; }
        public string Permisos { get; set; }
        public bool Estado { get; set; }
    }
}
