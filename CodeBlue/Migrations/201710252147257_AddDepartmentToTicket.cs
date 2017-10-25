namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Department_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "Department_Id");
            AddForeignKey("dbo.Tickets", "Department_Id", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Tickets", new[] { "Department_Id" });
            DropColumn("dbo.Tickets", "Department_Id");
        }
    }
}
