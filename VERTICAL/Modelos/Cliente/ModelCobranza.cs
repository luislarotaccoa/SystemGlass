using System;

namespace VERTICAL.Modelos.Cliente
{
    public class ModelCobranza
    {
        public int IdCobranza { get; set; }
        public int IdVentas { get; set; }
        public int Numero { get; set; } //Numero de Comprobante (Factura,Boleta)
        public int Serie { get; set; }
        public string Simbolo { get; set; }
        public string Condicion { get { return TVenta + "(" + Plazo+")"; } }

        public string Documento { get { return Simbolo + string.Format("{0:000}", Serie) + "-" + string.Format("{0:000000000}", Numero); } }
        public int Dias { get {return (DateTime.Now-FVencimiento).Days; } }
        public string Situacion { get { return Dias > 0 ? "Vencido" + "(" + Dias + ")" : "Pendiente" + "(" + Dias + ")"; } }
        ///Fecha de emision del comprobante 
        public DateTime FEmision { get; set; }
       
        public int IdCliente { get; set; }
        public string NumDocumento { get; set; }
        public string Cliente { get; set; }
        public int IdBanco { get; set; }
        public int IdMedioPago { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }//Importe de venta
        public decimal ACuenta { get; set; }//Importe a cuenta anterior
        public decimal Apagar { get; set; }//Importe a paga ahora
        public decimal Saldo { get; set; }//Importe deudal del cliente
        public string NumOperacion { get; set; }

        ///Fecha de operacion del banco (fecha en el baucher) 
        public DateTime FOperacion { get; set; }
        public bool Estado { get; set; }
        public virtual bool Efectivo { get; set; }
        public virtual int IdComprobante { get; set; }
        public virtual int IdTienda { get; set; }
        public string Directo { get; set; }
        public string MPago { get; set; }
        public string TVenta { get; set; }
        public string Usuario { get; set; }
        public string Banco { get; set; }
        public DateTime FVencimiento { get; set; }
        public bool Credito { get; set; }
        public int Plazo { get; set; }
    }
    public enum ColCobranza
    {
        IdCobranza,
        IdVentas,
        Numero,//Numero de Comprobante (Factura,Boleta)
        Serie,
        Simbolo,
        FEmision,
        IdCliente,
        NumDocumento,
        Cliente,
        IdBanco,
        IdMedioPago,
        IdUsuario,
        Fecha,
        Importe,
        Pago,
        Saldo,
        NumOperacion,
        FOperacion,
        Estado,
        Documento,
        Efectivo,
        IdComprobante,
        IdTienda,
        Directo,
        MPago,
        TVenta,
        Usuario,
        Banco
    }
    public enum ProcCobranza
    {
        RegistrarCobranza,
        ModificarCobranza,
        EliminarCobranza,
        ListarCobranza,
        ConsultarCobranza,
        ConsultaDeudaCliente
    }
}
