using Application;
using Application.Helpers;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {

        private WebFinalContext db;
        public LoginController()
        {
            db = new WebFinalContext();
        }

        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Authenticate(Usuarios login)
        {
            if (login == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var usuarios = db.Usuarios.ToList();
            foreach (var x in usuarios)
            {
                if (x.Mail == login.Mail && Hash.VerifyHashedPassword(x.Clave, login.Clave))
                {
                    var token = TokenGenerator.GenerateTokenJWT(login.Mail);
                    return Ok(token);
                }
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Codigo")]
        public IHttpActionResult Codigo(Usuarios codigo)
        {

            var usuario = db.Usuarios.Where(x => x.Mail == codigo.Mail).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Codigo = codigo.Codigo;
                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se guardo el codigo correctamente");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex);
            }
            return Content(HttpStatusCode.NotFound, "Algo salio Mal");
        }

        [HttpPost]
        [Route("VerificarCodigo")]
        public IHttpActionResult VerificarCodigo(Usuarios codigo)
        {

            var usuario = db.Usuarios.Where(x => x.Mail == codigo.Mail).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    if (Equals(usuario.Codigo, codigo.Codigo))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return Ok(false);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex);
            }
            return Content(HttpStatusCode.NotFound, "Algo salio Mal");
        }


        [HttpPost]
        [Route("RecuperarCuenta")]
        public IHttpActionResult RecuperarCuenta(Usuarios usuario)
        {

            var usu = db.Usuarios.Where(x => x.Mail == usuario.Mail).FirstOrDefault();

            try
            {
                if (ModelState.IsValid)
                {
                    usu.Clave = usuario.Clave;
                    db.Entry(usu).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se edito el usuario correctamente");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex);
            }
            return Content(HttpStatusCode.NotFound, "Algo salio Mal");
        }

    }

}