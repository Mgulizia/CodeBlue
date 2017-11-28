using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeBlue.Models;
using CodeBlue.ViewModels.Accounts;
using Microsoft.AspNet.Identity;

namespace CodeBlue.Controllers
{
    public class KnowledgeBaseController : Controller
    {
        private ApplicationDbContext _context;

        // GET: KnowledgeBase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KnowledgeBase model)
        {
            _context = new ApplicationDbContext();

            var title = model.ArticleTitle;
            var article = model.Article;
            var category = model.Category;
            var dateAdded = DateTime.Today;
            var userId = User.Identity.GetUserId();

            var addArticle = new KnowledgeBase()
            {
                ArticleTitle = title,
                Article = article,
                Category = category,
                DateAdded = dateAdded,
                Userid = userId
            };

            return View("View");
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}