using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class Categoria
    {
        [ScaffoldColumn(false)]
        public int CategoriaID { get; set; }

        [Required, StringLength(100), Display(Name = "Nombre")]
        public string NombreCategoria { get; set; }

        [Display(Name = "Product Description")]
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}