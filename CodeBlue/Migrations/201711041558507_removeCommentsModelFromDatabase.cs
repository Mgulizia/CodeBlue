namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCommentsModelFromDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "RelatedTicketId", "dbo.Tickets");
            DropIndex("dbo.Comments", new[] { "PostedById" });
            DropIndex("dbo.Comments", new[] { "RelatedTicketId" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostedOn = c.DateTime(nullable: false),
                        Comment = c.String(),
                        PostedById = c.String(maxLength: 128),
                        RelatedTicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Comments", "RelatedTicketId");
            CreateIndex("dbo.Comments", "PostedById");
            AddForeignKey("dbo.Comments", "RelatedTicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "PostedById", "dbo.AspNetUsers", "Id");
        }
    }
}
