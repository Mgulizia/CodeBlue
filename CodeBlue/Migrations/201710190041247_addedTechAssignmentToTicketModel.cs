namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTechAssignmentToTicketModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "AssignedToApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tickets", "AssignedToApplicationUserId");
            AddForeignKey("dbo.Tickets", "AssignedToApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "AssignedToApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "AssignedToApplicationUserId" });
            DropColumn("dbo.Tickets", "AssignedToApplicationUserId");
        }
    }
}
