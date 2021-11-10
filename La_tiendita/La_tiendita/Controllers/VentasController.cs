using La_tiendita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace La_tiendita.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        ConsultasModelo modelo = new ConsultasModelo();
        public ActionResult Index()
        {
            return View(modelo.listaVentas());
        }

        public ActionResult Insertar()
        {

            List<Vendedor> lista = modelo.listaVendedor();
            List<SelectListItem> listaO = new List<SelectListItem>();
            foreach (Vendedor item in lista)
            {
                listaO.Add(new SelectListItem { Text = item.Nombre_vendedor, Value = item.Id_vendedor.ToString() });
            }
            ViewBag.listaVendedor = listaO;
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<Vendedor> lista = modelo.listaVendedor();
            List<SelectListItem> listaO = new List<SelectListItem>();
            Ventas ventas = modelo.obtenerVentas(id);
            foreach (Vendedor item in lista)
            {
                if (item.Id_vendedor == ventas.Vendedor.Id_vendedor)
                {
                    listaO.Add(new SelectListItem { Text = item.Nombre_vendedor, Value = item.Id_vendedor.ToString(), Selected = true });

                }
                else
                {
                    listaO.Add(new SelectListItem { Text = item.Nombre_vendedor, Value = item.Id_vendedor.ToString() });

                }

            }
            ViewBag.listaVendedor = listaO;
            return View(modelo.obtenerVentas(id));
        }

        //[ActionName("Buscar")]
        //public ActionResult buscar(String valor)
        //{

        //    return View("Index", modelo.listaBuscarVentas(valor));
        //}


        [ActionName("Agregar")]
        public ActionResult insert(int listaVendedor, TimeSpan Hora_venta, DateTime Fecha_venta, Decimal Total_venta)
        {
            Ventas ventas = new Ventas();
            ventas.Hora_venta = Hora_venta;
            ventas.Fecha_venta = Fecha_venta;
            ventas.Total_venta = Total_venta;
            ventas.Id_vendedor = listaVendedor;

            modelo.insertarVentas(ventas);
            TempData["mensaje"] = "Ventas agregada exitosamente";
            return RedirectToAction("Index", modelo.listaVentas());
        }
        [ActionName("Editar")]
        public ActionResult edit(int listaVendedor, int Id_venta, TimeSpan Hora_venta, DateTime Fecha_venta, Decimal Total_venta)
        {
            Ventas ventas = new Ventas();
            ventas.Id_venta = Id_venta;
            ventas.Hora_venta = Hora_venta;
            ventas.Fecha_venta = Fecha_venta;
            ventas.Total_venta = Total_venta;
            ventas.Id_vendedor = listaVendedor;

            modelo.editarVentas(ventas);
            TempData["mensaje"] = "Ventas modificada exitosamente";
            return RedirectToAction("Index", modelo.listaVentas());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarVentas(id);
            TempData["mensaje"] = "Venta eliminada exitosamente";
            return RedirectToAction("Index", modelo.listaVentas());
        }
        
    }
}