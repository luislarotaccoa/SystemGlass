using System;

namespace LOGICA.Entidades.IOProducto
{
    public class Transferencia
    {
        public int IdTransferencia { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public int IdComprobante { get; set; }
        public int IdAlmacen1 { get; set; }
        public int IdAlmacen2 { get; set; }
        public int IdUbicacion1 { get; set; }
        public int IdUbicacion2 { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public int Estado { get; set; }
    }
}
