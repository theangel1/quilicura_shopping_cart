namespace Quilicura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pruebaDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "Total", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Productoes", "Precio", c => c.Double());
        }
    }
}
