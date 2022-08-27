using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal
{
    public partial class MiProyecto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Token"].ToString() == "")
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Default.aspx", false);
            }

        }
    }
}