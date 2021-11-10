using La_tiendita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_tiendita.Controllers
{
    public class ConsultasModelo
    {

        La_tienditaDBEntities contexto = new La_tienditaDBEntities();

        public List<Producto> listaProducto()
        {
            return contexto.Producto.ToList();
        }

        public List<Producto> listaBuscarProducto(String Producto)
        {

            if (Producto.Equals(""))
            {
                return contexto.Producto.ToList();
            }
            else
            {
                var resultados = from cc in contexto.Producto
                                 where cc.produtco.Contains(Producto)
                                 select cc;
                return resultados.ToList();
            }
        }


        public List<Categoria> listaCategoria()
        {
            return contexto.Categoria.ToList();
        }

        public int insertarProducto(Producto producto)
        {
            contexto.Producto.Add(producto);
            return contexto.SaveChanges();

        }

        public int editarProducto(Producto productoid)
        {
            Producto producto = contexto.Producto.Find(productoid.Id_producto);
            producto.produtco = productoid.produtco;
            producto.descripcion_producto = productoid.descripcion_producto;
            producto.fecha_caducidad = productoid.fecha_caducidad;
            producto.existencia_de_producto = productoid.existencia_de_producto;
            producto.precio_compra = productoid.precio_compra;
            producto.precio_venta = productoid.precio_venta;
            producto.Id_categoria = productoid.Id_categoria;
            return contexto.SaveChanges();

        }

        public int eliminarProducto(int id)
        {
            Producto producto = contexto.Producto.Find(id);
            contexto.Producto.Remove(producto);
            return contexto.SaveChanges();
        }

        public Producto obtenerProducto(int id)
        {
            Producto producto = contexto.Producto.Find(id);
            return producto;
        }




        //------------------------------------------------------------------------

        

        public List<Categoria> listaBuscarCategoria(String Categoria)
        {

            if (Categoria.Equals(""))
            {
                return contexto.Categoria.ToList();
            }
            else
            {
                var resultados = from cc in contexto.Categoria
                                 where cc.categoria.Contains(Categoria)
                                 select cc;
                return resultados.ToList();
            }
        }


        

        public int insertarCategoria(Categoria categoria)
        {
            contexto.Categoria.Add(categoria);
            return contexto.SaveChanges();

        }

        public int editarCategoria(Categoria categoriaid)
        {
            Categoria categoria = contexto.Categoria.Find(categoriaid.Id_categoria);
            categoria.categoria = categoriaid.categoria;
            return contexto.SaveChanges();

        }

        public int eliminarCategoria(int id)
        {
            Categoria categoria = contexto.Categoria.Find(id);
            contexto.Categoria.Remove(categoria);
            return contexto.SaveChanges();
        }

        public Categoria obtenerCategoria(int id)
        {
            Categoria categoria = contexto.Categoria.Find(id);
            return categoria;
        }

        //--------------------------------------------------------------------------------------------

        public List<Ventas> listaVentas()
        {
            return contexto.Ventas.ToList();
        }

        public List<Vendedor> listaVendedor()
        {
            return contexto.Vendedor.ToList();
        }

        public int insertarVentas(Ventas ventas)
        {
            contexto.Ventas.Add(ventas);
            return contexto.SaveChanges();

        }

        public int editarVentas(Ventas ventasid)
        {
            Ventas ventas = contexto.Ventas.Find(ventasid.Id_venta);
            ventas.Hora_venta = ventasid.Hora_venta;
            ventas.Fecha_venta = ventasid.Fecha_venta;
            ventas.Total_venta = ventasid.Total_venta;
            ventas.Id_vendedor = ventasid.Id_vendedor;
            return contexto.SaveChanges();

        }

        public int eliminarVentas(int id)
        {
            Ventas ventas = contexto.Ventas.Find(id);
            contexto.Ventas.Remove(ventas);
            return contexto.SaveChanges();
        }

        public Ventas obtenerVentas(int id)
        {
            Ventas ventas = contexto.Ventas.Find(id);
            return ventas;
        }

        //-------------------------------------------------------------------------------------------
        public List<DetalleVenta> listaDetalleVenta()
        {
            return contexto.DetalleVenta.ToList();
        }

        public int insertarDetalleVenta(DetalleVenta detalle)
        {
            contexto.DetalleVenta.Add(detalle);
            return contexto.SaveChanges();

        }

        public int editarDetalleVenta(DetalleVenta detalleid)
        {
            DetalleVenta detalle = contexto.DetalleVenta.Find(detalleid.Id_detalle);
            detalle.Id_producto = detalleid.Id_producto;
            detalle.Id_venta = detalleid.Id_producto;
            detalle.Cantidad = detalleid.Cantidad;
            detalle.Subtotal = detalleid.Subtotal;
            return contexto.SaveChanges();

        }

        public int eliminarDetalleVenta(int id)
        {
            DetalleVenta detalle = contexto.DetalleVenta.Find(id);
            contexto.DetalleVenta.Remove(detalle);
            return contexto.SaveChanges();
        }

        public DetalleVenta obtenerDetalleVenta(int id)
        {
            DetalleVenta detalle = contexto.DetalleVenta.Find(id);
            return detalle;
        }
    }
}