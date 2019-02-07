using Contexto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ejemploMiercoles2
{
    public partial class detalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        public IEnumerable ObtenerProducto([QueryString("id")]int? idProductos)
        {
            IEnumerable<Productos> lista = (IEnumerable<Productos>)ProductoLN.ListaProductos();
            if(idProductos.HasValue && idProductos > 0)
            {
                lista = lista.Where(p => p.ProductoID == idProductos);
            }
            else
            {
                lista = null;
            }
            return lista;
        }
    }
}