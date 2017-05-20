using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.RepositoryTicket
{
    public class ImprimeTicket
    {
        private string conexion;

        public ImprimeTicket()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }


        public string NombreServicioPorRut(string rut){
            string nombreServicio = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"SE_NOMBRE\" FROM \"SISTEMA\".\"SERVICIO\" WHERE \"IDSERVICIO\" = (select \"SERVICIO_IDSERVICIO\"from \"SISTEMA\".\"PERFIL_SERVICIO\"WHERE \"PERFIL_IDPERFIL\" = (SELECT \"PERFIL_IDPERFIL\" from \"SISTEMA\".\"USUARIO\" WHERE \"RUT\" = '" + rut + "'))";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return nombreServicio;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return nombreServicio = (string)reader["SE_NOMBRE"];
                }
                cn.Close();
            }
            return nombreServicio;

        }


        public decimal valorServicio(string rut)
        {
            decimal valor = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = " select \"PE_VALOR\" from \"SISTEMA\".\"PERFIL_SERVICIO\"WHERE \"PERFIL_IDPERFIL\" = (SELECT \"PERFIL_IDPERFIL\" from \"SISTEMA\".\"USUARIO\" WHERE \"RUT\" = '" + rut + "')";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return valor;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return valor = (decimal)reader["PE_VALOR"];
                }
                cn.Close();
            }
            return valor;

        }


    }
}
