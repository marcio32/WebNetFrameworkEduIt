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
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace Api.Controllers
{
    [Authorize]
    [EnableCors(origins:"*", headers:"*", "*")]
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {
        public WebFinalContext db;

        public ProductosController()
        {
            db = new WebFinalContext();
        }

        [HttpGet]
        [Route("ObtenerProductos")]
        public IHttpActionResult ObtenerProductos()
        {
            var produ = db.Productos.Where(x=> x.Activo == true).ToList();
            return Ok(produ);
        }

        [HttpPost]
        [Route("GuardarProducto")]
        public IHttpActionResult GuardarProducto([Bind(Include = "Id, Descripcion, Precio, Stock, Imagen, Activo")] Productos producto )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Productos.Add(producto);
                    db.SaveChanges();
                    return Ok("Se guardo Correctamente");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok("Algo Salio Mal");
        }

        [HttpPost]
        [Route("EditarProducto")]
        public IHttpActionResult EditarProducto([Bind(Include = "Id, Descripcion, Precio, Stock, Imagen, Activo")] Productos producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se Edito Correctamente");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok("Algo Salio Mal");
        }

        [HttpGet]
        [Route("EliminarProducto")]
        public IHttpActionResult EliminarProducto(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Productos producto = db.Productos.Find(id);
                    producto.Activo = false;
                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Se Elimino Correctamente");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return Ok("Algo Salio Mal");
        }
    }
}