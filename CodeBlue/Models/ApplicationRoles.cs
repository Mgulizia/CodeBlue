using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Models
{
    public class ApplicationRoles : IdentityRole
    {
        [NotMapped]
        public bool IsChecked { get; set; }

        public string RoleDescription { get; set; }
    }

    public static class RoleNames
    {
        public const string CanManageUsers = "CanManageUsers";
        public const string CanManagePositions = "CanManagePositions";
        public const string BasicUser = "BasicUser";
    }
    
}