namespace Quilicura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAdd : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Username = c.String(),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(maxLength: 24),
                        Email = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTransactionId = c.String(),
                        HasBeenShipped = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
         
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Productoes", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.CartItems", new[] { "ProductoID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Productoes", new[] { "CategoriaID" });
            DropTable("dbo.CartItems");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
