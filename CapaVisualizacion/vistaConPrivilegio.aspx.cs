using CapaDatos.RepositoryTicket;
using CapaDatos.RepositoryUsuarios;
using CapaDatos.RepositoryUsuarioTurno;
using CapaDatos.RepositoryVales;
using CapaLogica.Vales;
using CrearTicketVenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaVisualizacion
{
    public partial class vistaConPrivilegio : System.Web.UI.Page
    {
        ImprimeTicket imp = new ImprimeTicket();

        /* */
        ValesRepository vl = new ValesRepository();
        /* */
        int cantidadValesEspeciales = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string nameTurno = imp.extraeNombreDeTurnoPorRut(Convert.ToString(Session["rut_conPrivilegios"]));
            /* */
            this.nombreTurno.Text = nameTurno;
            /* */
            int v = imp.idTurnoPorRut(Convert.ToString(Session["rut_conPrivilegios"]));
            /* */
            string rut = Convert.ToString(Session["rut_conPrivilegios"]);
            /* */
            cantidadValesEspeciales = vl.extraeNumeroDeValesEspeciales(rut);
            /* SI tiene vales especiales y esta en su horario de servicio correspondiente 
               se desactiva el boton de ticket especial y solo queda el de imprimir normal*/
            if (cantidadValesEspeciales > 0 && imp.consultaIdServicio(v) > 0)
            {
                if (imp.consultaSiExisteVale(v, Convert.ToString(Session["rut_conPrivilegios"])) != true)
                {
                    this.Button3.Enabled = false;
                    this.Button3.Visible = false;
                    this.Button1.Enabled = true;
                }
                else if (cantidadValesEspeciales > 0)
                {
                    this.nombreTurno.Text = "UD TIENE " + cantidadValesEspeciales + " VALES ESPECIALES";
                    this.Button1.Enabled = false;
                    this.Button1.Visible = false;
                    this.Button3.Enabled = true;
                    this.Button3.Visible = true;
                }
                else
                {

                    this.Button3.Enabled = false;
                    this.Button3.Visible = false;
                    this.Button1.Visible = true;
                    this.Button1.Enabled = false;
                }

            }
            /*si existen vales especiales y no esta dentro del horario de servicio 
            se activa el boton de imprecion de ticket especial y se desactiva el normal */
            else if (cantidadValesEspeciales > 0)
            {
                this.nombreTurno.Text = "UD TIENE " + cantidadValesEspeciales + " VALES ESPECIALES";
                this.Button1.Enabled = false;
                this.Button1.Visible = false;

                this.rb1.Enabled = false;
                this.rb2.Enabled = false;
                this.rb3.Enabled = false;
                this.rb4.Enabled = false;
                this.rb5.Enabled = false;

                this.Button3.Enabled = true;
                this.Button3.Visible = true;
            }
            /*si esta en el horario pero ya se emitio el vale*/
            else if (imp.consultaIdServicio(v) != 0 && imp.consultaSiExisteVale(v, Convert.ToString(Session["rut_conPrivilegios"])) == true)
            {
                //this.cantidadVales.Text = Convert.ToString(0);
                this.nombreTurno.Text = "SU VALE YA FUE EMITIDO";
                this.Button1.Enabled = false;
                this.Button3.Enabled = false;
                this.Button3.Visible = false;
            }
            /* */
            else if (imp.consultaIdServicio(v) == 0)
            {
                if (cantidadValesEspeciales > 0)
                {
                    this.nombreTurno.Text = "UD TIENE " + cantidadValesEspeciales + " VALES ESPECIALES";
                    this.Button1.Enabled = false;
                    this.Button1.Visible = false;

                    this.Button3.Enabled = true;
                    this.Button3.Visible = true;
                }
                else
                {
                    this.rb1.Enabled = false;
                    this.rb2.Enabled = false;
                    this.rb3.Enabled = false;
                    this.rb4.Enabled = false;
                    this.rb5.Enabled = false;

                    this.nombreTurno.Text = "SU TURNO NO CORRESPONDE A ESTE HORARIO (" + nameTurno + ")";
                    this.Button1.Visible = true;
                    this.Button1.Enabled = false;
                    this.Button3.Enabled = false;
                    this.Button3.Visible = false;
                }
            }
            /* */
            else
            {
            

                this.Button1.Visible = true;
                this.Button1.Enabled = true;
                this.Button3.Enabled = false;
                this.Button3.Visible = false;

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int cant =0;

            if(this.rb1.Checked == true)
            {
                cant = 1;
            }else if(this.rb2.Checked == true)
            {
                cant = 2;
            }else if(this.rb3.Checked == true)
            {
                cant = 3;
            }else if(this.rb4.Checked == true)
            {
                cant = 4;
            }else if(this.rb5.Checked == true)
            {
                cant = 5;
            }
            
            for (int i = 1; i <= cant; i++)
            {
                    //rescata el id del servicio que corresponde dependiendo de la hora actual
                int idServicio = imp.consultaIdServicio(imp.idTurnoPorRut(Convert.ToString(Session["rut_conPrivilegios"])));

                if (Session["rut_conPrivilegios"] == null)
                {

                    Response.Redirect("logout.aspx");
                }
                else
                {
                    string rutNormal = Convert.ToString(Session["rut_conPrivilegios"]);

                    UsuarioTurnoRepository usuTur = new UsuarioTurnoRepository();
                    ValesRepository vl = new ValesRepository();

                    int tot = imp.consultaValorPorIdServicio(idServicio);

                    DateTime fec = DateTime.Now;

                    ValesEspeciales v = new ValesEspeciales(tot, 1, 0, 1, 1, Convert.ToString(Session["rut_conPrivilegios"]), usuTur.buscaIdTurno(rutNormal),fec,1);

                    vl.insertaValesEspeciales(v);


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
                    int idTurno = imp.idTurnoPorRut(Convert.ToString(Session["rut_conPrivilegios"]));
                    //mediante el id del turno y la hora actual se obtiene el id del servicio
                    int idServ = Convert.ToInt32(imp.consultaIdServicio(idTurno));
                    //mediante el id del servicio se obtiene el nombre de este
                    string nombreServicio = t.NombreServicioPorId(idServ);
                    //mediante el rut se extrae el id del perfil del usuario
                    int idPerfil = imp.extraeIdPerfilPorRut(Convert.ToString(Session["rut_conPrivilegios"]));
                    //mediante el id del servicio se obtiene el valor de este 
                    decimal value = t.valorServicio(idPerfil, idServ);

                    decimal total = cant * value;

                    ticket.AgregaArticulo(nombreServicio, cant, total);
                    ticket.lineasIgual();

                    //Resumen de la venta. Sólo son ejemplos

                    //Texto final del Ticket.
                    ticket.lineasAsteriscos();

                    ticket.TextoCentro("Numero de Vale: " + vl.extraUltimoIdVale(rutNormal).ToString());

                    ticket.lineasAsteriscos();
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("¡Complete su pedido en caja!");
                    ticket.CortaTicket();
                    ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

                    
                }
                
            }
            Response.Redirect("logout.aspx");


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (cantidadValesEspeciales > 0)
            {

                /*Se ejecuta si tiene vales especiales */

                /*Resta 1 a la cantidad de vales especiales para luego actualizarlos */
                cantidadValesEspeciales = cantidadValesEspeciales - 1;
                /*Actualiza numero de vales especiales */
                vl.cambiaNumeroValesEspeciales(cantidadValesEspeciales, Convert.ToString(Session["rut_conPrivilegios"]));

                //rescata el id del servicio que corresponde dependiendo de la hora actual
                int idServicio = imp.consultaIdServicio(4);

                /*Consulta nuevamente si la sesion esta activa */
                if (Session["rut_conPrivilegios"] == null)
                {
                    /*Si no esta activa redirecciona a la pagina de login */
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    /*Si esta activa la sesion se ejecuta este bloque */

                    /*Se genera la clase de Imprime Ticket */
                    ImprimeTicket t = new ImprimeTicket();

                    /*Se extrae el rut del usuario */
                    string rutNormal = Convert.ToString(Session["rut_conPrivilegios"]);

                    /*Se genera la clase UsuarioTurnoRepository */
                    UsuarioTurnoRepository usuTur = new UsuarioTurnoRepository();

                    /*Genera una variable Tipo DateTime la cual se inicializa con la fecha y hora actual del sistema */
                    DateTime fe = DateTime.Today;
                    /*extrae el id del servicio*/
                    int ids = Convert.ToInt32(imp.consultaIdServicioEspecial(4));

                    /*La diferencia entre vales y vales especiales es que vale no contiene v_fecha_especial ni v_cantidad */
                    /*Se genera y llena la clase de Vales Especial  */
                    ValesEspeciales v = new ValesEspeciales(imp.consultaValorPorIdServicio(ids), 1, 0, 1, 1, Convert.ToString(Session["rut_conPrivilegios"]), usuTur.buscaIdTurno(rutNormal), fe, 0);

                    /*se insertan los dato en la tabla */
                    vl.insertaValesEspeciales(v);

                    /* Se genera la clase de usuarios repository */
                    UsuariosRepository usu = new UsuariosRepository();

                    /*la variable name se inicializa con el nombre del usuario obtenido mediante el rut */
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

                    //mediante el id del turno y la hora actual se obtiene el id del servicio
                    int idServ = Convert.ToInt32(imp.consultaIdServicioEspecial(4));
                    //mediante el id del servicio se obtiene el nombre de este
                    string nombreServicio = t.NombreServicioPorId(idServ);
                    //mediante el rut se extrae el id del perfil del usuario
                    int idPerfil = imp.extraeIdPerfilPorRut(Convert.ToString(Session["rut_conPrivilegios"]));
                    //mediante el id del servicio se obtiene el valor de este 
                    decimal value = t.valorServicioEspecial(idServ);

                    ticket.AgregaArticulo(nombreServicio, 1, value);
                    ticket.lineasIgual();

                    //Resumen de la venta. Sólo son ejemplos

                    //Texto final del Ticket.
                    ticket.lineasAsteriscos();

                    ticket.TextoCentro("Numero de Vale: " + vl.extraUltimoIdVale(rutNormal).ToString());

                    ticket.lineasAsteriscos();
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("¡Complete su pedido en caja!");
                    ticket.CortaTicket();
                    ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

                    /*este if actualiza la variable v_impreso de la tabla vale para que la fila ya o se encuentre con vales disponibles  */
                    if (cantidadValesEspeciales == 0)
                    {
                        vl.actualizaVariableImpreso(rutNormal);
                    }

                    /*redicciona a la vista normal para que vuelva a ser capturada por el page load y asi se actualicen los datos en pantalla */
                    Response.Redirect("vistaConPrivilegio.aspx");
                }
            }

        }
    }
}