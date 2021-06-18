namespace Quilicura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productoadeci : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Precio", c => c.Int());
        }
    }
}
