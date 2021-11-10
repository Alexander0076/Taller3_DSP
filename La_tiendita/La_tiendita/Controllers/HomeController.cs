using La_tiendita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace La_tiendita.Controllers
{
    public class HomeController : Controller
    {
        ConsultasModelo modelo = new ConsultasModelo();
        public ActionResult Index()
        {
            return View(modelo.listaProducto());
        }

        public ActionResult Insertar()
        {

            List<Categoria> lista = modelo.listaCategoria();
            List<SelectListItem> listaO = new List<SelectListItem>();
            foreach (Categoria item in lista)
            {
                listaO.Add(new SelectListItem { Text = item.categoria, Value = item.Id_categoria.ToString() });
            }
            ViewBag.listaCategoria = listaO;
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<Categoria> lista = modelo.listaCategoria();
            List<SelectListItem> listaO = new List<SelectListItem>();
            Producto producto = modelo.obtenerProducto(id);
            foreach (Categoria item in lista)
            {
                if (item.Id_categoria == producto.Categoria.Id_categoria)
                {
                    listaO.Add(new SelectListItem { Text = item.categoria, Value = item.Id_categoria.ToString(), Selected = true });

                }
                else
                {
                    listaO.Add(new SelectListItem { Text = item.categoria, Value = item.Id_categoria.ToString() });

                }

            }
            ViewBag.listaCategoria = listaO;
            return View(modelo.obtenerProducto(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarProducto(valor));
        }


        [ActionName("Agregar")]
        public ActionResult insert(int listaCategoria, String produtco, String descripcion_producto, int existencia_de_producto, decimal precio_compra, decimal precio_venta, DateTime fecha_caducidad)
        {
            Producto producto = new Producto();
            producto.produtco = produtco;
            producto.descripcion_producto = descripcion_producto;
            producto.fecha_caducidad = fecha_caducidad;
            producto.existencia_de_producto = existencia_de_producto;
            producto.precio_compra = precio_compra;
            producto.precio_venta = precio_venta;
            producto.Id_categoria = listaCategoria;

            modelo.insertarProducto(producto);
            TempData["mensaje"] = "Producto agregado exitosamente";
            return RedirectToAction("Index", modelo.listaProducto());
        }
        [ActionName("Editar")]
        public ActionResult edit(int listaCategoria, int Id_producto, String produtco, String descripcion_producto, int existencia_de_producto, decimal precio_compra, decimal precio_venta, DateTime fecha_caducidad)
        {
            Producto producto = new Producto();
            producto.Id_producto = Id_producto;
            producto.produtco = produtco;
            producto.descripcion_producto = descripcion_producto;
            producto.fecha_caducidad = fecha_caducidad;
            producto.existencia_de_producto = existencia_de_producto;
            producto.precio_compra = precio_compra;
            producto.precio_venta = precio_venta;
            producto.Id_categoria = listaCategoria;

            modelo.editarProducto(producto);
            TempData["mensaje"] = "Persona modificada exitosamente";
            return RedirectToAction("Index", modelo.listaProducto());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarProducto(id);
            TempData["mensaje"] = "Producto eliminado exitosamente";
            return RedirectToAction("Index", modelo.listaProducto());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}