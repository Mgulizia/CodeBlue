using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class TicketStatus
    {
        public int Id { get; set; }

        [Required]
        public string StatusDescription { get; set; }

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