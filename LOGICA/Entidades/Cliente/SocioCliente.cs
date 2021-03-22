namespace LOGICA.Entidades.Cliente
{
    public class SocioCliente
    {
        public int IdCliente1 { get; set; } //FK
        public int IdCliente2 { get; set; } //FK
        public string TipoSocio { get; set; }
        public bool Estado { get; set; }
    }
}
