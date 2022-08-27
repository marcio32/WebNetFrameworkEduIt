using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CerrarSesionBtn_Click(object sender, EventArgs e)
        {
            Response.Cookies["Token"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");
        }
    }
}