namespace LOGICA.Entidades.Cliente
{
    public class LineaCredito
    {
        public int IdLineaCredito { get; set; } //PK
        public int IdCliente { get; set; } //FK
        public int IdCalificacion { get; set; } //FK
        public int DiasMax { get; set; }
        public decimal MontoMax { get; set; }
        public bool Estado { get; set; }
    }
}
