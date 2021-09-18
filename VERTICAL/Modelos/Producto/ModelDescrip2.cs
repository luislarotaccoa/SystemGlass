namespace VERTICAL.Modelos.Producto
{
    public class ModelDescrip2
    {
        public int IdDescrip2 { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }
        public bool Bilateral { get; set; }
    }
    public enum ColDescrip2
    {
        IdDescrip2,
        Descripcion,
        NomCategoria,
        Bilateral,
        Estado,
        IdCategoria
    }
    public enum ProcDescrip2
    {
        RegistrarDescrip2,
        ModificarDescrip2,
        EliminarDescrip2,
        ListarDescrip2,
        ConsultarDescrip2,
        ListarCategoriaDescrip2,
        RegistrarCategoriaDescrip2
    }
}
