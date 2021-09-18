namespace LOGICA.Entidades.Producto
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public int IdProveedor { get; set; }
        public string Nombres { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
