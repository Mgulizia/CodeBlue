namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostedOn = c.DateTime(nullable: false),
                        Comment = c.String(),
                        PostedById = c.Int(nullable: false),
                        RelatedTicketId = c.Int(nullable: false),
                        PostedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PostedBy_Id)
                .ForeignKey("dbo.Tickets", t => t.RelatedTicketId, cascadeDelete: true)
                .Index(t => t.RelatedTicketId)
                .Index(t => t.PostedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RelatedTicketId", "dbo.Tickets");
            DropForeignKey("dbo.Comments", "PostedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "PostedBy_Id" });
            DropIndex("dbo.Comments", new[] { "RelatedTicketId" });
            DropTable("dbo.Comments");
        }
    }
}
