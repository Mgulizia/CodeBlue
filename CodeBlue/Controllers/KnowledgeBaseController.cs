using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeBlue.Models;
using CodeBlue.ViewModels.Accounts;
using CodeBlue.ViewModels.KnowledgeBase;
using Microsoft.AspNet.Identity;

namespace CodeBlue.Controllers
{
    public class KnowledgeBaseController : Controller
    {
        private ApplicationDbContext _context;

        public KnowledgeBaseController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: KnowledgeBase
        public ActionResult Index()
        {
            var vm = new KnowledgeBaseIndexViewModel
            {
                CurrentKnowledgeBase = _context.KnowledgeBase.ToList()
            };
            
            return View("Index", vm);
        }

        public ActionResult Create()
        {
            var knowledgeBase = new KnowledgeBase();
            var catagories = _context.KnowledgeBaseCatagories.ToList();
            var vm = new KnowledgeBaseCreateViewModel
            {
                KnowledgeBase = knowledgeBase,
                KnowledgeBaseCatagories = catagories
            };

            return View("Create", vm);
        }

        [HttpPost]
        public ActionResult Save(KnowledgeBaseCreateViewModel model)
        {
            var item = new KnowledgeBase
            {
                ArticleTitle = model.KnowledgeBase.ArticleTitle,
                Article = model.KnowledgeBase.Article,
                Category = model.KnowledgeBase.Category,
                DateAdded = DateTime.Today,
                Userid = User.Identity.GetUserId()

            };

            

            _context.KnowledgeBase.Add(item);
            _context.SaveChanges();

            return View("Index");
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}