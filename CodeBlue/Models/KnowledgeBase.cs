using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class KnowledgeBase
    {
        public int KnowledgeBaseId { get; set; }

        [Required]
        [Display(Name = "Article Description")]
        public string ArticleTitle { get; set; }

        [Required]
        [Display(Name = "Article")]
        public string Article { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public string Userid { get; set; }

        


    }

    public static class CategoryNames
    {
        public const int Administrator = 1;
        public const int TechnicianSupervisor = 2;
        public const int AdvancedTechniciannistrator = 3;
        public const int Technician = 4;
        public const int FieldTechnician = 5;
        public const int CustomerSupport = 6;
    }
}