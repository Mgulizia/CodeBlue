namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserPropertiesAndPositionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "RoleDescription", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "CellNumber", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "PositionId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsEnabled", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PositionId");
            AddForeignKey("dbo.AspNetUsers", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PositionId", "dbo.Positions");
            DropIndex("dbo.AspNetUsers", new[] { "PositionId" });
            DropColumn("dbo.AspNetUsers", "IsEnabled");
            DropColumn("dbo.AspNetUsers", "PositionId");
            DropColumn("dbo.AspNetUsers", "CellNumber");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "RoleDescription");
            DropTable("dbo.Positions");
        }
    }
}
