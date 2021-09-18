namespace VERTICAL.Modelos.Producto
{
    public class ModelFamilia
    {
        public int IdFamilia { get; set; }
        public string NomFamilia { get; set; }
        public string NomCategoria { get; set; }
        public int IdCategoria { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColFamilia
    {
        IdFamilia,
        NomFamilia,
        NomCategoria,
        IdCategoria,
        Estado
    }
    public enum ProcFamilia
    {
        RegistrarFamilia,
        ModificarFamilia,
        EliminarFamilia,
        ListarFamilia,
        ConsultarFamilia
    }
}
