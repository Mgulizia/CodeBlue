namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeTicketStatusAndTicketPriorityNonNullable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "TicketPriority", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "TicketPriority", c => c.Int(nullable: false));
        }
    }
}
