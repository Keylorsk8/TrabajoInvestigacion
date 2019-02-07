using Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ejemploMiercoles2
{
    public partial class listaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Productos> GetProductos()
        {
            IEnumerable<Productos> lista = (IEnumerable<Productos>)ProductoLN.ListaProductos();
            return lista;
        } 
    }
}