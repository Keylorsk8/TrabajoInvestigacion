using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    public class CarritoCompras
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        //Para establecer el precio del producto
        public double? PrecioUnitario
        {
            get { return Productos.PrecioUnitario; }
        }
        public virtual Productos Productos
        {
            get; set;
        }
        public decimal subTotal()
        {
            return Convert.ToDecimal(PrecioUnitario * Cantidad);
        }
        public CarritoCompras()
        {

        }
        public CarritoCompras(int productId)
        {
            this.ProductoId = productId;
            this.Productos = new Productos();
            Productos = ProductoLN.obtenerProducto(productId);
        }
    }
}
