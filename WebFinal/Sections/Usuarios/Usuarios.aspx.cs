using Application.Helpers;
using Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFinal.Service;

namespace WebFinal
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (String.IsNullOrEmpty((string)Session["Token"]))
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        token.Value = Session["Token"].ToString();
                    }

                    var rolService = new RolService();
                    var roles = rolService.ObtenerRoles(token.Value);

                    var listaRoles = JsonConvert.DeserializeObject<List<Roles>>(roles.ToString());

                    foreach (var x in listaRoles)
                    {
                        RolDrop.Items.Add(new ListItem(x.Nombre, x.Id.ToString()));
                    }
                    
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = NombreText.Text;
            string apellido = ApellidoText.Text;
            string clave = Hash.Hashing(ClaveText.Text);
            string mail = MailText.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(FechaNacimientDate.Text);
            int rol = Convert.ToInt16(RolDrop.SelectedValue);
            bool activo = ActivoCheck.Checked;

            var usuario = new Usuarios();

            var guardarUsuario = new UsuarioService();

            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Clave = clave;
            usuario.Mail = mail;
            usuario.Fecha_Nacimiento = fechaNacimiento;
            usuario.Id_Rol = rol;
            usuario.Activo = activo;

            guardarUsuario.GuardarUsuario(usuario, token.Value);

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idUsuario.Value);
            string nombre = NombreText.Text;
            string apellido = ApellidoText.Text;
            string clave = ClaveHasheada.Value == ClaveText.Text ? ClaveText.Text : Hash.Hashing(ClaveText.Text);
            string mail = MailText.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(FechaNacimientDate.Text);
            int rol = Convert.ToInt16(RolDrop.SelectedValue);
            bool activo = ActivoCheck.Checked;


            var usuario = new Usuarios();

            var editarUsuario = new UsuarioService();
            usuario.Id = id;
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Clave = clave;
            usuario.Mail = mail;
            usuario.Fecha_Nacimiento = fechaNacimiento;
            usuario.Id_Rol = rol;
            usuario.Activo = activo;

            editarUsuario.EditarUsuario(usuario, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarUsuario = new UsuarioService();
            int id = Convert.ToInt16(idUsuario.Value);
            eliminarUsuario.EliminarUsuario(id, token.Value);
        }
    }
}