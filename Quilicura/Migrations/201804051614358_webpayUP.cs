namespace Quilicura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webpayUP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderTBKs",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        AccountingDate = c.String(),
                        SessionID = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        CardNumber = c.String(),
                        CardExpirationDate = c.String(),
                        VCI = c.String(),
                        CommerceCode = c.String(),
                        PaymentTypeCode = c.String(),
                        AuthorizationCode = c.String(),
                        ResponseCode = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetailTBKs",
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
                .ForeignKey("dbo.OrderTBKs", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetailTBKs", "OrderId", "dbo.OrderTBKs");
            DropIndex("dbo.OrderDetailTBKs", new[] { "OrderId" });
            DropTable("dbo.OrderDetailTBKs");
            DropTable("dbo.OrderTBKs");
        }
    }
}
