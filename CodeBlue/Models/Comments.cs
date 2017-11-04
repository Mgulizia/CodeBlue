using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlue.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public DateTime PostedOn { get; set; }
        public string Comment { get; set; }

        public ApplicationUser PostedBy { get; set; }
        public string PostedById { get; set; }

        public Ticket RelatedTicket { get; set; }
        public int RelatedTicketId { get; set; }




    }
}