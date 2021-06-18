using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class Producto
    {
        [ScaffoldColumn(false)]
        public int ProductoID { get; set; }
        [Required, StringLength(100), Display(Name = "Nombre")]
        public string ProductoNombre { get; set; }
        [Required, StringLength(10000), Display(Name = "Descripcion del producto"), DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Precio")]
        public double? Precio { get; set; }
        public int? CategoriaID { get; set; }
        public string Modelo { get; set; }
        public string CodigoSKU { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}