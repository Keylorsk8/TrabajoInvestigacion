using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    public class ProductoLN
    {
        public static IQueryable ListaProductos()
        {
            var db = new ProductoContext();
            IQueryable query = db.Productos;
            return query;
        }
        public bool guardarProducto(
            string nombreProducto,
            string descripcion,
            string precio,
            string categoriaID,
            string imagen
            )
        {
            ProductoContext db = new ProductoContext();
            Productos miProducto = new Productos();
            miProducto.ProductoNombre = nombreProducto;
            miProducto.Descripcion = descripcion;
            miProducto.PrecioUnitario = Convert.ToDouble(precio);
            miProducto.ImagenPath = imagen;
            miProducto.CategoriaID = Convert.ToInt32(categoriaID);

            db.Productos.Add(miProducto);
            db.SaveChanges();
            return true;
        }
    }
}
