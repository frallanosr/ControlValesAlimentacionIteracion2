﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Vales
{
    public class ValesEspeciales
    {
        public int valor { get; set; }
        public int v_impreso { get; set; }
        public int v_usado { get; set; }
        public int v_normal { get; set; }
        public int casino_idcasino { get; set; }
        public string rut_usuario { get; set; }
        public int turno_idturno { get; set; }
        public DateTime? v_fecha_especial { get; set; }
        public int? v_cantidad { get; set; }


        public ValesEspeciales(int valor, int v_impreso, int v_usado, int v_normal, int casino_idcasino,
                     string rut_usuario, int turno_idturno, DateTime? v_fecha_especial, int? v_cantidad)
        {
            this.valor = valor;
            this.v_impreso = v_impreso;
            this.v_usado = v_usado;
            this.v_normal = v_normal;
            this.casino_idcasino = casino_idcasino;
            this.rut_usuario = rut_usuario;
            this.turno_idturno = turno_idturno;
            this.v_fecha_especial = v_fecha_especial;
            this.v_cantidad = v_cantidad;
        }
    }
}