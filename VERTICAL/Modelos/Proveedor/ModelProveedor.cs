using VERTICAL.Modelos.Publico;

namespace VERTICAL.Modelos.Proveedor
{
    public class ModelProveedor
    {
        public int IdProveedor { get; set; }
        public Documento CodDocumento { get; set; }
        public string NomDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public int IdUbigeo { get; set; }
        public string Ubigeo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColProveedor
    {
        IdProveedor,
        CodDocumento,
        NomDocumento,
        RazonSocial,
        Numero,
        Direccion,
        IdUbigeo,
        Ubigeo,
        Departamento,
        Provincia,
        Distrito,
        Email,
        Telefono,
        Estado
    }
    public enum ProcProveedor
    {
        RegistrarProveedor,
        ModificarProveedor,
        EliminarProveedor,
        ListarProveedor,
        ConsultarProveedor
    }
}
