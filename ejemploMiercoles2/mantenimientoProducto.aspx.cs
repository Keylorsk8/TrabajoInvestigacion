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
            string accionProducto = Request.QueryString["accion"];
            if (accionProducto == "guardar")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Producto guardado";
            }
            //Listado de productos para el gridView
            recargarListado();
        }

        public void recargarListado()
        {
            IEnumerable<Productos> lista = (IEnumerable<Productos>)ProductoLN.ListaProductos();
            grvListado.DataSource = lista.ToList();
            grvListado.DataBind();
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

            using (WsCategorias.CategoriasClient client = new WsCategorias.CategoriasClient())
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
                return client.updateCategoria(id, nombre, descripcion);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Boolean archivoOK = false;
            String path = Server.MapPath("~/Imagenes/");
            if (archivoImagen.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(archivoImagen.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        archivoOK = true;
                    }
                }
            }
            if (archivoOK)
            {
                try
                {
                    // Guardar imagen en la carpeta
                    archivoImagen.PostedFile.SaveAs(path + archivoImagen.FileName);
                    // Guardar imagen en la carpeta Thumbs
                    archivoImagen.PostedFile.SaveAs(path + "Thumbs/" + archivoImagen.FileName);
                }
                catch (Exception ex)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = ex.Message;
                }
                //Guardar un producto
                ProductoLN producto = new ProductoLN();
                bool confirmacionGuardado = producto.guardarProducto(txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, ddlCategoria.SelectedValue, archivoImagen.FileName,hProductoId.Value);
                if (confirmacionGuardado)
                {
                    //Recargar página
                    Response.Redirect("mantenimientoProducto.aspx?accion=guardar");
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No se puede guardar el producto";
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Tipo de archivo incorrecto";
            }
        }



        protected void grvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grvListado.DataKeys[grvListado.SelectedIndex].Values[0]);
            Productos prod = ProductoLN.obtenerProducto(id);
            ddlCategoria.SelectedValue = prod.ProductoID.ToString();
            txtNombre.Text = prod.ProductoNombre;
            txtDescripcion.Text = prod.Descripcion;
            txtPrecio.Text = prod.PrecioUnitario.ToString();
            hProductoId.Value = prod.ProductoID.ToString();
            btnRegistrar.Text = "Actualizar";
        }
    }
}