using Application.Helpers;
using Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFinal.Service;

namespace WebFinal
{
    public partial class AdministrarProductos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty((string)Session["Token"]))
                {
                    Response.Redirect("~/Default.aspx", false);
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
            string descripcion = DescripcionText.Text;
            decimal precio = decimal.Parse(PrecioText.Text);
            int stock = int.Parse(StockText.Text);

            bool activo = ActivoProductoCheck.Checked;
            string imagen = "";

            Stream st = ImagenUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(st);
            Byte[] bytes = br.ReadBytes((Int32)st.Length);
            imagen = Convert.ToBase64String(bytes, 0, bytes.Length);


            var Producto = new Productos();

            var guardarProducto = new ProductosService();

            Producto.Descripcion = descripcion;
            Producto.Precio = precio;
            Producto.Stock = stock;
            Producto.Imagen = imagen;
            Producto.Activo = activo;

            guardarProducto.GuardarProducto(Producto, token.Value);

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idProducto.Value);
            string descripcion = DescripcionText.Text;
            decimal precio = decimal.Parse(PrecioText.Text);
            int stock = int.Parse(StockText.Text);
            
            bool activo = ActivoProductoCheck.Checked;

            string imagen = imagenEditar.Value;
            if (ImagenUpload.PostedFile.FileName != "")
            {
                Stream st = ImagenUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(st);
                Byte[] bytes = br.ReadBytes((Int32)st.Length);
                imagen = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
           

            var Producto = new Productos();

            var editarProducto = new ProductosService();
            Producto.Id = id;
            Producto.Descripcion = descripcion;
            Producto.Precio = precio;
            Producto.Stock = stock;
            Producto.Imagen = imagen;
            Producto.Activo = activo;

            editarProducto.EditarProducto(Producto, token.Value);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminarProducto = new ProductosService();
            int id = Convert.ToInt16(idProducto.Value);
            eliminarProducto.EliminarProducto(id, token.Value);
        }
    }
}