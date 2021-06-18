using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class CartItem
    {
        [Key]
        public string ItemID { get; set; }
        public string CartID { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
    }
}