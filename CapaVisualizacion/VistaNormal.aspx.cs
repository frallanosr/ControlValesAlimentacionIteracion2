
using CrearTicketVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos.RepositoryUsuarios;
using CapaDatos.RepositoryTicket;
using CapaDatos.RepositoryUsuarioTurno;
using CapaLogica.Vales;
using CapaDatos.RepositoryVales;

namespace CapaVisualizacion
{
    public partial class VistaNormal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.cantidadVales.Text = Convert.ToString(2);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx");
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {

            //if (Session["rut_UsuarioNormal"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            //else {
            //    string rutNormal = Convert.ToString(Session["rut_UsuarioNormal"]);

            //    UsuarioTurnoRepository usuTur = new UsuarioTurnoRepository();
            //    ValesRepository vl = new ValesRepository();

            //    Vales v = new Vales(200,1,0,1,1,usuTur.buscaIdTurno(rutNormal));

            //    vl.insertaVales(v);


            //    UsuariosRepository usu = new UsuariosRepository();
            //    String name = usu.nombreUsuario(rutNormal);
            //    //Creamos una instancia d ela clase CrearTicket
            //    CrearTicket ticket = new CrearTicket();
            //    //Ya podemos usar todos sus metodos
            //    ticket.AbreCajon();//Para abrir el cajon de dinero.

            //    //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //    //Datos de la cabecera del Ticket.
            //    ticket.TextoCentro("SETA");
            //    ticket.TextoIzquierda("EXPEDIDO EN: Casino N° ###");
            //    ticket.lineasAsteriscos();

            //    //Sub cabecera.
            //    ticket.TextoIzquierda("");
            //    ticket.TextoIzquierda("Nombre de Usuario: " + name + " ");
            //    ticket.TextoIzquierda("");
            //    ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
            //    ticket.lineasAsteriscos();

            //    //Articulos a vender.
            //    ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            //    ticket.lineasAsteriscos();
            //    //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
            //    //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
            //    //{
            //    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
            //    //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
            //    //}
            //    ImprimeTicket t = new ImprimeTicket();
            //    string nombreServicio = t.NombreServicioPorRut(rutNormal);
            //    decimal value = t.valorServicio(rutNormal);

            //    ticket.AgregaArticulo(nombreServicio, 1, value);
            //    ticket.lineasIgual();

            //    //Resumen de la venta. Sólo son ejemplos

            //    //Texto final del Ticket.

            //    ticket.TextoIzquierda("");
            //    ticket.TextoCentro("¡Complete su pedido en caja!");
            //    ticket.CortaTicket();
            //    ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

            //    Response.Redirect("logout.aspx");

           // }

           
        }
    }
}
