using Quilicura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quilicura.Logica;

namespace Quilicura.Administracion
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Producto agregado!";
            }
            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "Producto eliminado!";
            }
        }
        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String path = Server.MapPath(@"~/Catalogo/Imagenes/");
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            if (fileOK)
            {
                try
                {
                    // Save to Images folder. 
                    ProductImage.PostedFile.SaveAs(@path + ProductImage.FileName);
                    miLabel.Text = path + ProductImage.FileName;
                    // Save to Images/Thumbs folder.
                    ProductImage.PostedFile.SaveAs(@path + "Thumbs/" + ProductImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }
                // Add product data to DB.

                AddProducto products = new AddProducto();
                bool addSuccess = products.AddProductos(AddProductName.Text, AddProductDescription.Text, AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName, AddModelo.Text, AddSKU.Text);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "No se agregó el producto a la base de datos.";
                }
            }
            else
            {
                LabelAddStatus.Text = "No se acepta este tipo de archivos.";
            }
        }
        public IQueryable GetCategories()
        {
            var _db = new ProductoContext();
            IQueryable query = _db.Categorias;
            return query;
        }
        public IQueryable GetProducts()
        {
            var _db = new ProductoContext();
            IQueryable query = _db.Productos;
            return query;
        }
        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var _db = new ProductoContext())
            {
                int productId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                var myItem = (from c in _db.Productos
                              where c.ProductoID == productId
                              select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Productos.Remove(myItem);
                    _db.SaveChanges();
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "No pudimos localizar el producto.";
                }
            }
        }
    }
}
