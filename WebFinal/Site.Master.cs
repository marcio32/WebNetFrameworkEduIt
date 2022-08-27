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
            if (!String.IsNullOrEmpty((string)Session["Rol"]))
            {
                if (Session["Rol"].ToString() != "Administrador")
                {
                    UsuariosBtn.Visible = false;
                    RolesBtn.Visible = false;
                }
                
            }
        }

        protected void CerrarSesionBtn_Click(object sender, EventArgs e)
        {
            Response.Cookies["Token"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");
        }

        protected void UsuariosBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sections/Usuarios/Usuarios");
        }

        protected void ProductosBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sections/Productos/AdministrarProductos");
        }

        protected void RolesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sections/Roles/AdministrarRoles");
        }
    }
}