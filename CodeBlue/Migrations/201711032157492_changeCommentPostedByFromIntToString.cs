namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCommentPostedByFromIntToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "PostedBy_Id" });
            DropColumn("dbo.Comments", "PostedById");
            RenameColumn(table: "dbo.Comments", name: "PostedBy_Id", newName: "PostedById");
            AlterColumn("dbo.Comments", "PostedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "PostedById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "PostedById" });
            AlterColumn("dbo.Comments", "PostedById", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "PostedById", newName: "PostedBy_Id");
            AddColumn("dbo.Comments", "PostedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostedBy_Id");
        }
    }
}
