namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addknowledgebasemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KnowledgeBases",
                c => new
                    {
                        KnowledgeBaseId = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(nullable: false),
                        Article = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Userid = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KnowledgeBaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KnowledgeBases");
        }
    }
}
