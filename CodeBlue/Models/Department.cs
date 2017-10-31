using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }


        public bool IsEnabled { get; set; }

    }
}