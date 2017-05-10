using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.Perfil;
using Oracle.DataAccess.Client;

namespace CapaDatos.RepositoryPerfil
{
    
    public class PerfilRepository
    {
        private string conexion;

        public PerfilRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }
        public void insertaPerfil(Perfil p)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"PERFIL\" (\"IDPERFIL\", \"P_CARGO\", \"P_ESTADO\", \"P_DESCRIPCION\") VALUES (p_sequence.nextval, '" + p.p_cargo + "', '"+p.p_estado+"', '"+p.descripcion+"')";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public string tipoCargoExtraer(int c)
        {

            
            string tipoCargo = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "Select \"P_CARGO\" from SISTEMA.PERFIL where \"IDPERFIL\" = '" + c + "' and \"P_ESTADO\" = '" + 1 + "'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return tipoCargo;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return tipoCargo = (string)reader["P_CARGO"];
                }
                cn.Close();
            }
            return tipoCargo;

        }
    }
}
