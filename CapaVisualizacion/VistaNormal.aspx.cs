
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
        ImprimeTicket imp = new ImprimeTicket();

        protected void Page_Load(object sender, EventArgs e)
        {
            

            string nameTurno = imp.extraeNombreDeTurnoPorRut(Convert.ToString(Session["rut_UsuarioNormal"]));
            this.nombreTurno.Text = nameTurno;
            int v = imp.idTurnoPorRut(Convert.ToString(Session["rut_UsuarioNormal"]));

            if (imp.consultaIdServicio(v) == 0)
            {
                //this.cantidadVales.Text = Convert.ToString(0);
                
                this.Button1.Enabled = false;
            }
            else {

                this.Button1.Enabled = true;
            }
            
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx");
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            //rescata el id del servicio que corresponde dependiendo de la hora actual
            int idServicio = imp.consultaIdServicio(imp.idTurnoPorRut(Convert.ToString(Session["rut_UsuarioNormal"])));

            if (Session["rut_UsuarioNormal"] == null)
           {
               Response.Redirect("logout.aspx");
           }
           else {
               string rutNormal = Convert.ToString(Session["rut_UsuarioNormal"]);

              UsuarioTurnoRepository usuTur = new UsuarioTurnoRepository();
               ValesRepository vl = new ValesRepository();

               
               Vales v = new Vales(imp.consultaValorPorIdServicio(idServicio),1,0,1,1,Convert.ToString(Session["rut_UsuarioNormal"]), usuTur.buscaIdTurno(rutNormal));

             vl.insertaVales(v);


             UsuariosRepository usu = new UsuariosRepository();

             String name = usu.nombreUsuario(rutNormal);

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
             ticket.TextoIzquierda("Nombre de Usuario: " + name + " ");
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
             
             

                //extrae el id del turno
                int idTurno = imp.idTurnoPorRut(Convert.ToString(Session["rut_UsuarioNormal"]));
                //mediante el id del turno y la hora actual se obtiene el id del servicio
                int idServ = Convert.ToInt32(imp.consultaIdServicio(idTurno));
                //mediante el id del servicio se obtiene el nombre de este
                string nombreServicio = t.NombreServicioPorId(idServ);
                //mediante el rut se extrae el id del perfil del usuario
                int idPerfil = imp.extraeIdPerfilPorRut(Convert.ToString(Session["rut_UsuarioNormal"]));
                //mediante el id del servicio se obtiene el valor de este 
                decimal value = t.valorServicio(idPerfil,idServ);

                ticket.AgregaArticulo(nombreServicio, 1, value);
             ticket.lineasIgual();

                //Resumen de la venta. Sólo son ejemplos

                //Texto final del Ticket.
                ticket.lineasAsteriscos();

                ticket.TextoCentro("Numero de Vale: "+vl.extraUltimoIdVale(rutNormal).ToString());    

                ticket.lineasAsteriscos();
                ticket.TextoIzquierda("");
                ticket.TextoCentro("¡Complete su pedido en caja!");
                ticket.CortaTicket();
                ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

             Response.Redirect("logout.aspx");

           }


        }

       
    }
}
