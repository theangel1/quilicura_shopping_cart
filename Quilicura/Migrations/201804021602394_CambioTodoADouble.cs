namespace Quilicura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioTodoADouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.Double());
            AlterColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.Productoes", "Precio", c => c.Double(nullable: false));
        }
    }
}
