using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Service
{
    public class ProductosService : BaseApiService
    {

        public object GuardarProducto(Productos producto, string token)
        {
            string ControllerMethodName = "Productos/GuardarProducto";

            var p = base.PostToApi(ControllerMethodName, producto, token);
            return p;
        }

        public object EditarProducto(Productos producto, string token)
        {
            string ControllerMethodName = "Productos/EditarProducto";
            return base.PostToApi(ControllerMethodName, producto, token);
        }

        public object EliminarProducto(int id, string token)
        {
            string ControllerMethodName = "Productos/EliminarProducto";
            return base.DeleteToApi(ControllerMethodName, id, token);
        }
    }
}