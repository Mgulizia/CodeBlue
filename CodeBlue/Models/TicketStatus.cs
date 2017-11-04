using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class TicketStatus
    {
        public int Id { get; set; }

        [Required]
        public string StatusDescription { get; set; }

        public string StatusLabel()
        {
            switch (this.Id)
            {
                
               case 1: return  "<span style='font-size: 120%' class='label label-danger'>New</span>";
               case 2: return  "<span style='font-size: 120%' class='label label-default'>Closed : Per Requestor</span>";
               case 3: return  "<span style='font-size: 120%' class='label label-success'>Assigned to Technician</span>";
               case 4: return  "<span style='font-size: 120%' class='label label-warning'>Escalated</span>";
               case 5: return  "<span style='font-size: 120%' class='label label-info'>Set For Follow Up</span>";
               case 6: return  "<span style='font-size: 120%' class='label label-default'>Closed : Completed</span>";
               case 7: return  "<span style='font-size: 120%' class='label label-default'>Closed : Not Completed</span>";
               case 8: return  "<span style='font-size: 120%' class='label label-default'>Closed : Non Compliance</span>";
               default: return "<span style='font-size: 120%' class='label label-danger'>NO STATUS CODE!</span>";
                    
            }
        }

    }

    public static class TicketStatusNames
    {
        public static readonly int New = 1;
        public static readonly int ClosedByRequestor = 2;
        public static readonly int AssignedToTechnician = 3;
        public static readonly int EscalatedBySupervisor = 4;
        public static readonly int SetForFollowUp = 5;
        public static readonly int ClosedCompleted = 6;
        public static readonly int ClosedNotCompleted = 7;
        public static readonly int ClosedNonCompliance = 8;
    }
}