using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFinal.Service;

namespace WebFinal
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Token"] != null)
            {
                Session["Token"] = Request.Cookies["Token"].Value;
                Response.Redirect("~/Sections/Usuarios/Usuarios");
            }
            else
            {
                Session["Token"] = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Clave = txtClave.Text;
            usuario.Mail = txtEmail.Text;

            LoginService loginServices = new LoginService();

            string respuesta = loginServices.Login(usuario).ToString();

            Session["Token"] = respuesta.Trim().Replace(@"\", "").Replace(@"""", "");

            if (RecuerdameCheck.Checked)
            {
                HttpCookie cookie = new HttpCookie("Token", respuesta.Trim().Replace(@"\", "").Replace(@"""", ""));
                cookie.Expires = DateTime.Now.AddDays(+5);
                Response.Cookies.Add(cookie);
            }

            if(respuesta != "")
            {
                Response.Redirect("~/Sections/Usuarios/Usuarios");
            }
            else
            {
                lblError.Visible = true;
            }

        }
    }
}