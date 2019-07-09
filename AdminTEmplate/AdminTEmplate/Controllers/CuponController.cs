using AdminTEmplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
    [Auth]
    public class CuponController : Controller
    {
        // GET: Cupon
        public ActionResult Index()
        {
            return View();
        }
    }
}