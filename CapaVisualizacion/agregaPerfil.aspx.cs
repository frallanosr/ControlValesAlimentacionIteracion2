using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica.Perfil;
using CapaDatos.RepositoryPerfil;

namespace CapaVisualizacion
{
    public partial class agregaPerfil : System.Web.UI.Page
    {
        PerfilRepository per = new PerfilRepository();
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


            }
        }

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        
        protected void Button2_Click(object sender, EventArgs e)
        {
            
            string nombrePerfil = this.nombrePerfil.Text;
            string descripcion = this.DropDownList1.Text;
            int activo = 1;
            Perfil p = new Perfil(nombrePerfil,activo,descripcion);
            per.insertaPerfil(p);
            this.GridView1.DataBind();
        }
    }
}