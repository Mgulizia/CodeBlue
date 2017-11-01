using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CodeBlue.Models;
using CodeBlue.ViewModels.Ticket;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CodeBlue.Controllers
{
    public class TicketController : Controller
    {
        
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public TicketController()
        {
            _context = new ApplicationDbContext();
        }

        public TicketController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            _context = new ApplicationDbContext();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Ticket
        public ActionResult Index()
        {
            return View("Index");
        }


        // GET: Ticket/Create
        public ActionResult Create()
        {
            var ticket = new Ticket
            {
                CreatedDate = DateTime.Today,
                CreatedByApplicationUser = UserManager.FindById(User.Identity.GetUserId()),
                TicketPriority = 0,
                TicketStatusId = TicketStatusNames.New
            };

            var viewModel = new TicketCrudViewModel
            {
                Ticket = ticket,
                Departments = _context.Departments.OrderBy(c => c.DepartmentName).ToList()
            };

            return View("TicketForm", viewModel);
        }

        public ActionResult Save(TicketCrudViewModel model)
        {
            Ticket ticketInDb;

            if (model.Ticket.Id == 0)
            {
                ticketInDb = new Ticket();
                _context.Tickets.Add(ticketInDb);
            }
            else
            {
                ticketInDb = _context.Tickets.Single(c => c.Id == model.Ticket.Id);
            }



            if (!ModelState.IsValid)
            {
                model.Departments = _context.Departments.ToList();
                return View("TicketForm", model);
            }

            ticketInDb.CreatedDate = DateTime.Today;
            ticketInDb.TicketSubject = model.Ticket.TicketSubject;
            ticketInDb.CreatedByApplicationUserId = model.Ticket.CreatedByApplicationUserId;
            ticketInDb.TicketSummary = model.Ticket.TicketSummary;
            ticketInDb.TicketPriority = 0;
            ticketInDb.TicketStatusId = TicketStatusNames.New;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
