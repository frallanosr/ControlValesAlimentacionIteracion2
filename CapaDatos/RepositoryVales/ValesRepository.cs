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

        public void insertaVales(Vales v)
        {
           using (OracleConnection cn = new OracleConnection(this.conexion))
            {
               OracleCommand cmd = new OracleCommand();
               cmd.Connection = cn;
               cmd.CommandText = "INSERT INTO \"SISTEMA\".\"VALE\" (\"IDVALE\", \"V_VALOR\", \"V_IMPRESO\", \"V_USADO\", \"TURNO_IDTURNO\",\"V_NOMBREPERFIL\") VALUES (v_sequence.nextval, '"+v.valor+"', '"+v.v_impreso+"', '"+v.v_usado+"', '"+v.turno_idturno+"','"+v.nombrePerfil+"')";

               cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
           }
        }



    }
}
