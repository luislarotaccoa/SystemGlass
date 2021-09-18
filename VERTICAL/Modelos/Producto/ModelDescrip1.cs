namespace VERTICAL.Modelos.Producto
{
    public class ModelDescrip1
    {
        public int IdDescrip1 { get; set; }
        public string Descripcion { get; set; }
        public int IdFamilia { get; set; }
        public string NomFamilia { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColDescrip1
    {
        IdDescrip1,
        Descripcion,
        IdFamilia,
        NomFamilia,
        Estado
    }
    public enum ProcDescrip1
    {
        RegistrarDescrip1,
        ModificarDescrip1,
        EliminarDescrip1,
        ListarDescrip1,
        ConsultarDescrip1
    }
}
