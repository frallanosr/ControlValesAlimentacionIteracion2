using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica.Vales;
using CapaDatos.RepositoryVales;

namespace CapaVisualizacion
{
    public partial class agregaVales : System.Web.UI.Page
    {
       
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

        protected void Btn1_Click(object sender, EventArgs e)
        {
            string nombrePerfil = this.DropDownList3.Text;
            int valorVale = Convert.ToInt32(this.valorVale.Text);
            int turno = Convert.ToInt32(this.DropDownList2.Text);
            int v_impreso = 0;
            int v_usado = 0;
            int casino_idcasino = 1;

            Vales v = new Vales(valorVale,nombrePerfil,v_impreso,v_usado,casino_idcasino, turno);

           ValesRepository vr = new ValesRepository();

           vr.insertaVales(v);

            this.GridView1.DataBind();
        }
    }
}