using Application;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Api.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        public WebFinalContext db;

        public UsuariosController()
        {
            db = new WebFinalContext();
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        public IHttpActionResult ObtenerUsuarios()
        {
            var usu = db.Usuarios.AsNoTracking().Where(x=> x.Activo == true).ToList();
            return Ok(usu);
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public IHttpActionResult GuardarUsuario([Bind(Include = "Id, Nombre, Apellido, Fecha_Nacimiento, Rol")] Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usu = db.Usuarios.AsNoTracking().ToList();
                    foreach (var x in usu)
                    {
                        if(x.Mail == usuario.Mail)
                        {
                            return Ok("El usuario Ya Existe");
                        }
                    }
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    return Ok("Se guardo Correctamente");
                }
            }
            catch
            {
                return Ok("Algo Salio Mal");
            }

            return Ok("Algo Salio Mal");
        }

        [HttpPost]
        [Route("EditarUsuario")]
        public IHttpActionResult EditarUsuario([Bind(Include = "Id, Nombre, Apellido, Fecha_Nacimiento, Rol")] Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se Edito Correctamente");
                }
            }
            catch(Exception ex)
            {
                return Ok("Algo Salio Mal");
            }

            return Ok("Algo Salio Mal");
        }


        [HttpGet]
        [Route("EliminarUsuario")]
        public IHttpActionResult EliminarUsuario(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuarios usuario = db.Usuarios.Find(id);
                    usuario.Activo = false;
                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se Elimino Correctamente");
                }
            }
            catch
            {
                return Ok("Algo Salio Mal");
            }

            return Ok("Algo Salio Mal");
        }
    }
}
