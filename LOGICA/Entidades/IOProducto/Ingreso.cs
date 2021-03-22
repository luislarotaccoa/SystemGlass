using System;

namespace LOGICA.Entidades.IOProducto
{
    public class Ingreso
    {
        /// <summary>
        /// Clave primaria
        /// </summary>
        public int IdIngreso { get; set; }
        /// <summary>
        /// Fecha de emision de Ingreso
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Almacen de ingreso de mercaderia, tambien indicador de serie de documento
        /// </summary>
        public int IdAlmacen { get; set; }
        /// <summary>
        /// Numero de comprobante (ingreso)
        /// </summary>
        public int Numero { get; set; }
        /// <summary>
        /// Usuario quien hace el ingreso
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Proveedor de quien se adquiere la mercaderia
        /// </summary>
        public int IdProveedor { get; set; }
        /// <summary>
        /// Comprobante de documento de ingreso (por defecto: Ingreso)
        /// </summary>
        public int IdComprobante { get; set; }
        /// <summary>
        /// tipo de comprobante de entrega del proveedor (guia, factura, u otros)
        /// </summary>
        public int IdCompProveedor { get; set; }
        /// <summary>
        /// Serie de comprobante de entrega del proveedor
        /// </summary>
        public int SerieProveedor { get; set; }
        /// <summary>
        /// Numero de comprobante de entrega del proveedor
        /// </summary>
        public int NumCompProveedor { get; set; }
        /// <summary>
        /// Fecha del comprovante de entrega del proveedor
        /// </summary>
        public DateTime FechaProveedor { get; set; }
        /// <summary>
        /// Identificador del transportista quien moviliza la mercaderia
        /// </summary>
        public int IdTransportista { get; set; }
        /// <summary>
        /// Tipo de comprobante con la que entrega el transportista
        /// </summary>
        public int IdCompTransportista { get; set; }
        /// <summary>
        /// Serie de comprobante del transportista
        /// </summary>
        public int SerieTransportista { get; set; }
        /// <summary>
        /// Numero de comprobante del transportista
        /// </summary>
        public int NumCompTransportista { get; set; }
        /// <summary>
        /// Estado del documento actual (anulado,vigente)
        /// </summary>
        public bool Estado { get; set; }
    }
}
