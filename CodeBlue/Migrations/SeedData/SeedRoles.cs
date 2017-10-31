using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeBlue.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Migrations.SeedData
{
    public static class SeedRoles
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();
            
            //Seed Additional Roles by adding them to this collection.  then run update-database again
            var roles = new Dictionary<string, string>();
            roles.Add("CanManageUsers", "Manage User Accounts");
            roles.Add("CanManagePositions", "Manage Support Postions");
            roles.Add("CanManageTickets", "Can Manage and Assign Tickets");
            roles.Add("BasicUser", "Basic User Account");

            foreach (var role in roles)
            {
                if (!context.ApplicationRoles.Any(r => r.Name == role.Key))
                {
                    var store = new RoleStore<ApplicationRoles>(context);
                    var manager = new RoleManager<ApplicationRoles>(store);
                    var newRole = new ApplicationRoles() {Name = role.Key, RoleDescription = role.Value};

                    manager.Create(newRole);
                }
            }
            context.SaveChanges();
        }
    }
}