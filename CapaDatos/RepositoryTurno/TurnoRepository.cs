using CapaLogica.Turno;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.RepositoryTurno
{
    public class TurnoRepository
    {
        private string conexion;

        public TurnoRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }

        //excepcion con se_nombreperfeil
        public void insertaTurno(Turno t)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"TURNO\" (\"IDTURNO\", \"T_NOMBRE\", \"HR_INICIO\", \"HR_TERMINO\") VALUES (t_sequence.nextval,'"+t.nombreTurno+"', TO_DATE('" + t.horaInicio + "', 'DD/MM/YYYY HH24:MI:SS'),TO_DATE('" + t.horaFin + "', 'DD/MM/YYYY HH24:MI:SS'))";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
