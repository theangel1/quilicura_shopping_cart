using Quilicura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quilicura
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        public IQueryable<Producto> GetProducto([QueryString("ProductID")] int? productId,  [RouteData] string productName)
        {
            var _db = new ProductoContext();
            IQueryable<Producto> query = _db.Productos;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductoID == productId);
            }
            else if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(p =>
                      String.Compare(p.ProductoNombre, productName) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}