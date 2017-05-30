using CapaDatos.RepositoryUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaVisualizacion
{
    public partial class maestraTotemPrivilegio : System.Web.UI.MasterPage
    {
        UsuariosRepository usu = new UsuariosRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
           
      
            if (Session["rut_conPrivilegios"] == null)
            {

                Response.Redirect("Login.aspx");
                Response.Write("<script>alert('ACCESO DENEGADO!!')</script>");
            }
            else
            {
                string rut = Session["rut_conPrivilegios"].ToString();
                this.nombreUsuario.Text = usu.nombreUsuario(rut);

            }
        }
    
    }
}