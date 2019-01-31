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
        /*public bool guardarProducto(
            string nombreProducto,
            string descripcion,
            string precio,
            string categoriaID,
            string imagen, string id = ""
            )
        {
            ProductoContext db = new ProductoContext();
            Productos miProducto = new Productos();
            int idProducto = 0;
            bool esNumero = int.TryParse(id, out idProducto);
            if (esNumero && idProducto > 0)
            {
                //Buscar Producto para actualizar
                miProducto = db.Productos.Where(x => x.ProductoID == idProducto).First<Productos>();
            }
            miProducto.ProductoNombre = nombreProducto;
            miProducto.Descripcion = descripcion;
            miProducto.PrecioUnitario = Convert.ToDouble(precio);
            miProducto.ImagenPath = imagen;
            miProducto.CategoriaID = Convert.ToInt32(categoriaID);
            if (id.Equals("") || !esNumero)
            {
                db.Productos.Add(miProducto);
            }
            db.Productos.Add(miProducto);
            db.SaveChanges();
            return true;
        }*/

        public bool guardarProducto(
            string nombreProducto,
            string descripcion,
            string precio,
            string categoriaID,
            string imagenPath, string id = "")
        {

            var miProducto = new Productos();
            ProductoContext db = new ProductoContext();
            int idProducto = 0;
            bool esNumero = int.TryParse(id, out idProducto);
            if (esNumero || idProducto > 0)
            {

                // Buscar producto en la BD
                miProducto = db.Productos.
                    Where(p => p.ProductoID == idProducto).
                    First<Productos>();

            }
            //Definir valores del producto
            miProducto.ProductoNombre = nombreProducto;
            miProducto.Descripcion = descripcion;
            miProducto.PrecioUnitario = Convert.ToDouble(precio);
            miProducto.ImagenPath = imagenPath;
            miProducto.CategoriaID = Convert.ToInt32(categoriaID);
            //Guardar producto en la BD
            if (id.Equals("") || !esNumero)
            { // Agregar producto a la BD
                db.Productos.Add(miProducto);

            }
            db.SaveChanges();
            return true;
        }
        public static Productos obtenerProducto(int id)
        {
            var db = new ProductoContext();
            Productos miProducto = db.Productos.Where(x => x.ProductoID == id).First<Productos>();
            return miProducto;
        }
    }
}
