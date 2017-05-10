using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos.RepositoryUsuarios;
using CapaLogica.Usuario;

namespace CapaVisualizacion
{
    public partial class maestraAdministrador : System.Web.UI.MasterPage
    {
        UsuariosRepository usu = new UsuariosRepository();

        private Usuario u;
        public String rut = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rut_administrador"] == null)
            {
                
                Response.Redirect("Login.aspx");
                Response.Write("<script>alert('ACCESO DENEGADO!!')</script>");
            }
            else
            {
                string rut = Session["rut_administrador"].ToString();
                Label1.Text = usu.nombreAdministrador(rut);
                
            }
        }
    }
}