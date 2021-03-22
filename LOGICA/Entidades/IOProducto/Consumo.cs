using System;

namespace LOGICA.Entidades.IOProducto
{
    public class Consumo
    {
        public int IdConsumo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdAlmacen { get; set; }
        public int Numero { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public int IdComprobante { get; set; }
        public bool Estado { get; set; }
    }
}
