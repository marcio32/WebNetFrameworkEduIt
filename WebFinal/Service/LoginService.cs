using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Service
{
    public class LoginService : BaseApiService
    {
        public object Login(Usuarios usuario)
        {
            string ControllerMethodName = "Login/Authenticate";
            return base.LoginToApi(ControllerMethodName, usuario);
        }

        public object Codigo(Usuarios usuario)
        {
            string ControllerMethodName = "Login/Codigo";
            return base.LoginToApi(ControllerMethodName, usuario);
        }

        public object VerificarCodigo(Usuarios usuario)
        {
            string ControllerMethodName = "Login/VerificarCodigo";
            return base.LoginToApi(ControllerMethodName, usuario);
        }

        public object RecuperarCuenta(Usuarios usuario)
        {
            string ControllerMethodName = "Login/RecuperarCuenta";
            return base.LoginToApi(ControllerMethodName, usuario);
        }
    }
}