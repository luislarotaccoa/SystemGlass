namespace LOGICA.Entidades.Venta
{
    public class TipoVenta
    {
        public int IdTipoVenta { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
        public bool Credito { get; set; }//Afecto a Crédito
    }
}
