using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Turno
{
    public class Turno
    {
        public DateTime horaFin { get; set; }
        public DateTime horaInicio { get; set; }
        public string nombreTurno { get; set; }

        public Turno() { }

        public Turno(string nombreTurno, DateTime horaInicio, DateTime horaFin) {

            this.nombreTurno = nombreTurno;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;

        }
    }
}
