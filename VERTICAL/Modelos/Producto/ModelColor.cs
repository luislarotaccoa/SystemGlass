namespace VERTICAL.Modelos.Producto
{
    public class ModelColor
    {
        public int IdColor { get; set; }
        public string NomColor { get; set; }
        public bool Estado { get; set; }

        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }
        public bool Bilateral { get; set; }
    }
    public enum ColColor
    {
        IdColor,
        NomColor,
        Estado,

        IdCategoria,
        NomCategoria,
        Bilateral,
    }
    public enum ProcColor
    {
        RegistrarColor,
        ModificarColor,
        EliminarColor,
        ListarColor,
        ConsultarColor,

        RegistrarCategoriaColor,
        ModificarColorCategoria,
        EliminarColorCategoria,
        ListarCategoriaColor
    }
}
