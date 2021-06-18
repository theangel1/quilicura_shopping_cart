using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class AddProducto
    {
        public bool AddProductos(string ProductName, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath, string model, string sku)
        {
            var myProduct = new Producto();
            myProduct.ProductoNombre = ProductName;
            myProduct.Descripcion = ProductDesc;
            myProduct.Precio = int.Parse(ProductPrice);
            myProduct.ImagePath = ProductImagePath;
            myProduct.CategoriaID = int.Parse(ProductCategory);
            myProduct.Modelo = model;
            myProduct.CodigoSKU = sku;
            using (ProductoContext _db = new ProductoContext())
            {
                // Add product to DB. 
                _db.Productos.Add(myProduct);
                _db.SaveChanges();
            }
            // Success. 
            return true;
        }
    }
}