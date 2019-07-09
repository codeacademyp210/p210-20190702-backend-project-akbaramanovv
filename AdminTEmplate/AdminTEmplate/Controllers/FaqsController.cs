using AdminTEmplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
    [Auth]
    public class FaqsController : Controller
    {
        // GET: Faqs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddFaq()
        {
            return View();
        }
    }
}