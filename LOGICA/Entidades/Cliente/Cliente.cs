namespace LOGICA.Entidades.Cliente
{
    public class Cliente
    {
        public int IdCliente { get; set; } //PK
        public string RazSocial { get; set; }
        public int CodDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Direccion { get; set; } // Direccion fiscal
        public int IdUbigeo { get; set; } //FK
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
