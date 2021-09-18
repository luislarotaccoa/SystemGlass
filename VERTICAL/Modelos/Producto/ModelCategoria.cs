namespace VERTICAL.Modelos.Producto
{
    public class ModelCategoria
    {
        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }
        public bool Bilateral { get; set; }
        public virtual bool Estado { get; set; }
    }
    public enum ColCategoria
    {
        IdCategoria,
        NomCategoria,
        Bilateral,
        Estado
    }
    public enum ProcCategoria
    {
        RegistrarCategoria,
        ModificarCategoria,
        EliminarCategoria,
        ListarCategoria,
        ConsultarCategoria
    }
}
