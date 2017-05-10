using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos.RepositoryUsuarios;

namespace CapaVisualizacion
{
    public partial class homeAdministrador : System.Web.UI.Page
    {
        UsuariosRepository usu = new UsuariosRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["rut_administrador"] == null)
            {
                Response.Write("<script>alert('ACCESO DENEGADO!!')</script>");
            }
            else {
                string rut = Session["rut_administrador"].ToString();
                
            }
            

            
        }
    }
}