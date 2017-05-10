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
        public string nombrePerfil { get; set; }
        public int valorServicio { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }

        public Servicio(string nombre, string nombrePerfil, int valorServicio, DateTime horaInicio, DateTime horaFin)
        {
            this.nombre = nombre;
            this.nombrePerfil = nombrePerfil;
            this.valorServicio = valorServicio;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }
    }
}
