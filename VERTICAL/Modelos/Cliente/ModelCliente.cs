using VERTICAL.Modelos.Publico;

namespace VERTICAL.Modelos.Cliente
{
    public class ModelCliente
    {
        public int IdCliente { get; set; }
        public string RazSocial { get; set; }
        public Documento CodDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Ubigeo { get; set; }
        public int IdUbigeo { get; set; }
    }

    public enum ColCliente
    {
        IdCliente,
        RazSocial,
        CodDocumento,
        NomDocumento,
        NumDocumento,
        Direccion,
        Email,
        Telefono,
        Estado,
        Departamento,
        Provincia,
        Distrito,
        Ubigeo,
        IdUbigeo
    }
    public enum ProcCliente
    {
        RegistrarCliente,
        ModificarCliente,
        EliminarCliente,
        ListarCliente,
        ConsultarCliente
    }
}
