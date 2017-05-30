using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.RepositoryUsuarioTurno
{
    public class UsuarioTurnoRepository
    {
        private string conexion;

        public UsuarioTurnoRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }

        public int buscaIdTurno(string rut) {

            int idTurno = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "select \"TURNO_IDTURNO\" from \"SISTEMA\".\"USUARIO_TURNO\" where \"USUARIO_RUT\" = '"+rut+"'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return idTurno;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return idTurno = Convert.ToInt32(reader["TURNO_IDTURNO"]);
             }
                cn.Close();
            }
            return idTurno;

         }
    }
}
