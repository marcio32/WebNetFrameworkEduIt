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
    [RoutePrefix("api/Roles")]
    public class RolesController : ApiController
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WebFinalContext db;

        public RolesController()
        {
            db = new WebFinalContext();
        }

        [HttpGet]
        [Route("ObtenerRoles")]
        public IHttpActionResult ObtenerRoles()
        {
            log.Error("Se rompio todo");
            var rol = db.Roles.AsNoTracking().Where(x=> x.Activo == true).ToList();
            return Ok(rol);
        }

        [HttpPost]
        [Route("GuardarRol")]
        public IHttpActionResult GuardarRol([Bind(Include = "Id, Nombre, Apellido, Fecha_Nacimiento, Rol")] Roles Rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usu = db.Roles.AsNoTracking().ToList();
                    foreach (var x in usu)
                    {
                        if(x.Nombre == Rol.Nombre)
                        {
                            return Ok("El Rol Ya Existe");
                        }
                    }
                    db.Roles.Add(Rol);
                    db.SaveChanges();
                    return Ok("Se guardo Correctamente");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Ok("Algo Salio Mal");
            }

            return Ok("Algo Salio Mal");
        }

        [HttpPost]
        [Route("EditarRol")]
        public IHttpActionResult EditarRol([Bind(Include = "Id, Nombre, Activo")] Roles Rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Rol).State = System.Data.Entity.EntityState.Modified;
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
        [Route("EliminarRol")]
        public IHttpActionResult EliminarRol(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Roles Rol = db.Roles.Find(id);
                    Rol.Activo = false;
                    db.Entry(Rol).State = System.Data.Entity.EntityState.Modified;
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
