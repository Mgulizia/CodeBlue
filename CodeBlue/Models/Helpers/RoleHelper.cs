using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Models.Helpers
{
    public class RoleHelper
    {
        public static bool HasRole(string userId, string roleId)
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(userscontext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            return userManager.IsInRole(userId, roleId);
        }
    }
}