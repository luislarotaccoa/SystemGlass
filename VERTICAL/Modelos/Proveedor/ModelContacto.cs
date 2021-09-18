using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VERTICAL.Modelos.Proveedor
{
    public class ModelContacto
    {
        public int IdContacto { get; set; }
        public int IdProveedor { get; set; }
        public string Nombres { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColContacto
    {
        IdContacto,
        IdProveedor,
        Nombres,
        Area,
        Email,
        Telefono,
        Estado
    }
    public enum ProcContacto
    {
        RegistrarContacto,
        ModificarContacto,
        EliminarContacto,
        ListarContacto,
        ConsultarContacto
    }
}
