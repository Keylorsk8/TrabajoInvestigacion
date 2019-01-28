using Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ejemploMiercoles2
{
    public partial class mantenimientoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Length >= 3);
        }
        public IQueryable listaCategorias()
        {
            return CategoriaLN.ListaCategorias();
        }
    }
}