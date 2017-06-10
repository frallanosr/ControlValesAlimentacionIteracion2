using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.Vales;
using System.Configuration;
using Oracle.DataAccess.Client;

namespace CapaDatos.RepositoryVales
{
    public class ValesRepository
    {
        private string conexion;

        public ValesRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }

        //public int insertaVale(Vales v)
        //{

        //    int idVale = 0;
        //    using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
        //    {


        //cn.Open();
        //        OracleCommand command = cn.CreateCommand();
        //        command.CommandText = "EXEC insertaVale('"+v.valor+"','"+v.v_impreso+"','"+v.v_usado+"','"+v.v_normal+"','"+v.casino_idcasino+"','"+v.rut_usuario+"','"+v.turno_idturno+"')";
        //        OracleDataReader reader = command.ExecuteReader();
        //        if (!reader.HasRows)//si no tiene regitros
        //        {
        //            return idVale;
        //        } while (reader.Read())//llenando la lista con objetos tipo usuario
        //        {
        //            return idVale = (int)reader["insertaVale"];
        //        }
        //        cn.Close();
        //    }
        //    return idVale;
        //}


        public void insertaValesEspeciales(ValesEspeciales v)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"VALE\" (\"IDVALE\", \"V_VALOR\", \"V_IMPRESO\", \"V_USADO\",\"V_NORMAL\", \"CASINO_IDCASINO\",\"USUARIO_TURNO_USUARIO_RUT\",\"USUARIO_TURNO_TURNO_IDTURNO\",\"V_FECHA_ESPECIAL\",\"V_CANTIDAD\") VALUES (v_sequence.nextval, '" + v.valor + "', '" + v.v_impreso + "', '" + v.v_usado + "','" + v.v_normal + "', '" + v.casino_idcasino + "','" + v.rut_usuario + "','" + v.turno_idturno + "',TO_DATE('" + v.v_fecha_especial + "', 'DD/MM/YYYY HH24:MI:SS'),'" + v.v_cantidad + "')";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void insertaVales(Vales v)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"VALE\" (\"IDVALE\", \"V_VALOR\", \"V_IMPRESO\", \"V_USADO\",\"V_NORMAL\", \"CASINO_IDCASINO\",\"USUARIO_TURNO_USUARIO_RUT\",\"USUARIO_TURNO_TURNO_IDTURNO\") VALUES (v_sequence.nextval, '" + v.valor + "', '" + v.v_impreso + "', '" + v.v_usado + "','" + v.v_normal + "', '" + v.casino_idcasino + "','" + v.rut_usuario + "','" + v.turno_idturno + "')";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        //public DataTable GetHeader_BySproc(string unit, string office, string receiptno)
        //{
        //    using (OracleConnection cn = new OracleConnection(DatabaseHelper.GetConnectionString()))
        //    {
        //        OracleDataAdapter da = new OracleDataAdapter();
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.Connection = cn;
        //        cmd.InitialLONGFetchSize = 1000;
        //        cmd.CommandText = DatabaseHelper.GetDBOwner() + "PKG_COLLECTION.CSP_COLLECTION_HDR_SELECT";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("PUNIT", OracleDbType.Char).Value = unit;
        //        cmd.Parameters.Add("POFFICE", OracleDbType.Char).Value = office;
        //        cmd.Parameters.Add("PRECEIPT_NBR", OracleDbType.Int32).Value = receiptno;
        //        cmd.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

        //        da.SelectCommand = cmd;
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

        public int extraUltimoIdVale(string rut)
        {
            int id = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT MAX(\"IDVALE\")AS \"ID\" FROM \"SISTEMA\".\"VALE\" WHERE \"USUARIO_TURNO_USUARIO_RUT\" = '" + rut + "'";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return id;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return id = Convert.ToInt32(reader["ID"]);
                }
                cn.Close();
            }
            return id;

        }

        public int valorPerfilEspecial(int turno)
        {
            int v = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"PE_VALOR\" FROM \"SISTEMA\".\"PERFIL_SERVICIO\" WHERE \"SERVICIO_IDSERVICIO\" = (select \"SERVICIO_IDSERVICIO\" from \"SISTEMA\".\"TURNO_SERVICIO\" WHERE \"TURNO_IDTURNO\" = '" + turno + "')";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return v;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return v = Convert.ToInt32(reader["PE_VALOR"]);
                }
                cn.Close();
            }
            return v;

        }
        public int extraeNumeroDeValesEspeciales(string rut)
        {
            int id = 0;
            using (OracleConnection cn = new OracleConnection(this.conexion))//crear conexion
            {
                cn.Open();
                OracleCommand command = cn.CreateCommand();
                command.CommandText = "SELECT \"V_CANTIDAD\" as \"cant\" from \"SISTEMA\".\"VALE\" where \"V_IMPRESO\" = 0 and \"USUARIO_TURNO_USUARIO_RUT\" = '" + rut + "' AND TO_CHAR(\"V_FECHA_ESPECIAL\",'DD') = TO_CHAR(SYSDATE,'DD')";
                OracleDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)//si no tiene regitros
                {
                    return id;
                } while (reader.Read())//llenando la lista con objetos tipo usuario
                {
                    return id = Convert.ToInt32(reader["cant"]);
                }
                cn.Close();
            }
            return id;

        }

        public void cambiaNumeroValesEspeciales(int numero, string rut)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE \"SISTEMA\".\"VALE\" SET \"V_CANTIDAD\"='" + numero + "' where \"USUARIO_TURNO_USUARIO_RUT\" = '" + rut + "' AND TO_CHAR(\"V_FECHA_ESPECIAL\",'DD') = TO_CHAR(SYSDATE,'DD') and \"V_IMPRESO\" = 0 ";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void actualizaVariableImpreso(string rut)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE \"SISTEMA\".\"VALE\" SET \"V_IMPRESO\"='" + 1 + "' where \"USUARIO_TURNO_USUARIO_RUT\" = '" + rut + "' AND TO_CHAR(\"V_FECHA_ESPECIAL\",'DD') = TO_CHAR(SYSDATE,'DD') and \"V_IMPRESO\" = 0 ";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
