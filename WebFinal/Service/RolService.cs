using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Service
{
    public class RolService : BaseApiService
    {
        public object GuardarRol(Roles Rol, string token)
        {
            string ControllerMethodName = "Roles/GuardarRol";
            return base.PostToApi(ControllerMethodName, Rol, token);
        }

        public object EditarRol(Roles Rol, string token)
        {
            string ControllerMethodName = "Roles/EditarRol";
            return base.PostToApi(ControllerMethodName, Rol, token);
        }

        public object EliminarRol(int id, string token)
        {
            string ControllerMethodName = "Roles/EliminarRol";
            return base.DeleteToApi(ControllerMethodName, id, token);
        }

        public object ObtenerRoles(string token)
        {
            string ControllerMethodName = "Roles/ObtenerRoles";
            return base.GetToApi(ControllerMethodName, "", token);
        }
    }
}
