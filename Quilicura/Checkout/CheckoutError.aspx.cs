using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quilicura.Logica;

namespace Quilicura.Checkout
{
    public partial class CheckoutError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShoppingCartActions sp = new ShoppingCartActions();
            
        }
    }
}