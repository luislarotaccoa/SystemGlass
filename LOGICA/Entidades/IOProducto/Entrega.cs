using System;

namespace LOGICA.Entidades.IOProducto
{
    public class Entrega
    {
        public int IdEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public int IdVentas { get; set; }
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
        public int Numero { get; set; } //Numeracion de entregas
        public int IdAlmacen { get; set; } //Almacen de entregas (serie)
        public int IdComprobante { get; set; } //Comprobante de entrega (FIJO=ENTREGA)

    }
}
