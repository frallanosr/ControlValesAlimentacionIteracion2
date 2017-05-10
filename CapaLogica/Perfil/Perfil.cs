using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Perfil
{
    public class Perfil
    {
        public string p_cargo { get; set; }
        public int p_estado { get; set; }
        public string descripcion { get; set;}

        public Perfil(string p_cargo,int p_estado, string descripcion) {
            this.p_cargo = p_cargo;
            this.p_estado = p_estado;
            this.descripcion = descripcion;
        }
    }
}
