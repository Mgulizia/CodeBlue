namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsEnabledToCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "IsEnabled");
        }
    }
}
