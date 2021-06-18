using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quilicura.Models;

namespace Quilicura.Logica
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }
        private ProductoContext _db = new ProductoContext();
        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            ShoppingCartId = GetCartId();
            var cartItem = _db.ShoppingCartItems.SingleOrDefault(
                c => c.CartID == ShoppingCartId && c.ProductoID == id);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ItemID = Guid.NewGuid().ToString(),
                    ProductoID = id,
                    CartID = ShoppingCartId,
                    Producto = _db.Productos.SingleOrDefault(
                    p => p.ProductoID == id),
                    Cantidad = 1,
                    FechaCreacion = DateTime.Now
                };
                _db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                //si el item no existe en el carro, añado uno a la cantidad
                cartItem.Cantidad++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    //genero un guid random
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();
            return _db.ShoppingCartItems.Where(c => c.CartID == ShoppingCartId).ToList();
        }
      
        public int GetTotal()
        {
            ShoppingCartId = GetCartId();
            int? total = 0;
            total = (int?)(from cartItems in _db.ShoppingCartItems
                               where cartItems.CartID == ShoppingCartId
                               select (int?)cartItems.Cantidad *
                               cartItems.Producto.Precio).Sum();
            return total ?? 0;
        }
       
        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new ProductoContext())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartItem> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Producto.ProductoID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProductoID);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.ProductoID, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: no se pudo actualizar la base de datos - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new ProductoContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartItems where c.CartID == removeCartID && c.Producto.ProductoID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.ShoppingCartItems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: no se pudo eliminar el item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            using (var _db = new ProductoContext())
            {
                try
                {
                    var myItem = (from c in _db.ShoppingCartItems where c.CartID == updateCartID && c.Producto.ProductoID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Cantidad = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: no se pudo actualizar el item del carro - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.ShoppingCartItems.Where(
                c => c.CartID == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.ShoppingCartItems
                          where cartItems.CartID == ShoppingCartId
                          select (int?)cartItems.Cantidad).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }

        public void MigrateCart(string cartId, string userName)
        {
            var shoppingCart = _db.ShoppingCartItems.Where(c => c.CartID == cartId);
            foreach (CartItem item in shoppingCart)
            {
                item.CartID = userName;
            }
            HttpContext.Current.Session[CartSessionKey] = userName;
            _db.SaveChanges();
        }
    }
}