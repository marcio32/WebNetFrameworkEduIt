using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Service
{
    public class UsuarioService : BaseApiService
    {
        public object GuardarUsuario(Usuarios usuario, string token)
        {
            string ControllerMethodName = "Usuarios/GuardarUsuario";
            return base.PostToApi(ControllerMethodName, usuario, token);
        }

        public object EditarUsuario(Usuarios usuario, string token)
        {
            string ControllerMethodName = "Usuarios/EditarUsuario";
            return base.PostToApi(ControllerMethodName, usuario, token);
        }

        public object EliminarUsuario(int id, string token)
        {
            string ControllerMethodName = "Usuarios/EliminarUsuario";
            return base.DeleteToApi(ControllerMethodName, id, token);
        }

        public object ObtenerUsuario(string mail, string token)
        {
            string ControllerMethodName = "Usuarios/ObtenerUsuario";
            return base.GetToApi(ControllerMethodName, mail, token);
        }
    }
}
