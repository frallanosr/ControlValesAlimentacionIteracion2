﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}