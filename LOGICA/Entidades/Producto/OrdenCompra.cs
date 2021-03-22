using System;

namespace LOGICA.Entidades.Producto
{
    public class OrdenCompra
    {
        public int IdOrdenCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }
        public string Plazo { get; set; }
        public decimal TipoCambio { get; set; }
        public bool Estado { get; set; }
        public bool Ingresado { get; set; }
    }
}
