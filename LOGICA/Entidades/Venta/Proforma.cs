using System;

namespace LOGICA.Entidades.Venta
{
    public class Proforma
    {
        public int IdProforma { get; set; }
        public int Numero { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; } //Fecha de Emision
        public int IdComprobante { get; set; }
        public decimal Igv { get; set; }
        public int Plazo { get; set; }
        public int IdTienda { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoVenta { get; set; }
        public int IdAlmacen { get; set; } //Almacen por defecto
        public bool Estado { get; set; }
        public bool ENUSO { get; set; }
        public string Directo { get; set; }
    }
}
