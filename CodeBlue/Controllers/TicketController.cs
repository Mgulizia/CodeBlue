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
            var currentUser = UserManager.FindById(User.Identity.GetUserId());

            var myTickets = _context.Tickets
                .Include(c => c.Department)
                .Include(c => c.CreatedByApplicationUser)
                .Include(c=>c.TicketStatus)
                .Where(c=>c.CreatedByApplicationUserId == currentUser.Id)
                .ToList();

            var availableTickets = _context.Tickets
                .Include(c => c.Department)
                .Include(c => c.CreatedByApplicationUser)
                .Where(c=>c.TicketStatusId == TicketStatusNames.New)
                .ToList();

            var myAssignedTickets = _context.Tickets
                .Include(c => c.Department)
                .Include(c => c.CreatedByApplicationUser)
                .Where(c=>c.AssignedToApplicationUserId == currentUser.Id && c.TicketStatusId != 2 && c.TicketStatusId < 6)
                .ToList();

            var closedTickets = new List<Ticket>();

            if (User.IsInRole("canManageTickets"))
            {
                closedTickets = _context.Tickets
                .Include(c => c.Department)
                .Include(c => c.CreatedByApplicationUser)
                .Where(c=>c.TicketStatusId == TicketStatusNames.ClosedByRequestor ||
                c.TicketStatusId == TicketStatusNames.ClosedCompleted ||
                c. TicketStatusId == TicketStatusNames.ClosedNonCompliance ||
                c. TicketStatusId == TicketStatusNames.ClosedNotCompleted)
                .ToList();
            }
            else
            {
                closedTickets = _context.Tickets
                    .Include(c => c.Department)
                    .Include(c => c.CreatedByApplicationUser)
                    .Where(c => c.TicketStatusId == TicketStatusNames.ClosedByRequestor ||
                                c.TicketStatusId == TicketStatusNames.ClosedCompleted ||
                                c.TicketStatusId == TicketStatusNames.ClosedNonCompliance ||
                                c.TicketStatusId == TicketStatusNames.ClosedNotCompleted &&
                                c.CreatedByApplicationUserId == currentUser.Id)
                    .ToList();
            }

            var viewModel = new TicketIndexViewModel()
            {
                MyTickets = myTickets,
                AvailableTickets = availableTickets,
                MyAssignedTickets = myAssignedTickets,
                ClosedTickets = closedTickets
            };

            return View("Index", viewModel);
        }



        //GET: Ticket/View/{ticketId]
        public ActionResult View(int ticketId)
        {
            var ticket = _context.Tickets
                .Include(c => c.Department)
                .Include(c => c.CreatedByApplicationUser)
                .Include(c => c.AssignedToApplicationUser)
                .Include(c => c.TicketStatus)
                .Single(c => c.Id == ticketId);

            var ticketcomments = _context.Comments
                .Include(c => c.PostedBy)
                .Where(c => c.RelatedTicketId == ticketId && c.IsEnabled == true)
                .OrderBy(c=>c.PostedOn)
                .ToList();

            var technicians = _context.Users
                .Include(c=>c.Position)
                .Where(c => c.IsEnabled == true && c.PositionId < 6)
                .ToList();

            List<TicketStatus> ticketStatuses = _context.TicketStatuses.ToList();

            var viewModel = new TicketDetailsViewModel
            {
                Ticket = ticket,
                Comments = ticketcomments,
                Technicians = technicians,
                TicketStatuses = ticketStatuses
            };

            return View("Details", viewModel);
        }


        //GET: Ticket/Take/{ticketId]
        public ActionResult Take(int ticketId)
        {
            var ticket = _context.Tickets.Single(c => c.Id == ticketId);
            var currentUser = UserManager.FindById(User.Identity.GetUserId());

            ticket.AssignedToApplicationUserId = currentUser.Id;
            ticket.TicketStatusId = TicketStatusNames.AssignedToTechnician;

            _context.SaveChanges();



            return RedirectToAction("Index", "Ticket");
        }

        // GET: Ticket/UpdateStatus
        public ActionResult UpdateStatus(TicketDetailsViewModel model)
        {
            if (model.TicketStatus != 99)
            {
                var ticketInDb = _context.Tickets.Single(c => c.Id == model.Ticket.Id);
                ticketInDb.TicketStatusId = model.TicketStatus;
                ticketInDb.CompletedDate = DateTime.Now;
                _context.SaveChanges();
            }
            

            return RedirectToAction("Index", "Ticket");
        }

        // GET: Ticket/UpdateTechnician
        public ActionResult UpdateTecnician(TicketDetailsViewModel model)
        {
            
            var ticketInDb = _context.Tickets.Single(c => c.Id == model.Ticket.Id);
            ticketInDb.AssignedToApplicationUserId = model.Ticket.AssignedToApplicationUserId;
            _context.SaveChanges();

            return RedirectToAction("View", "Ticket", new{ticketId = model.Ticket.Id});
        }



        // GET: Ticket/EscalateTicket
        public ActionResult EscalateTicket(TicketDetailsViewModel model)
        {
            
            var ticketInDb = _context.Tickets.Single(c => c.Id == model.Ticket.Id);
            ticketInDb.TicketStatusId = TicketStatusNames.EscalatedBySupervisor;
            _context.SaveChanges();

            return RedirectToAction("View", "Ticket", new{ticketId = model.Ticket.Id});
        }


        // GET: Ticket/OverrideTicketStatus
        public ActionResult OverrideTicketStatus(TicketDetailsViewModel model)
        {

            var ticketInDb = _context.Tickets.Single(c => c.Id == model.Ticket.Id);
            ticketInDb.TicketStatusId = model.Ticket.TicketStatusId;

            switch (model.Ticket.TicketStatusId)
            {
                case 1:
                    if (ticketInDb.AssignedToApplicationUserId != "")ticketInDb.AssignedToApplicationUserId = "";
                    if (model.Ticket.CompletedDate != null)ticketInDb.CompletedDate = null;
                    break;
                case 2:
                case 6:
                case 7:
                case 8:
                    ticketInDb.CompletedDate = DateTime.Now;
                    break;
                case 3:
                case 5:
                    if (model.Ticket.CompletedDate != null) ticketInDb.CompletedDate = null;
                    break;
            }
            _context.SaveChanges();

            return RedirectToAction("View", "Ticket", new { ticketId = model.Ticket.Id });
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



        public ActionResult AddComments(TicketDetailsViewModel model)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var commentInDb = new Comments();
            _context.Comments.Add(commentInDb);
        
            commentInDb.PostedById = user.Id;
            commentInDb.PostedOn = DateTime.Now;
            commentInDb.RelatedTicketId = model.NewComment.RelatedTicketId;
            commentInDb.Comment = model.NewComment.Comment;
            commentInDb.IsEnabled = true;
        
            _context.SaveChanges();
        
            return RedirectToAction("View", new { ticketId = model.NewComment.RelatedTicketId});
        }

        public ActionResult RemoveComments(TicketDetailsViewModel model)
        {
            var commentInDb = _context.Comments.Single(c => c.Id == model.NewComment.Id);
            if (commentInDb.IsEnabled)
                commentInDb.IsEnabled = false;

            _context.SaveChanges();


            return RedirectToAction("View", new { ticketId = model.NewComment.RelatedTicketId});
        }
        
    }
}
