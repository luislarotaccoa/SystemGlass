using System;

namespace LOGICA.Entidades.Cliente
{
    public class Cobranza
    {
        public int IdCobranza { get; set; }
        public int IdVenta { get; set; }
        public int IdBanco { get; set; }
        public int IdMedioPago { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int NumOperacion { get; set; }
        public DateTime FOperacion { get; set; }
        public bool Estado { get; set; }
    }
}
