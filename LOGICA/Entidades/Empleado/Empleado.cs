using System;

namespace LOGICA.Entidades.Empleado
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Documento { get; set; }
        public string NumDocumento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int IdUbigeo { get; set; }
        public string EstCivil { get; set; }
        public string Email { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}
