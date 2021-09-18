using System;

namespace VERTICAL.Modelos.Cliente
{
    public class ModelLineaCredito
    {
        public int IdLineaCredito { get; set; }
        public int IdCliente { get; set; }
        public int DiasMax { get; set; }
        public decimal MontoMax { get; set; }
        public int IdCalificacion { get; set; }
        public string Nota { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public object FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
    public enum ColLineaCredito
    {
        IdLineaCredito,
        IdCliente,
        DiasMax,
        MontoMax,
        IdCalificacion,
        Nota,
        Descripcion,
        Estado
    }
    public enum ProcLineaCredito
    {
        RegistrarLineaCredito,
        ModificarLineaCredito,
        EliminarLineaCredito,
        ListarLineaCredito,
        ConsultarLineaCredito
    }
}
