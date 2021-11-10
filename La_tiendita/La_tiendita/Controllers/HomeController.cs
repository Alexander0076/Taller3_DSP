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
        La_tienditaDBEntities contexto = new La_tienditaDBEntities();
        ConsultasModelo modelo = new ConsultasModelo();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tabla()
        {
            return View(modelo.listaVendedor());
        }

        [HttpPost]
        public ActionResult Index(Vendedor log)
        {
            var user = contexto.Vendedor.Where(x => x.Usuario_vendedor == log.Usuario_vendedor && x.contasena == log.contasena).Count();
            if (user > 0)
            {
                return RedirectToAction("Index", "Producto");
            }
            else
            {
                return View();
            }


        }

        public ActionResult Insertar()
        {
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<Ventas> lista = modelo.listaVentas();
            List<SelectListItem> listaO = new List<SelectListItem>();
            Vendedor vendedor = modelo.obtenerVendedor(id);
            foreach (Ventas item in lista)
            {
                if (item.Id_vendedor == vendedor.Id_vendedor)
                {
                    listaO.Add(new SelectListItem { Text = item.Vendedor.Nombre_vendedor, Value = item.Id_vendedor.ToString(), Selected = true });

                }
                else
                {
                    listaO.Add(new SelectListItem { Text = item.Vendedor.Nombre_vendedor, Value = item.Id_vendedor.ToString() });

                }

            }
            ViewBag.listaVentas = listaO;
            return View(modelo.obtenerVendedor(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Tabla", modelo.listaBuscarVendedor(valor));
        }


        [ActionName("Registrar")]
        public ActionResult insert(String Nombre_vendedor, String Correo_vendedor, String Telefono_vendedor, String Dui_vendedor, String Usuario_vendedor, String contasena)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Nombre_vendedor = Nombre_vendedor;
            vendedor.Correo_vendedor = Correo_vendedor;
            vendedor.Telefono_vendedor = Telefono_vendedor;
            vendedor.Dui_vendedor = Dui_vendedor;
            vendedor.Usuario_vendedor = Usuario_vendedor;
            vendedor.contasena = contasena;

            modelo.insertarVendedor(vendedor);
            TempData["mensaje"] = "Vendedor agregado exitosamente";
            return RedirectToAction("Index", modelo.listaVendedor());
        }
        [ActionName("Editar")]
        public ActionResult edit(int Id_vendedor, String Nombre_vendedor, String Correo_vendedor, String Telefono_vendedor, String Dui_vendedor, String Usuario_vendedor, String contasena)
        {
            
            Vendedor vendedor = new Vendedor();
            vendedor.Id_vendedor = Id_vendedor;
            vendedor.Nombre_vendedor = Nombre_vendedor;
            vendedor.Correo_vendedor = Correo_vendedor;
            vendedor.Telefono_vendedor = Telefono_vendedor;
            vendedor.Dui_vendedor = Dui_vendedor;
            vendedor.Usuario_vendedor = Usuario_vendedor;
            vendedor.contasena = contasena;

            modelo.editarVendedor(vendedor);
            TempData["mensaje"] = "Vendedor modificado exitosamente";
            return RedirectToAction("Index", modelo.listaVendedor());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarVendedor(id);
            TempData["mensaje"] = "Categoria eliminado exitosamente";
            return RedirectToAction("Index", modelo.listaVendedor());
        }

    }
}