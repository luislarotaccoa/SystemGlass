using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERTICAL.Modelos.Producto
{
   public class ModelUbicacion
    {
        public int IdAlmacen { get; set; }
        public string Serie { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public int IdUbicacion { get; set; }
        public string NomUbicacion { get; set; }
    }
    public enum ColUbicacion
    {
        IdAlmacen,
        Serie,
        Nombre,
        Direccion,
        Estado,
        IdUbicacion,
        NomUbicacion,
    }
    public enum ProcUbicacion
    {
        RegistrarUbicacion,
        ModificarUbicacion,
        EliminarUbicacion,
        ListarUbicacion,
        ConsultarUbicacion,
        ListarAlmacenUbicacion
    }
}
