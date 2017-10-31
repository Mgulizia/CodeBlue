namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsEnabledIntoDepartments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "IsEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "IsEnabled");
        }
    }
}
