namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBasicTicketModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CompletedDate = c.DateTime(),
                        TicketSubject = c.String(nullable: false),
                        TicketSummary = c.String(nullable: false),
                        TicketPriority = c.Int(nullable: false),
                        CreatedByApplicationUserId = c.String(maxLength: 128),
                        ClosedByApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ClosedByApplicationUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByApplicationUserId)
                .Index(t => t.CreatedByApplicationUserId)
                .Index(t => t.ClosedByApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CreatedByApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "ClosedByApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "ClosedByApplicationUserId" });
            DropIndex("dbo.Tickets", new[] { "CreatedByApplicationUserId" });
            DropTable("dbo.Tickets");
        }
    }
}
