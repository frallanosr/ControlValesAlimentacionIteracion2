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
using CapaLogica.Login;

namespace CapaVisualizacion
{
    public partial class Login : System.Web.UI.Page
    {

        FormatoRut r = new FormatoRut();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Visible = false;   
         }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string rut = r.formatearRut(this.rut.Text);
            bool rutValidado = r.validarRut(rut);

            if (rutValidado == false)
            {
                this.Label1.Visible = true;
                this.Label1.Text = "Rut o Contraseña Invaidos";
            }
            else {
                this.Label1.Visible = true;
                this.Label1.Text = "si";


                string rutSinPniG = rut.Replace(".","").Replace("-", "");
                string contraseña = this.pass.Text;
                UsuariosRepository lista = new UsuariosRepository();
                Encripta en = new Encripta();

                string contraEncriptada = en.Encriptar(contraseña);
                if (lista.listaUsuario(rutSinPniG, contraEncriptada) == false)
                {
                    this.Label1.Visible = true;
                    Label1.Text = "Rut o Contraseña Invaidos";
                }
                else
                {
                    if (lista.privilegio(rutSinPniG, contraEncriptada) == "administrador")
                    {
                        Session.Add("rut_administrador", rutSinPniG);
                        Response.Redirect("homeAdministrador.aspx");
                    }
                    else if (lista.privilegio(rutSinPniG, contraEncriptada) == "cajero")
                    {
                        this.Label1.Visible = true;
                        Label1.Text = "CAJERO";
                    }
                    else if (lista.privilegio(rutSinPniG, contraEncriptada) == "funcionario")
                    {
                        Session.Add("rut_UsuarioNormal", rutSinPniG);
                        Response.Redirect("VistaNormal.aspx");
                        //this.Label1.Visible = true;
                        //Label1.Text = "NORMAL";
                    }
                    else if (lista.privilegio(rutSinPniG, contraEncriptada) == "conPrivilegios")
                    {
                        this.Label1.Visible = true;
                        Label1.Text = "CON PRIVILEGIOS (Sercretari@,Jefe)";
                    }
                    else
                    {
                        this.Label1.Visible = true;
                        Label1.Text = "OTRO PRIVILEGIO";
                    }
                }

            }
            


           
        }
    }
}
