using System;

namespace VERTICAL.Modelos.ESProducto
{
    public class CompraModel
    {
        private decimal _Factor;
        public CompraModel(decimal factor)
        {
            _Factor = factor;
        }
        public int IdProducto { get; set; }
        public int IdIngreso { get; set; }
        public int IdOCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public decimal _Cantidad { get { return (Factor / _Factor) * Cantidad; } }
        public string Unidad { get; set; }
        public int IdContenido { get; set; }
        public decimal Factor { get; set; }
        public string Moneda { get; set; }
        public decimal Costo { get; set; }
        public decimal Promedio { get; set; }
        public decimal _Costo { get { return (Costo * _Factor) / Factor; } }
        public decimal _Promedio { get { return (Promedio * _Factor) / Factor; } }
        public decimal TCambio { get; set; }
        public string Almacen { get; set; }
        public int Serie { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; } //Simbolo Comprobante
        public string Documento { get { return Tipo + string.Format("{0:0000}", Serie) + "-" + string.Format("{0:00000}", Numero); } } //I001-0001
        public string Proveedor { get; set; }
        public string NumDocumento { get; set; }
    }
    public enum ColCompra
    {
        IdProducto,
        IdIngreso,
        IdOCompra,
        Fecha,
        Cantidad,
        _Cantidad,
        Unidad,
        IdContenido,
        Factor,
        Moneda,
        Costo,
        _Costo,
        TCambio,
        Almacen,
        Serie,
        Numero,
        Tipo,
        Documento,
        Proveedor,
        NumDocumento
    }
    public enum ProcCompra
    {
        ListarCompra
    }
}
