using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Servicio
{
    public class Servicio
    {
        public string nombre { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }

        public Servicio(string nombre, DateTime horaInicio, DateTime horaFin)
        {
            this.nombre = nombre;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }
    }
}
