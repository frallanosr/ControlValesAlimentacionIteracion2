using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica.Servicio;
using CapaDatos.RepositoryServicio;

namespace CapaVisualizacion
{
    public partial class agregaServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombreServicio = this.nombreDelServicio.Text;
            string nombrePerfil = this.DropDownList1.Text;
            int valorServicio = Convert.ToInt32(this.valorDelServicio.Text);
            DateTime horaInicio = Convert.ToDateTime(this.horaInicio.Text);
            DateTime horaFin = Convert.ToDateTime(this.horaFin.Text);

            Servicio s = new Servicio(nombreServicio,nombrePerfil,valorServicio,horaInicio,horaFin);

            ServicioRepository se = new ServicioRepository();

            se.insertaServicio(s);

            GridView1.DataBind();

        }
    }
}