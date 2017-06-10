using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica.Servicio;
using CapaDatos.RepositoryServicio;
using CapaLogica.PerfilServicio;
using CapaDatos.RepositoryPerfilServicio;

namespace CapaVisualizacion
{
    public partial class agregaServicio : System.Web.UI.Page
    {
        ServicioRepository rs = new ServicioRepository();
        PerfilServicio ps = null;
        Servicio s = null;
        PerfilServicioRepository psr = new PerfilServicioRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.horaInicio.Text == "")
            {
                string nombreServicio = this.nombreDelServicio.Text;
                int idperfil = Convert.ToInt32(this.DropDownList1.Text);
                int valorServicio = Convert.ToInt32(this.valorDelServicio.Text);

                
                DateTime hI = Convert.ToDateTime("12:00:00");
                DateTime hF = Convert.ToDateTime("11:59:00");

                //llena la clase servicio
                s = new Servicio(nombreServicio,hI, hF);

                //inserta servicio
                rs.insertaServicio(s);

                //buscael ultimo registro del servicio
                int id = rs.buscaUltimoRegistro();

                //llena la clae perfilservicio
                ps = new PerfilServicio(valorServicio, idperfil, id);

                //llena la tabla perfilservicio
                psr.insertaPerfilServicio(ps);

                //Actualiza el gridview
                GridView1.DataBind();
            }
            else { 
            string nombreServicio = this.nombreDelServicio.Text;
            int idperfil = Convert.ToInt32(this.DropDownList1.Text);
            int valorServicio = Convert.ToInt32(this.valorDelServicio.Text);
            DateTime horaInicio = Convert.ToDateTime(this.horaInicio.Text);
            DateTime horaFin = Convert.ToDateTime(this.horaFin.Text);

            //llena la clase servicio
            s = new Servicio(nombreServicio,horaInicio,horaFin);

            //inserta servicio
            rs.insertaServicio(s);

            //buscael ultimo registro del servicio
            int id = rs.buscaUltimoRegistro();

            //llena la clae perfilservicio
            ps = new PerfilServicio(valorServicio, idperfil,id);

            //llena la tabla perfilservicio
            psr.insertaPerfilServicio(ps);
            
            //Actualiza el gridview
            GridView1.DataBind();
            }
        }
    }
}