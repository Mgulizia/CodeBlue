using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeBlue.Models;

namespace CodeBlue.ViewModels.Ticket
{
    public class TicketDetailsViewModel
    {
        public Models.Ticket Ticket { get; set; }
        public List<Comments> Comments { get; set; }
        public Comments NewComment { get; set; }
        public int? TicketStatus { get; set; }
        public List<ApplicationUser> Technicians { get; set; }
        public List<TicketStatus> TicketStatuses { get; set; }

    }
}