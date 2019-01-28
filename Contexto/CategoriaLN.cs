using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    public class CategoriaLN
    {
        public static IQueryable ListaCategorias()
        {
            var db = new ProductoContext();
            IQueryable query = db.Categorias;
            return query;
        }
    }
}
