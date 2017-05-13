using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Vales
{
    public class Vales
    {
        public int valor { get; set; }
        public string nombrePerfil { get; set; }
        public int v_impreso { get; set; }
        public int v_usado { get; set; }
        public int casino_idcasino { get; set; }
        public int turno_idturno { get; set; }

        public Vales(int valor, string nombrePerfil,int v_impreso, int v_usado,int casino_idcasino,int turno_idturno)
        {
            this.valor = valor;
            this.nombrePerfil = nombrePerfil;
            this.v_impreso = v_impreso;
            this.v_usado = v_usado;
            this.casino_idcasino = casino_idcasino;
            this.turno_idturno = turno_idturno;
        }

    }

    

    
}
