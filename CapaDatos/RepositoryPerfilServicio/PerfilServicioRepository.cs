using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica.PerfilServicio;

namespace CapaDatos.RepositoryPerfilServicio
{
    public class PerfilServicioRepository
    {
        private string conexion;

        public PerfilServicioRepository()
        {
            this.conexion = ConfigurationManager.ConnectionStrings["ConOracle"].ToString();
        }

        public void insertaPerfilServicio(PerfilServicio s)
        {
            using (OracleConnection cn = new OracleConnection(this.conexion))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO \"SISTEMA\".\"PERFIL_SERVICIO\" (\"PE_VALOR\", \"PERFIL_IDPERFIL\", \"SERVICIO_IDSERVICIO\") VALUES ('"+s.pe_valor+"','"+s.idPerfil+"','"+s.idServicio+"')";

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
