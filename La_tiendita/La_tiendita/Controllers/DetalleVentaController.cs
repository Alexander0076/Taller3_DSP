using La_tiendita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace La_tiendita.Controllers
{
    public class DetalleVentaController : Controller
    {
        // GET: DetalleVenta
        ConsultasModelo modelo = new ConsultasModelo();
        public ActionResult Index()
        {
            return View(modelo.listaDetalleVenta());
        }

        public ActionResult Insertar()
        {

            List<Ventas> lista = modelo.listaVentas();
            List<SelectListItem> listaO = new List<SelectListItem>();
            List<Producto> lista1 = modelo.listaProducto();
            List<SelectListItem> listaP = new List<SelectListItem>();
            foreach (Ventas item in lista)
            {
                listaO.Add(new SelectListItem { Text = item.Id_venta.ToString(), Value = item.Id_venta.ToString() });
            }
            foreach(Producto item in lista1)
            {
                listaP.Add(new SelectListItem { Text = item.produtco, Value = item.Id_producto.ToString() });
            }

            ViewBag.listaProducto = listaP;
            ViewBag.listaVentas = listaO;
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<Ventas> lista = modelo.listaVentas();
            List<SelectListItem> listaO = new List<SelectListItem>();
            List<Producto> lista1 = modelo.listaProducto();
            List<SelectListItem> listaP = new List<SelectListItem>();
            DetalleVenta detalle = modelo.obtenerDetalleVenta(id);
            foreach (Ventas item in lista)
            {
                if (item.Id_venta == detalle.Id_venta)
                {
                    listaO.Add(new SelectListItem { Text = item.Id_venta.ToString(), Value = item.Id_venta.ToString(), Selected = true });

                }
                else
                {
                    listaO.Add(new SelectListItem { Text = item.Id_venta.ToString(), Value = item.Id_venta.ToString() });

                }

            }

            foreach (Producto item in lista1)
            {
                if (item.Id_producto == detalle.Producto.Id_producto)
                {
                    listaP.Add(new SelectListItem { Text = item.produtco, Value = item.Id_producto.ToString(), Selected = true });

                }
                else
                {
                    listaP.Add(new SelectListItem { Text = item.produtco, Value = item.Id_producto.ToString() });

                }
            }

            ViewBag.listaProducto = listaP;
            ViewBag.listaVentas = listaO;
            return View(modelo.obtenerDetalleVenta(id));
        }


        [ActionName("Agregar")]
        public ActionResult insert(int listaVentas, int listaProducto, int Cantidad, Decimal Subtotal)
        {
            DetalleVenta detalle = new DetalleVenta();
            detalle.Id_venta = listaVentas;
            detalle.Id_producto = listaProducto;
            detalle.Cantidad = Cantidad;
            detalle.Subtotal = Subtotal;


            modelo.insertarDetalleVenta(detalle);
            TempData["mensaje"] = "Detalle de venta agregada exitosamente";
            return RedirectToAction("Index", modelo.listaDetalleVenta());
        }
        [ActionName("Editar")]
        public ActionResult edit(int ID_detalle, int listaVentas, int listaProducto, int Cantidad, Decimal Subtotal)
        {
            DetalleVenta detalle = new DetalleVenta();
            detalle.Id_detalle = ID_detalle;
            detalle.Id_venta = listaVentas;
            detalle.Id_producto = listaProducto;
            detalle.Cantidad = Cantidad;
            detalle.Subtotal = Subtotal;

            modelo.editarDetalleVenta(detalle);
            TempData["mensaje"] = "Detalle de venta ha sido modificada exitosamente";
            return RedirectToAction("Index", modelo.listaDetalleVenta());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarDetalleVenta(id);
            TempData["mensaje"] = "Detalle de venta ha sido eliminada exitosamente";
            return RedirectToAction("Index", modelo.listaDetalleVenta());
        }
    }
}