using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class ProductoDatabaseInitializer : CreateDatabaseIfNotExists<ProductoContext>
    {
        protected override void Seed(ProductoContext context)
        {
            GetCategorias().ForEach(c => context.Categorias.Add(c));
            GetProductos().ForEach(p => context.Productos.Add(p));
        }


        private static List<Categoria> GetCategorias()
        {
            var categorias = new List<Categoria>
            {
            /*
            new Categoria { CategoriaID = 1, NombreCategoria = "Herramientas Manuales" },
            new Categoria { CategoriaID = 2, NombreCategoria = "Herramientas Electricas" },
            new Categoria { CategoriaID = 3, NombreCategoria = "Herramientas a Combustion"},
            new Categoria { CategoriaID = 4, NombreCategoria = "Sanitarios para Baño"},
            new Categoria { CategoriaID = 5, NombreCategoria = "Muebles para Baño"},
            new Categoria { CategoriaID = 6, NombreCategoria = "Muebles para Terraza"},
            new Categoria { CategoriaID = 7, NombreCategoria = "Griferia"},
            new Categoria { CategoriaID = 8, NombreCategoria = "Camping"},
            new Categoria { CategoriaID = 9, NombreCategoria = "Juguetes"},
            new Categoria { CategoriaID = 10, NombreCategoria = "Rodados para Bebes"},
            new Categoria { CategoriaID = 11, NombreCategoria = "Iluminacion"}
            */
            };

            return categorias;
        }

        private static List<Producto> GetProductos()
        {
            var products = new List<Producto>
        {
                /*
                new Producto { ProductoID = 1, ProductoNombre = "Grifo Cocina Retactil", Descripcion = "La grifería de cocina con rociador deslizable de una sola manija de Glacier Bay Market en acero inoxidable agregará estilo y funcionalidad a una amplia variedad de decoración de cocina", ImagePath="GRIFO COCINA RETRACTIL.jpg", Precio =71154, CategoriaID = 7 },
            new Producto { ProductoID = 2, ProductoNombre = "Esmeriladora Angular de 15mm Empañadura Cil", Descripcion = "Esmeril angular de 15 mm .", ImagePath="ESMERILADORA ANGULAR DE 15mm EMPAÑADURA CIL.jpg", Precio = 17487, CategoriaID = 2 },
            new Producto { ProductoID = 3, ProductoNombre = "Repisa Esquinera vidrio exten16-BN", Descripcion = "Diseñada para ofrecer almacenamiento adicional donde más se necesita sin sacrificar el diseño, Delta Glass Corner Shelf agrega estilo y funcionalidad a cualquier baño.", ImagePath="REPISA ESQUINERA VIDRIO EXTEN16-BN.jpg", Precio = 18090, CategoriaID = 5 },
            new Producto { ProductoID = 4, ProductoNombre = "Glac Bay WHT Dualflsh Toilet 2pc", Descripcion = "El inodoro alargado completo de dos piezas de doble eficacia Glacier Bay de 2 piezas ofrece un potente rendimiento de 1.1 o 1.6 GPF y cuenta con un diseño certificado WaterSense para ayudar a conservar el agua. La construcción de porcelana vitrificada de este inodoro ofrece resistencia al ácido, a la abrasión y a las manchas. Sanitario de baño color blanco.", ImagePath="GLAC BAY WHT DUALFLSH TOILET 2PC.png", Precio = 65664, CategoriaID = 4}
          */
         
        };
            return products;
        }
    }
}