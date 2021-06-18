namespace Quilicura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addToProductoModelFieldsModeloAndSKU : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Modelo", c => c.String());
            AddColumn("dbo.Productoes", "CodigoSKU", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "CodigoSKU");
            DropColumn("dbo.Productoes", "Modelo");
        }
    }
}
