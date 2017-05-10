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
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"SERVICIO\" (\"IDSERVICIO\", \"SE_NOMBRE\", \"SE_VALOR\", \"SE_INICIO\", \"SE_TERMINO\", \"SE_NOMBREPERFIL\")VALUES(s_sequence.nextval, '"+s.nombre+"', '"+s.valorServicio+ "',TO_DATE('" + s.horaInicio+ "', 'DD/MM/YYYY HH24:MI:SS'),TO_DATE('" + s.horaFin+ "', 'DD/MM/YYYY HH24:MI:SS'), '" + s.nombrePerfil+"')";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        } 
    }
}
