using Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploMiercoles2.CarritoLN
{
    public class Carrito
    {
        public List<CarritoCompras> Items { get; private set; }

        //ImplementaciÃ³n Singleton

        // Las propiedades de solo lectura solo se pueden establecer en la inicializaciÃ³n o en un constructor
        public static readonly Carrito Instancia;

        // Se llama al constructor estÃ¡tico tan pronto como la clase se carga en la memoria
        static Carrito()
        {
            // Si el carrito no estÃ¡ en la sesiÃ³n, cree uno y guarde los items.
            if (HttpContext.Current.Session["carrito"] == null)
            {
                Instancia = new Carrito();
                Instancia.Items = new List<CarritoCompras>();
                HttpContext.Current.Session["carrito"] = Instancia;
            }
            else
            {
                // De lo contrario, obtÃ©ngalo de la sesiÃ³n.
                Instancia = (Carrito)HttpContext.Current.Session["carrito"];
            }
        }

        // Un constructor protegido asegura que un objeto no se puede crear desde el exterior
        protected Carrito() { }

        /**
         * AgregarItem (): agrega un artÃ­culo a la compra
         */
        public void AgregarItem(int productoId)
        {
            // Crear un nuevo artÃ­culo para agregar al carrito
            CarritoCompras nuevoItem = new CarritoCompras(productoId);
            // Si este artÃ­culo ya existe en lista de artÃ­culos, aumente la cantidad
            // De lo contrario, agregue el nuevo elemento a la lista

            if (Items.Exists(x => x.ProductoId == productoId))
            {
                CarritoCompras item = Items.Find(x => x.ProductoId == productoId);
                item.Cantidad++;
                return;
            }
            //Otra opciÃ³n es recorrer el arreglo
            //foreach (CarritoCompras item in Items)
            //{
            //    if (item.ProductoId==productoId)
            //    {


            //    }
            //}

            nuevoItem.Cantidad = 1;
            Items.Add(nuevoItem);

        }

        /**
         * SetItemCantidad(): cambia la cantidad de un artÃ­culo en el carrito
         */
        public void SetItemCantidad(int productoId, int cantidad)
        {
            // Si estamos configurando la cantidad a 0, elimine el artÃ­culo por completo
            if (cantidad == 0)
            {
                EliminarItem(productoId);
                return;
            }

            // Encuentra el artÃ­culo y actualiza la cantidad
            CarritoCompras actualizarItem = new CarritoCompras(productoId);
            if (Items.Exists(x => x.ProductoId == productoId))
            {
                CarritoCompras item = Items.Find(x => x.ProductoId == productoId);
                item.Cantidad = cantidad;
                return;
            }
            //Otra opciÃ³n
            //foreach (CarritoCompras item in Items)
            //{
            //    if (item.ProductoId == productoId)
            //    {
            //        item.Cantidad = cantidad;
            //        return;
            //    }
            //}
        }

        /**
         * EliminarItem (): elimina un artÃ­culo del carrito de compras
         */
        public void EliminarItem(int productoId)
        {
            if (Items.Exists(x => x.ProductoId == productoId))
            {
                var itemEliminar = Items.Single(x => x.ProductoId == productoId);
                Items.Remove(itemEliminar);
            }

        }

        /**
         * GetSubTotal() - Devuelve el precio total de todos los artÃ­culos.
         */
        public decimal GetTotal()
        {
            decimal subTotal = 0;
            foreach (CarritoCompras item in Items)
                subTotal += item.subTotal();

            return subTotal;
        }

    }
}