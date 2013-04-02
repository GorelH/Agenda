using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSmartAgenda
{
    public partial class Acceuil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            introduction.Text = "Bienvenue sur LE web agenda, pour suivre les infos du moment, réserver des places de concert, s'informer sur les artistes...";
        }
    }
}