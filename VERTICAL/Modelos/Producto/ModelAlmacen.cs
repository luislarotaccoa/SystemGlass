using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERTICAL.Modelos.Producto
{
    public class ModelAlmacen
    {
        public int IdAlmacen { get; set; }
        public int Serie { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

    }
    public enum ColAlmacen
    {
        IdAlmacen,
        Serie,
        Nombre,
        Direccion,
        Estado
    }
    public enum ProcAlmacen
    {
        RegistrarAlmacen,
        ModificarAlmacen,
        EliminarAlmacen,
        ListarAlmacen,
        ConsultarAlmacen
    }
}
