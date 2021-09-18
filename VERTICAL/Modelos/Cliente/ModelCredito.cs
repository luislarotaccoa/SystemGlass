using System;

namespace VERTICAL.Modelos.Cliente
{
    public class ModelCredito
    {
        public int IdVentas { get; set; }
        public int Numero { get; set; } //Numero de Comprobante (Factura,Boleta)
        public int Serie { get; set; }
        public string Simbolo { get; set; }
        public string Comprobante { get { return Simbolo + string.Format("{0:000}", Serie) + "-" + string.Format("{0:000000000}", Numero); } }
        public DateTime FEmision { get; set; }
        public DateTime FVencimiento { get; set; }
        public string Cliente { get; set; }
        public string Documento { get; set; }
        public int Dias { get { return (FVencimiento - DateTime.Now).Days; } }
        public int Plazo { get; set; }
        public decimal Importe { get; set; }
        public decimal ACuenta { get; set; }
        public decimal Saldo { get { return Importe - ACuenta; } }
        public string TVenta { get; set; }
        public string Vendedor { get; set; }
    }
    public enum ColCredito
    {
        IdVentas,
        Numero,
        Serie,
        Simbolo,
        Comprobante,
        FEmision,
        FVencimineto,
        Cliente,
        Documento,
        Dias,
        Plazo,
        Importe,
        ACuenta,
        Saldo,
        TVenta,
        Vendedor
    }
    public enum ProcCredito
    {
        RegistrarCredito,
        ModificarCredito,
        EliminarCredito,
        ListarCredito,
        ConsultarCredito
    }
}
