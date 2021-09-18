using VERTICAL.Modelos.Publico;

namespace VERTICAL.Modelos.Cliente
{
    public class ModelSocioCliente
    {
        public int IdCliente1 { get; set; }
        public int IdCliente2 { get; set; }
        public Documento CodDocumento { get; set; }
        public string RazSocial { get; set; }
        public string NumDocumento { get; set; }
        public string Telefono { get; set; }
        public string TipSocio { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColSocioCliente
    {
        IdCliente1,
        IdCliente2,
        CodDocumento,
        RazSocial,
        NumDocumento,
        Telefono,
        TipSocio,
        Estado
    }
    public enum ProcSocioCliente
    {
        RegistrarSocioCliente,
        ModificarSocioCliente,
        EliminarSocioCliente,
        ListarSocioCliente,
        ConsultarSocioCliente
    }
}
