using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.PerfilServicio
{
    public class PerfilServicio
    {
        public int pe_valor { get; set; }
        public int idPerfil { get; set; }
        public int idServicio { get; set; }

        public PerfilServicio(int pe_valor,int idPerfil,int idServicio) {

            this.pe_valor = pe_valor;
            this.idPerfil = idPerfil;
            this.idServicio = idServicio;


        }
    }
}
