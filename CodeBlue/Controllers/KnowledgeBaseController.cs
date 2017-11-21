using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBlue.Controllers
{
    public class KnowledgeBaseController : Controller
    {
        // GET: KnowledgeBase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}