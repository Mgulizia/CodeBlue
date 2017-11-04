using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ticket Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Ticket Completion Date")]
        public DateTime? CompletedDate { get; set; }

        [Required]
        [Display(Name = "Ticket Subject")]

        public string TicketSubject { get; set; }

        [Required]
        [Display(Name = "Explain the Issue")]
        public string TicketSummary { get; set; }

        [Display(Name = "Priority of this Ticket")]
        public int? TicketPriority { get; set; }




        //Need implementation
            // Ticket status
            // Add list<Comments>


       
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public TicketStatus TicketStatus { get; set; }
        public int? TicketStatusId { get; set; }

        public ApplicationUser CreatedByApplicationUser { get; set; }
        public string CreatedByApplicationUserId { get; set; }

        public ApplicationUser AssignedToApplicationUser { get; set; }
        public string AssignedToApplicationUserId { get; set; }

        public ApplicationUser ClosedByApplicationUser { get; set; }
        public string ClosedByApplicationUserId { get; set; }
        
    }



}