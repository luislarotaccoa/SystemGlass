namespace LOGICA.Entidades.Producto
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public int IdDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public int IdUbigeo { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
