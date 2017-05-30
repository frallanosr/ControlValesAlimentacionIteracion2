using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogica.Vales;
using CapaDatos.RepositoryVales;
using CrearTicketVenta;
using CapaDatos.RepositoryTicket;

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
            int cant = Convert.ToInt32(this.cantidad.Text);
            



            Vales v = new Vales(valorVale, 1, 0, 1, 1, Convert.ToString(Session["rut_administrador"]),1);
            // Vales v = new Vales(valorVale,nombrePerfil,v_impreso,v_usado,casino_idcasino, turno);

            ValesRepository vr = new ValesRepository();



            vr.insertaVales(v);

            this.GridView1.DataBind();


            //Creamos una instancia d ela clase CrearTicket
            CrearTicket ticket = new CrearTicket();
            //Ya podemos usar todos sus metodos
            ticket.AbreCajon();//Para abrir el cajon de dinero.

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
            ticket.TextoCentro("SETA");
            ticket.TextoIzquierda("EXPEDIDO EN: Casino N° ###");
            ticket.lineasAsteriscos();

            //Sub cabecera.
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Tipo de Perfil: " + nombrePerfil + " ");
            ticket.TextoIzquierda("");
            ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            ticket.lineasAsteriscos();

            //Articulos a vender.
            ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasAsteriscos();
            //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
            //{
            //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
            //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            //}
            ImprimeTicket t = new ImprimeTicket();



            ////extrae el id del turno
            //int idTurno = imp.idTurnoPorRut(Convert.ToString(Session["rut_UsuarioNormal"]));
            ////mediante el id del turno y la hora actual se obtiene el id del servicio
            //int idServ = Convert.ToInt32(imp.consultaIdServicio(idTurno));
            ////mediante el id del servicio se obtiene el nombre de este
            //string nombreServicio = t.NombreServicioPorId(idServ);
            ////mediante el rut se extrae el id del perfil del usuario
            //int idPerfil = imp.extraeIdPerfilPorRut(Convert.ToString(Session["rut_UsuarioNormal"]));
            ////mediante el id del servicio se obtiene el valor de este 
            //decimal value = t.valorServicio(idPerfil, idServ);
            string g = "Personalizado";
            int vTot = cant * valorVale;
            ticket.AgregaArticulo(g, cant, vTot);
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos

            //Texto final del Ticket.
            ticket.lineasAsteriscos();

            ValesRepository vl = new ValesRepository();
            string rutNormal = Session["rut_administrador"].ToString();
            ticket.TextoCentro("Numero de Vale: " + vl.extraUltimoIdVale(rutNormal).ToString());

            ticket.lineasAsteriscos();
            ticket.TextoIzquierda("");
            ticket.TextoCentro("¡Complete su pedido en caja!");
            ticket.CortaTicket();
            ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
        }
    }
}