using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeBlue.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Add your new models here to have them migrated to the database
        public DbSet<ApplicationRoles> ApplicationRoles { get; set; }
       
        public DbSet<Position> Positions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<Comments> Comments { get; set; }




        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}