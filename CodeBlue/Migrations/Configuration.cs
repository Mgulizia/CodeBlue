using CodeBlue.Migrations.SeedData;

namespace CodeBlue.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeBlue.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeBlue.Models.ApplicationDbContext context)
        {
            // Seed Roles (or Account Permissions)
            SeedRoles.Seed();

            // Seed positions
            SeedPositions.Seed();

            // Seed Admin Account
            SeedAccounts.Seed();

            
        }
    }
}
