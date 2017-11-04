namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddCommentsModelToDatabaseWithoutStupidID : DbMigration
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
                        PostedById = c.String(maxLength: 128),
                        RelatedTicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PostedById)
                .ForeignKey("dbo.Tickets", t => t.RelatedTicketId, cascadeDelete: true)
                .Index(t => t.PostedById)
                .Index(t => t.RelatedTicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RelatedTicketId", "dbo.Tickets");
            DropForeignKey("dbo.Comments", "PostedById", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "RelatedTicketId" });
            DropIndex("dbo.Comments", new[] { "PostedById" });
            DropTable("dbo.Comments");
        }
    }
}
