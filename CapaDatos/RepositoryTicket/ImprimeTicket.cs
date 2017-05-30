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


        public string NombreServicioPorId(int id){
            string nombreServicio = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"SE_NOMBRE\" FROM \"SISTEMA\".\"SERVICIO\" WHERE \"IDSERVICIO\" = '" + id + "' ";
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


        public decimal valorServicio(int idPerfil,int id)
        {
            decimal valor = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = " select \"PE_VALOR\" from \"SISTEMA\".\"PERFIL_SERVICIO\"WHERE \"PERFIL_IDPERFIL\" = '"+idPerfil+"' AND \"SERVICIO_IDSERVICIO\" = '"+id+"'";
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

        public string extraeNombreDeTurnoPorRut(string rut) {

            string nombret = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"SISTEMA\".\"TURNO\".\"T_NOMBRE\" AS \"NOMBRE\" FROM \"SISTEMA\".\"USUARIO_TURNO\" INNER JOIN \"SISTEMA\".\"TURNO\" ON \"USUARIO_TURNO\".\"TURNO_IDTURNO\" = \"TURNO\".\"IDTURNO\" WHERE \"USUARIO_TURNO\".\"USUARIO_RUT\" = '"+rut+"' ";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return nombret;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return nombret = (string)reader["NOMBRE"];
                }
                cn.Close();
            }
            return nombret;
        }


        public int idTurnoPorRut(string rut)
        {

            int idTurno = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"TURNO\".\"IDTURNO\" AS \"ID\" FROM \"SISTEMA\".\"USUARIO_TURNO\" INNER JOIN \"SISTEMA\".\"TURNO\" ON \"USUARIO_TURNO\".\"TURNO_IDTURNO\" = \"TURNO\".\"IDTURNO\" WHERE \"USUARIO_TURNO\".\"USUARIO_RUT\" = '" + rut + "'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return idTurno;
                } while (reader.Read())
                {
                    return idTurno = Convert.ToInt32(reader["ID"]);
                }
                cn.Close();
            }
            return idTurno;
        }

        public String horaInicio(string rut)
        {

            string horaIni = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT TO_CHAR(\"TURNO\".\"HR_INICIO\",'HH:MM') AS \"horaIni\" FROM \"SISTEMA\".\"USUARIO_TURNO\" INNER JOIN \"SISTEMA\".\"TURNO\" ON \"USUARIO_TURNO\".\"TURNO_IDTURNO\" = \"TURNO\".\"IDTURNO\" WHERE \"USUARIO_TURNO\".\"USUARIO_RUT\" = '" + rut + "'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return horaIni;
                } while (reader.Read())
                {
                    return horaIni = reader["horaIni"].ToString() ;
                }
                cn.Close();
            }
            return horaIni;
        }

        public int extraeIdPerfilPorRut(string v)
        {
            int id = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"PERFIL_IDPERFIL\" AS \"ID\" FROM \"SISTEMA\".\"USUARIO\" where \"RUT\" = '"+v+"'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return id;
                } while (reader.Read())
                {
                    return id = Convert.ToInt32(reader["ID"]);
                }
                cn.Close();
            }
            return id;
        }

        public String horaFin(string rut)
        {

            string horaFin = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"TURNO\".\"HR_TERMINO\" AS \"horaFin\" FROM \"SISTEMA\".\"USUARIO_TURNO\" INNER JOIN \"SISTEMA\".\"TURNO\" ON \"USUARIO_TURNO\".\"TURNO_IDTURNO\" = \"TURNO\".\"IDTURNO\" WHERE \"USUARIO_TURNO\".\"USUARIO_RUT\" = '" + rut + "'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return horaFin;
                } while (reader.Read())
                {
                    return horaFin = reader["horaFin"].ToString();
                }
                cn.Close();
            }
            return horaFin;
        }

        //Consulta para recuperar el id del servicio correspondiente al turno y a la hora actual 
        public int consultaIdServicio(int idTurno) {

            int idServicio = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"t\".\"SERVICIO_IDSERVICIO\" AS \"ID\"FROM \"SISTEMA\".\"TURNO_SERVICIO\" \"t\" join \"SISTEMA\".\"SERVICIO\" \"s\" ON (\"t\".\"SERVICIO_IDSERVICIO\" = \"s\".\"IDSERVICIO\")WHERE \"TURNO_IDTURNO\" = '" + idTurno + "'AND to_char(sysdate,'HH24:MM:SS') BETWEEN TO_CHAR(\"s\".\"SE_INICIO\",'HH24:MM:SS') AND TO_CHAR(\"s\".\"SE_TERMINO\",'HH24:MM:SS')";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return idServicio;
                } while (reader.Read())
                {
                    return idServicio = Convert.ToInt32(reader["ID"]);
                }
                cn.Close();
            }
            return idServicio;
        }
        //devuelve el valor del servicio dependiendo del id del servicio
        public int consultaValorPorIdServicio(int idServicio)
        {

            int valor = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"PE_VALOR\" from \"SISTEMA\".\"PERFIL_SERVICIO\" where \"SERVICIO_IDSERVICIO\" = '"+idServicio+"'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return valor;
                } while (reader.Read())
                {
                    return valor = Convert.ToInt32(reader["PE_VALOR"]);
                }
                cn.Close();
            }
            return valor;
        }
    }
}
