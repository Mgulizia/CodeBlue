namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDepartmentIdToTickets : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tickets", name: "Department_Id", newName: "DepartmentId");
            RenameIndex(table: "dbo.Tickets", name: "IX_Department_Id", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tickets", name: "IX_DepartmentId", newName: "IX_Department_Id");
            RenameColumn(table: "dbo.Tickets", name: "DepartmentId", newName: "Department_Id");
        }
    }
}
