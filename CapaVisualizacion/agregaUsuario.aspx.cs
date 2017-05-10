using CapaDatos.RepositoryUsuarios;
using CapaDatos.RepositoryPerfil;
using CapaLogica.Perfil;
using CapaLogica.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaVisualizacion
{
    public partial class agregaUsuario : System.Web.UI.Page
    {
        UsuariosRepository usu = new UsuariosRepository();

        private Usuario u;
      
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
            //generamos la clase ex para extraer de busqueda de tipo de cargo 
            PerfilRepository ex = new PerfilRepository();

            string rut = this.rut.Text;
            string nombre = this.nombre.Text;
            string appaterno = this.appaterno.Text;
            string apmaterno = this.amaterno.Text;
            string email = this.email.Text;
            string pass = this.contraseña.Text;
            //se extrae el tipo de cargo de la tabla perfil mediante el id que proporciona el dropdownlist 
            String tipoUsuario = ex.tipoCargoExtraer(Convert.ToInt32(this.DropDownList1.Text));
            int estado = 1;
            int idperfil = Convert.ToInt32(this.DropDownList1.Text);

            // se genera la clase encri la cual tiene el proceso de encriptacion de la contraseña
            Encripta encri = new Encripta();

            // se genera la clase usuario la cual se llenara con los datos ingresados y se ocupa el proceso de encriptacion
            //que se genero anteriormente 
            Usuario u = new Usuario(rut, nombre, appaterno, apmaterno, email, encri.Encriptar(pass), tipoUsuario, estado,idperfil);
            //se crea la clase usuario que lleva el proceso insertaUsuario para entregar los datos para la insercion 
            UsuariosRepository usuario = new UsuariosRepository();
            usuario.insertaUsuario(u);
            
       

        }

        protected void rut_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Encripta en = new Encripta();
            Random r = new Random(DateTime.Now.Millisecond);
            int nAleatorio3 = r.Next(00000, 99999);
            
            if (usu.buscaContraseña(en.Encriptar(Convert.ToString(nAleatorio3)))==false)
            {
                this.contraseña.Text = Convert.ToString(nAleatorio3);
            }
            
           // this.Label20.Text = Convert.ToString(nAleatorio3);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}