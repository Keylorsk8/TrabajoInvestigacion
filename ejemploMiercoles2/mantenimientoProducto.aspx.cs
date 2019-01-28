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

        public List<Categorias> getCategoriasWS()
        {
            List<Categorias> categorias = new List<Categorias>();
            using (WsCategorias.CategoriasClient client = new WsCategorias.CategoriasClient())
            {
                Categorias cat;
                var categoriasWS = client.getCategorias();
                foreach (var v in categoriasWS)
                {
                    cat = new Categorias();
                    cat.CategoriaID = v.Id;
                    cat.CategoriaNombre = v.Nombre;
                    cat.Descripcion = v.Descripcion;
                    categorias.Add(cat);
                }
            }
            return categorias;
        }

        public bool insertCategoria()
        {
            var nombre = "";
            var descripcion = "";

            using(WsCategorias.CategoriasClient client = new WsCategorias.CategoriasClient())
            {
                return client.insertCategoria(nombre, descripcion);
            }
        }

        public bool updateCategoria()
        {
            int id = 0;
            var nombre = "";
            var descripcion = "";
            using (WsCategorias.CategoriasClient client = new WsCategorias.CategoriasClient())
            {
                return client.updateCategoria(id,nombre, descripcion);
            }
        }
    }
}