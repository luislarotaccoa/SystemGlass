using System;

namespace LOGICA.Entidades.Venta
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FEmision { get; set; } //Fecha de emision
        public DateTime FVencimiento { get; set; } //Fecha de vencimiento
        public int IdProforma { get; set; }
        public string Numero { get; set; } //Numero de documento formal
        public bool Estado { get; set; }
        public bool Cancelado { get; set; }
    }
}
