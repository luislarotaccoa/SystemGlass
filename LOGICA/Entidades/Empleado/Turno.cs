using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA.Entidades.Empleado
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string Turnos { get; set; }
        public TimeSpan Desde { get; set; }
        public TimeSpan Hasta { get; set; }
        public int Tolerancia { get; set; }
        public bool Estado { get; set; }

    }
}
