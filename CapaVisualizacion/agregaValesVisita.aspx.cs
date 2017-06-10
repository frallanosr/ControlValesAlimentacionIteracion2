using CapaDatos.RepositoryTicket;
using CapaDatos.RepositoryUsuarios;
using CapaDatos.RepositoryVales;
using CapaLogica.Login;
using CapaLogica.Vales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrearTicketVenta;
using CapaDatos.RepositoryUsuarioTurno;

namespace CapaVisualizacion
{  
    
    public partial class agregaValesVisita : System.Web.UI.Page
    {
          ImprimeTicket imp = new ImprimeTicket();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn1_Click(object sender, EventArgs e)
        {

            /*genera la clase para validar el rut */
            FormatoRut vali = new FormatoRut();

            UsuariosRepository usu = new UsuariosRepository();

            

            /*rut especial para generar vales de visita */
            string rut = "11.111.111-1";
            /*elimina puntos y guiones */
            string rutSinPniG = rut.Replace(".", "").Replace("-", "");
            /* valida el rut*/
            bool validacion = vali.validarRut(rutSinPniG);
            /*se pregunta si la validacion es exitosa o no  */
            if (validacion != true)
            {
                Response.Write("<script>alert('RUT INVALIDO!!')</script>");
            }
            else if (usu.verificaSiExisteUsuario(rutSinPniG) != true)
            {
                Response.Write("<script>alert('EL USUARIO NO EXISTE!!')</script>");
               
            }
            else 
            {
                ImprimeTicket ipt = new ImprimeTicket();

                /* crea variable para acceder a los metodos */
                ValesRepository va = new ValesRepository();
                /*el turno es el especial por eso es fijo */
                int turno = ipt.idTurnoPorRut(rutSinPniG);

                /*extrae valor de la bdd dependiendo del turno que en este caso el fijo */
                int valorVale = va.valorPerfilEspecial(4);
                /*extrae la cantidad de vales al imprimir */
                int cant = 1;
                
                /*Se establece la fecha neutra*/
                
                
                DateTime date1 = DateTime.Now;
                DateTime fechaAsig = date1;


                /*genera la clase para ser llenada */
                ValesEspeciales v = new ValesEspeciales(valorVale, 1, 0, 1, 1, rutSinPniG, turno, fechaAsig, cant);

                ValesRepository vr = new ValesRepository();

                vr.insertaValesEspeciales(v);


/*------------------------------------------------------------------------------ */
             UsuarioTurnoRepository usuTur = new UsuarioTurnoRepository();
               ValesRepository vl = new ValesRepository();

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
             ticket.TextoIzquierda("VALE DE VISITA");
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
                int idTurno = imp.idTurnoPorRut(rutSinPniG);
                //mediante el id del turno y la hora actual se obtiene el id del servicio
                int idServ = Convert.ToInt32(imp.consultaIdServicioEspecial(idTurno));
                //mediante el id del servicio se obtiene el nombre de este
                string nombreServicio = t.NombreServicioPorId(idServ);
                //mediante el rut se extrae el id del perfil del usuario
                int idPerfil = imp.extraeIdPerfilPorRut(rutSinPniG);
                //mediante el id del servicio se obtiene el valor de este 
                decimal value = t.valorServicio(idPerfil,idServ);

                ticket.AgregaArticulo(nombreServicio, 1, value);
             ticket.lineasIgual();

                //Resumen de la venta. Sólo son ejemplos

                //Texto final del Ticket.
                ticket.lineasAsteriscos();

                ticket.TextoCentro("Numero de Vale: "+vl.extraUltimoIdVale(rutSinPniG).ToString());    

                ticket.lineasAsteriscos();
                ticket.TextoIzquierda("");
                ticket.TextoCentro("¡Complete su pedido en caja!");
                ticket.CortaTicket();
                ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

            }
           



        }

    }
}