using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Usuario
{
    public class Usuario
    {
        public string rut { get; set; }
        public string us_nombre { get; set; }
        public string us_paterno { get; set; }
        public string us_materno { get; set; }
        public string email {get; set;}
        public string password { get; set; }
        public string us_tipo { get; set; }
        public int us_estado { get; set; }
        public int idperfil { get; set; }


        public Usuario(string rut,string us_nombre,string us_paterno,string us_materno,string email,string password,string us_tipo,int us_estado,int idperfil) {
            this.rut = rut;
            this.us_nombre = us_nombre;
            this.us_paterno = us_paterno;
            this.us_materno = us_materno;
            this.email = email;
            this.password = password;
            this.us_tipo = us_tipo;
            this.us_estado = us_estado;
            this.idperfil = idperfil;
        }
    }
}
