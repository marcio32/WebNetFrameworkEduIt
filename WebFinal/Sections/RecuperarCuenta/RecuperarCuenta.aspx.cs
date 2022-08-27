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
    public partial class RecuperarCuenta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int NumRandom = random.Next(100000, 999999);

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(ConfigurationManager.AppSettings["From"], ConfigurationManager.AppSettings["Asunto"], System.Text.Encoding.UTF8);
            correo.To.Add(EmailText.Text);
            correo.Subject = "Codigo Clave educacion it";
            correo.Body = "Con este codigo: " + NumRandom + " podras recuperar tu cuenta, no se lo compartas a nadie";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = ConfigurationManager.AppSettings["Host"];
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["CredentialMail"], ConfigurationManager.AppSettings["CredentialPass"]);
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors ssqlPolicyErrors) { return true; };
            smtp.EnableSsl = true;
            smtp.Send(correo);

            var usuario = new Usuarios();
            var loginService = new LoginService();

            usuario.Codigo = NumRandom;
            usuario.Mail = EmailText.Text;
            loginService.Codigo(usuario);

        }

        protected void BtnRecuperar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuarios();
            var loginService = new LoginService();

            usuario.Codigo = int.Parse(CodigoText.Text);
            usuario.Mail = EmailText.Text;

            bool codigoVerificado = bool.Parse(loginService.VerificarCodigo(usuario).ToString());

            if (codigoVerificado == true)
            {
                Session["Codigo"] = "true";
                Session["Mail"] = EmailText.Text;
                Response.Redirect("RecuperarCuentaFin.aspx");
            }
            else
            {
                Session["Codigo"] = "false";
            }


        }
    }
}