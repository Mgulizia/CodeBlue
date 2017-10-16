using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeBlue.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Migrations.SeedData
{
    public class SeedAccounts
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();
            var roles = context.Roles.ToList();

            if (!context.Users.Any(u => u.UserName == "admin@codeblue.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser();

                user.UserName = "admin@codeblue.com";
                user.CellNumber = "4025026023";
                user.Email = "admin@codeblue.com";
                user.FirstName = "Jotamama";
                user.LastName = "Vetiregu";
                user.PositionId = 1;
                user.IsEnabled = true;

                manager.Create(user, "Password11!!");
            }

            if (context.Users.Any(u => u.UserName == "admin@codeblue.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = context.Users.Single(u => u.Email == "admin@codeblue.com");
                foreach (var role in roles)
                {
                    manager.AddToRole(user.Id, role.Name);
                }
            }
            context.SaveChanges();
        }
    }
}