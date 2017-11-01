namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTicketStatusesToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TicketStatus");
        }
    }
}
