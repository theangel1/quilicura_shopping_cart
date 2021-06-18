using Quilicura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace Quilicura
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Producto> GetProductos([QueryString("id")] int? categoryId, [RouteData] string categoryName)
        {
            var _db = new ProductoContext();
            IQueryable<Producto> query = _db.Productos;

            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoriaID == categoryId);
            }

            if (!String.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p =>
                    String.Compare(p.Categoria.NombreCategoria,
                    categoryName) == 0);
            }
            return query;
        }

        public IQueryable<Categoria> GetCategorias()
        {
            var _db = new ProductoContext();
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }
    }
}