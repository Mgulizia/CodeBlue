using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeBlue.Models;

namespace CodeBlue.ViewModels.Ticket
{
    public class TicketCrudViewModel
    {
        public Models.Ticket Ticket { get; set; }
        public List<Department> Departments { get; set; }
    }
}