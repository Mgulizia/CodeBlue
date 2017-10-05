using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CodeBlue.Models;

namespace CodeBlue.ViewModels.Accounts
{
    public class ApplicationUserEditViewModel
    {
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //model data for drop downs and other selectors
        public List<ApplicationRoles> Roles { get; set; }
        public List<Position> Positions { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}