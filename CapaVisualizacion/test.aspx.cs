using CapaDatos.RepositoryUsuarios;
using CapaLogica.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaVisualizacion
{
    public partial class test : System.Web.UI.Page
    {
        UsuariosRepository proRepository = new UsuariosRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Usuario> lista = proRepository.listaUsuario();
            //GridView1.DataSource = lista;
            //GridView1.DataBind();
        }
    }
}