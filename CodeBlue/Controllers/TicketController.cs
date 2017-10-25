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

namespace CodeBlue.Controllers
{
    public class TicketController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public ApplicationUserManager _userManager { get; set; }

        public TicketController()
        {
            _context = new ApplicationDbContext();
 
        }




        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {


            var ticket = new Ticket
            {
                CreatedDate = DateTime.Today,
                CreatedByApplicationUser = _context.Users.Single(c => c.)
            };

            var viewModel = new TicketCrudViewModel
            {
                Ticket = ticket,
                Departments = _context.Departments.ToList()
            };

            return View("TicketForm", viewModel);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            var ticket = new Ticket
            {
                CreatedDate = DateTime.Today,
                CreatedByApplicationUser = _context.Users.Single(i => i.Id == User.Identity.GetUserId())
            };

            var viewModel = new TicketCrudViewModel
            {
                Ticket = ticket,
                Departments = _context.Departments.ToList()
            };

            return View("TicketForm", viewModel);
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
