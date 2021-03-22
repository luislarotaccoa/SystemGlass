namespace LOGICA.Entidades.Cliente
{
    public class DireccionCliente
    {
        public int IdDireccionCliente { get; set; } //PK
        public int IdUbigeo { get; set; } //FK
        public int IdCliente { get; set; } //FK
        public string NombreDireccion { get; set; }
        public bool Estado { get; set; }
    }
}
