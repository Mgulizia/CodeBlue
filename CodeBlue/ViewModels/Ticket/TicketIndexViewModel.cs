using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlue.ViewModels.Ticket
{
    public class TicketIndexViewModel
    {
        public List<Models.Ticket> MyTickets { get; set; }
        public List<Models.Ticket> AvailableTickets { get; set; }
        public List<Models.Ticket> MyAssignedTickets { get; set; }
        public List<Models.Ticket> ClosedTickets { get; set; }
    }
}