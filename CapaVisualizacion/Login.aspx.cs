using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using CapaDatos.RepositoryUsuarios;
using CapaLogica.Usuario;


namespace CapaVisualizacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Visible = false;   
         }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string rut = this.rut.Text.Replace("-", "");
            string contraseña = this.pass.Text;
            UsuariosRepository lista = new UsuariosRepository();
            Encripta en = new Encripta();

            string contraEncriptada = en.Encriptar(contraseña); 
            if (lista.listaUsuario(rut, contraEncriptada) == false)
            {
                this.Label1.Visible = true;
                Label1.Text = "EL USUARIO NO EXISTE";
            }
            else{
                if (lista.privilegio(rut, contraEncriptada) == "administrador")
                {
                    Session.Add("rut_administrador", rut);
                    Response.Redirect("homeAdministrador.aspx");
                }
                else if (lista.privilegio(rut, contraEncriptada) == "cajero")
                {
                    this.Label1.Visible = true;
                    Label1.Text = "CAJERO";
                }
                else if (lista.privilegio(rut, contraEncriptada) == "normal")
                {
                    this.Label1.Visible = true;
                    Label1.Text = "NORMAL";
                }
                else if (lista.privilegio(rut, contraEncriptada) == "conPrivilegios")
                {
                    this.Label1.Visible = true;
                    Label1.Text = "CON PRIVILEGIOS (Sercretari@,Jefe)";
                }
                else {
                    this.Label1.Visible = true;
                    Label1.Text = "OTRO PRIVILEGIO";
                }
            }
        }
    }
}
