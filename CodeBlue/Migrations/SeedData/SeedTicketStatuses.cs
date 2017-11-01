using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CodeBlue.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Migrations.SeedData
{
    public static class SeedTicketStatuses
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            //Add additional positions here
            context.TicketStatuses.AddOrUpdate(x => x.Id,
                new TicketStatus() { Id= 1, StatusDescription = "New"},
                new TicketStatus() { Id= 2, StatusDescription = "Closed By Requestor"},
                new TicketStatus() { Id= 3, StatusDescription = "Assigned to Technician"},
                new TicketStatus() { Id= 4, StatusDescription = "Escalated by Supervisor"},
                new TicketStatus() { Id= 5, StatusDescription = "Set for Follow Up"},
                new TicketStatus() { Id= 6, StatusDescription = "Closed - Completed"},
                new TicketStatus() { Id= 7, StatusDescription = "Closed - Not Completed"},
                new TicketStatus() { Id= 8, StatusDescription = "Closed - Non Compliance"}
            );
            context.SaveChanges();
        }
    }
}