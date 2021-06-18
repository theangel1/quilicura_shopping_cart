using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class ProductoContext : DbContext
    {
        public ProductoContext() : base("AccesoQuilicura")
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderTBK> OrdenesTBK { get; set; }
        public DbSet<OrderDetailTBK> OrderDetailsTBK { get; set; }
    }
}