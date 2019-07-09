using AdminTEmplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected FitnessDbEntities1 db;
        public BaseController()
        {
            //ViewBag.Club = db.ClubInfoes.ToList().FirstOrDefault();  
            db = new FitnessDbEntities1();

        }


    }
}