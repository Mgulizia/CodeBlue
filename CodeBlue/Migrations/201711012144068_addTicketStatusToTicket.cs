namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTicketStatusToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TicketStatusId");
            AddForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatus");
            DropIndex("dbo.Tickets", new[] { "TicketStatusId" });
            DropColumn("dbo.Tickets", "TicketStatusId");
        }
    }
}
