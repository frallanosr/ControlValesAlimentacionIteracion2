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
using CapaLogica.Login;
using CapaDatos.RepositoryUsuarios;


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
      
            /*genera la clase para validar el rut */
            FormatoRut vali = new FormatoRut();

            UsuariosRepository usu = new UsuariosRepository();

            DateTime fecha_nac = Convert.ToDateTime(fechatxt.Text);
            int result = DateTime.Compare(fecha_nac, DateTime.Today);

            /*extrae el rut del formulario */
            string rut = this.rut_empleado.Text;
            /*elimina puntos y guiones */
            string rutSinPniG = rut.Replace(".","").Replace("-","");
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
                this.rut_empleado.Text = "";
                this.cantidad.Text = "";
                this.fechatxt.Text = "";
            }
            else if (result < 0)
            {
                Response.Write("<script>alert('LA FECHA DEBE SER MAYOR O IGUAL A LA ACTUAL!!')</script>");
                this.fechatxt.Text = "";
            }
            else if (result == 0)
            {
                ImprimeTicket ipt = new ImprimeTicket();

                /* crea variable para acceder a los metodos */
                ValesRepository va = new ValesRepository();
                /*el turno es el especial por eso es fijo */
                int turno = ipt.idTurnoPorRut(rutSinPniG);

                /*extrae valor de la bdd dependiendo del turno que en este caso el fijo */
                int valorVale = va.valorPerfilEspecial(4);
                /*extrae la cantidad de vales al imprimir */
                int cant = Convert.ToInt32(this.cantidad.Text);
                /*extrae la fecha a la que se va a asignar el vale */
                DateTime fechaAsig = Convert.ToDateTime(this.fechatxt.Text);


                /*genera la clase para ser llenada */
                ValesEspeciales v = new ValesEspeciales(valorVale, 0, 0, 1, 1, rutSinPniG, turno, fechaAsig, cant);

                ValesRepository vr = new ValesRepository();

                vr.insertaValesEspeciales(v);
                Response.Write("<script>alert('VALE GENERADO CON EXITO')</script>");
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
                int cant = Convert.ToInt32(this.cantidad.Text);
                /*extrae la fecha a la que se va a asignar el vale */
                DateTime fechaAsig = Convert.ToDateTime(this.fechatxt.Text);


                /*genera la clase para ser llenada */
                ValesEspeciales v = new ValesEspeciales(valorVale, 0, 0, 1, 1, rutSinPniG, turno, fechaAsig, cant);

                ValesRepository vr = new ValesRepository();

                vr.insertaValesEspeciales(v);
                Response.Write("<script>alert('VALE GENERADO CON EXITO')</script>");

            }



        }


    }
 }
