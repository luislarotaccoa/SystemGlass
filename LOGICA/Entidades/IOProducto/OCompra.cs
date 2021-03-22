using System;

namespace LOGICA.Entidades.IOProducto
{
    public class OCompra
    {
        public int IdOCompra { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
        public int IdComprobante { get; set; }
        public int IdMoneda { get; set; }
        public decimal TipoCambio { get; set; }
        public int IdTipoVenta { get; set; }
        public int Plazo { get; set; }
        public decimal Igv { get; set; }
        public bool Estado { get; set; }
    }
}
