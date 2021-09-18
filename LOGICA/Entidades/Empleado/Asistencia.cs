using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.Entidades.Empleado
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int IdEmpleado { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Entredad { get; set; }
        public TimeSpan Salida { get; set; }
        public bool Estado { get; set; }
    }
}
