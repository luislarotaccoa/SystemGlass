using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VERTICAL.Modelos.Publico;

namespace VERTICAL.Modelos.Empleado
{
    public class ModelEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public Documento CodDocumento { get; set; }
        public string NumDocumento { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int IdUbigeo { get; set; }
        public string Ubigeo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string EstCivil { get; set; }
        public string Email { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
    public enum ColEmpleado
    {
        IdEmpleado,
        Apellidos,
        Nombres,
        CodDocumento,
        NumDocumento,
        Sexo,
        FechaNacimiento,
        Direccion,
        IdUbigeo,
        Ubigeo,
        Departamento,
        Provincia,
        Distrito,
        EstCivil,
        Email,
        Especialidad,
        Telefono,
        Estado
    }
    public enum Sexo
    {
        F = 0,
        M = 1
    }
    public enum ProcEmpleado
    {
        RegistrarEmpleado,
        ModificarEmpleado,
        EliminarEmpleado,
        ListarEmpleado,
        ConsultarEmpleado,
        ConsultaEmpleado
    }
}
