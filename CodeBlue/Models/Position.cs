using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Position Description")]
        public string TitleDescription { get; set; }
        

    }

    public static class PositionNames
    {
        public const int Administrator = 1;
        public const int TechnicianSupervisor = 2;
        public const int AdvancedTechniciannistrator = 3;
        public const int Technician = 4;
        public const int FieldTechnician = 5;
        public const int CustomerSupport = 6;
    }
}