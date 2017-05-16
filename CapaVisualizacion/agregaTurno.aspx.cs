using CapaDatos.RepositoryTurno;
using CapaLogica.Turno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaVisualizacion
{
    public partial class agregaTurno : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombre = this.nombreDelTurno.Text;
            DateTime inicio = Convert.ToDateTime(this.horaInicio.Text);
            DateTime fin = Convert.ToDateTime(this.horaFin.Text);

            Turno t = new Turno(nombre, inicio, fin);

            TurnoRepository agrega = new TurnoRepository();

            agrega.insertaTurno(t);
        }
    }
}