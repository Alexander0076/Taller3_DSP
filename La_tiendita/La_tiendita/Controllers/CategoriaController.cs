using La_tiendita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace La_tiendita.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        ConsultasModelo modelo = new ConsultasModelo();
        public ActionResult Index()
        {
            return View(modelo.listaCategoria());
        }

        public ActionResult Insertar()
        {
            return View();
        }

        public ActionResult Modificar(int id)
        {
            List<Producto> lista = modelo.listaProducto();
            List<SelectListItem> listaO = new List<SelectListItem>();
            Categoria categoria = modelo.obtenerCategoria(id);
            foreach (Producto item in lista)
            {
                if (item.Id_categoria == categoria.Id_categoria)
                {
                    listaO.Add(new SelectListItem { Text = item.Categoria.categoria, Value = item.Id_categoria.ToString(), Selected = true });

                }
                else
                {
                    listaO.Add(new SelectListItem { Text = item.Categoria.categoria, Value = item.Id_categoria.ToString() });

                }

            }
            ViewBag.listaProducto = listaO;
            return View(modelo.obtenerCategoria(id));
        }

        [ActionName("Buscar")]
        public ActionResult buscar(String valor)
        {

            return View("Index", modelo.listaBuscarCategoria(valor));
        }


        [ActionName("Agregar")]
        public ActionResult insert(String Categoria)
        {
            Categoria categoria = new Categoria();
            categoria.categoria = Categoria;

            modelo.insertarCategoria(categoria);
            TempData["mensaje"] = "Producto agregado exitosamente";
            return RedirectToAction("Index", modelo.listaCategoria());
        }
        [ActionName("Editar")]
        public ActionResult edit(int Id_Categoria, String Categoria)
        {
            Categoria categoria = new Categoria();
            categoria.Id_categoria = Id_Categoria;
            categoria.categoria = Categoria;

            modelo.editarCategoria(categoria);
            TempData["mensaje"] = "Categoria modificada exitosamente";
            return RedirectToAction("Index", modelo.listaProducto());
        }
        public ActionResult Eliminar(int id)
        {

            modelo.eliminarCategoria(id);
            TempData["mensaje"] = "Categoria eliminado exitosamente";
            return RedirectToAction("Index", modelo.listaCategoria());
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