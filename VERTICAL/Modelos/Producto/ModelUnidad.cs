namespace VERTICAL.Modelos.Producto
{
    public  class ModelUnidad
    {
        public int IdUnidadCategoria { get; set; }
        public int IdUnidad { get; set; }
        public int IdUnidadMinima { get; set; }
        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }
        public string AUnidad { get; set; }
        public string CodUnidad { get; set; }
        public decimal Factor { get; set; }
        public bool Bilateral { get; set; }
        public bool Medible { get; set; }
        public bool Estado { get; set; }
        public string AUnidadMinima { get; set; }
    }
    public enum ColUnidad
    {
        IdUnidadCategoria,
        IdUnidad,
        IdUnidadMinima,
        IdCategoria,
        NomCategoria,
        CodUnidad,
        AUnidad,
        Factor,
        Estado,
        Medible,
        AUnidadMinima
    }
    public enum ProcUnidad
    {
        RegistrarUnidad,
        ModificarUnidad,
        EliminarUnidad,
        ListarUnidad,
        ConsultarUnidad,
        ModificarUnidadCategoria,
        EliminarUnidadCategoria,
        ListarUnidadCategoria,
        RegistrarUnidadCategoria
    }
}
