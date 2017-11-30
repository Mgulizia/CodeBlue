using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class KnowledgeBaseCatagory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Catagory Name")]
        public string CatagoryName { get; set; }
    }
}