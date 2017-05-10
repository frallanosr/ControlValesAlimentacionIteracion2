using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaLogica.Usuario;
using Oracle.DataAccess.Client;
using CapaLogica.Perfil;

namespace CapaDatos.RepositoryUsuarios
{
    public class UsuariosRepository
    {
        private string conexion;

        public UsuariosRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }

        public bool listaUsuario(string rut, string contraseña)
        {
            //List<Usuario> lista = new List<Usuario>();//creacion de la lista que contiene los usuarios
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "Select * from SISTEMA.USUARIO where \"RUT\" = '" + rut + "' and password = '" + contraseña + "'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return false;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return true;
                }
                cn.Close();
            }
            return false;
        }



        public string privilegio(string rut, string contraseña)
        {

            List<Usuario> lista = new List<Usuario>();
            string tipoUsuario = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT t.P_DESCRIPCION as \"privilegio\" from SISTEMA.PERFIL t join SISTEMA.USUARIO u on u.PERFIL_IDPERFIL = t.IDPERFIL where u.RUT = '"+rut+"' and u.PASSWORD = '"+contraseña+"'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return tipoUsuario;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return tipoUsuario = (string)reader["privilegio"];
                }
                cn.Close();
            }
            return tipoUsuario;

        }

        public string nombreAdministrador(string rut)
        {

            string nombreAdministrador = "";
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "Select \"US_NOMBRE\"||' '||\"US_PATERNO\"as \"nombre\" from SISTEMA.USUARIO where \"RUT\" = '" + rut + "' ";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return nombreAdministrador;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return nombreAdministrador = (string)reader["nombre"];
                }
                cn.Close();
            }
            return nombreAdministrador;

        }

        public void insertaUsuario(Usuario u)
        {
           using (OracleConnection cn = new OracleConnection(this.conexion))
            {
               OracleCommand cmd = new OracleCommand();
               cmd.Connection = cn;
               cmd.CommandText = "INSERT INTO \"SISTEMA\".\"USUARIO\" (\"RUT\", \"US_NOMBRE\", \"US_PATERNO\", \"US_MATERNO\", \"PASSWORD\",\"US_ESTADO\", \"PERFIL_IDPERFIL\", \"US_EMAIL\") VALUES ('"+u.rut+"', '"+u.us_nombre+"', '"+u.us_paterno+"', '"+u.us_materno+"', '"+u.password+"','"+u.us_estado+"', '"+u.idperfil+"', '"+u.email+"') ";

               cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
           }
        }

        public bool buscaContraseña(string con) {

            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "Select * from \"SISTEMA\".\"USUARIO\" where password = '"+con+"' and \"US_ESTADO\" = 1";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return false;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return true;
                }
                cn.Close();
            }
            return false;
        }
    }
}

