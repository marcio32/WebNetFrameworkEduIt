using Application.Helpers;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFinal.Service;

namespace WebFinal
{
    public partial class RecuperarCuentaFin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((String.IsNullOrEmpty((string)Session["Codigo"])))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else if ((string)Session["Codigo"] == "false")
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Default.aspx");
            }

        }

        protected void CambiarClave_Click(object sender, EventArgs e)
        {
            if (Equals(ClaveText.Text, ClaveText2.Text))
            {
                var usuario = new Usuarios();
                usuario.Clave = Hash.Hashing(ClaveText.Text);
                usuario.Mail = (string)Session["Mail"];
                var loginService = new LoginService();
                loginService.RecuperarCuenta(usuario);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ErrClave.Visible = true;
            }
        }
    }
}