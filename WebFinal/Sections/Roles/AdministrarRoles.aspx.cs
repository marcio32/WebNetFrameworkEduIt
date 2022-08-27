using Application.Helpers;
using Application.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFinal.Service;

namespace WebFinal
{
    public partial class AdministrarRoles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty((string)Session["Token"]))
                {
                    Response.Redirect("~/Default.aspx", false);
                }else if (Session["Rol"].ToString() != "Administrador"){
                    Response.Redirect("~/MiProyecto.aspx", false);
                }
                else
                {
                    token.Value = Session["Token"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Default.aspx", false);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = NombreText.Text;
            bool activo = ActivoRolCheck.Checked;

            var Rol = new Roles();

            var guardarRol = new RolService();

            Rol.Nombre = nombre;
            Rol.Activo = activo;

            guardarRol.GuardarRol(Rol, token.Value);

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idRol.Value);
            string nombre = NombreText.Text;
            bool activo = ActivoRolCheck.Checked;


            var Rol = new Roles();

            var editarRol = new RolService();
            Rol.Id = id;
            Rol.Nombre = nombre;
            Rol.Activo = activo;

            editarRol.EditarRol(Rol, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarRol = new RolService();
            int id = Convert.ToInt16(idRol.Value);
            eliminarRol.EliminarRol(id, token.Value);
        }
    }
}