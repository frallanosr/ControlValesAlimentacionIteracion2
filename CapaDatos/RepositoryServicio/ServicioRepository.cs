using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.Servicio;

namespace CapaDatos.RepositoryServicio
{
   public class ServicioRepository
    {
        private string conexion;

        public ServicioRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }

        //excepcion con se_nombreperfeil
        public void insertaServicio(Servicio s) {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"SERVICIO\" (\"IDSERVICIO\", \"SE_NOMBRE\", \"SE_INICIO\", \"SE_TERMINO\")VALUES(s_sequence.nextval, '"+s.nombre+"', TO_DATE('" + s.horaInicio+ "', 'DD/MM/YYYY HH24:MI:SS'),TO_DATE('" + s.horaFin+ "', 'DD/MM/YYYY HH24:MI:SS'))";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public int buscaUltimoRegistro()
        {
            int id = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "Select \"IDSERVICIO\" from (select * from \"SISTEMA\".\"SERVICIO\" order by \"IDSERVICIO\" desc ) where rownum = 1 ";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return id;
                } while (reader.Read())
                {
                    return id = Convert.ToInt32(reader["IDSERVICIO"]);
                }
                cn.Close();
            }
            return id;
        }
    }
}
