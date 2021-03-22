namespace LOGICA.Entidades.Venta
{
    public  class Credito
    {
        public int IdCredito { get; set; }
        public int IdLineaCredito { get; set; }
        public int IdProforma { get; set; }
        public int Dias { get; set; } //numero de dias de credito
        public bool Estado { get; set; }
    }
}
