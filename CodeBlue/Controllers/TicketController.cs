﻿using System;
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
            var viewModel = new TicketIndexViewModel();

            if (User.IsInRole("CanManageTickets") || User.IsInRole("CanTakeTickets"))
            {
                if (User.IsInRole("CanManageTickets"))
                {
                    viewModel.Tickets = _context.Tickets
                        .Include(c => c.Department)
                        .Include(c => c.CreatedByApplicationUser)
                        .ToList();
                }
                else
                {
                    viewModel.Tickets = _context.Tickets
                        .Include(c => c.Department)
                        .Include(c => c.CreatedByApplicationUser)
                        .Where(c=>c.TicketStatusId == TicketStatusNames.New)
                        .ToList();
                }
            }
            else
            {
                var currentUser = UserManager.FindById(User.Identity.GetUserId());
                viewModel.Tickets = _context.Tickets
                    .Include(c => c.Department)
                    .Include(c => c.CreatedByApplicationUser)
                    .Where(c => c.CreatedByApplicationUserId == currentUser.Id)
                    .ToList();
            }

            return View("Index", viewModel);
        }

        //GET: Ticket/View/{ticketId]
        public ActionResult View(int ticketId)
        {
            var ticket = _context.Tickets
                .Include(c => c.Department)
                .Include(c => c.CreatedByApplicationUser)
                .Include(c => c.TicketStatus)
                .Single(c => c.Id == ticketId);
            var viewModel = new TicketDetailsViewModel {Ticket = ticket};

            return View("Details", viewModel);
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



            var user = UserManager.FindById(User.Identity.GetUserId());

            ticketInDb.CreatedDate = DateTime.Today;
            ticketInDb.TicketSubject = model.Ticket.TicketSubject;
            ticketInDb.CreatedByApplicationUserId = user.Id;
            ticketInDb.DepartmentId = model.Ticket.DepartmentId;
            ticketInDb.TicketSummary = model.Ticket.TicketSummary;
            ticketInDb.TicketPriority = 0;
            ticketInDb.TicketStatusId = TicketStatusNames.New;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
