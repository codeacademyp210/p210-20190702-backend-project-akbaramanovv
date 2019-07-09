using AdminTEmplate.Helpers;
using AdminTEmplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
   [Auth]
    public class HomeController : BaseController
    {
       
        public ActionResult Layout()
        {
            ViewModel model = new ViewModel()
            {
                ClubInfos = db.ClubInfoes.ToList(),
            };
           
            return PartialView(model);
        }
        public ActionResult Index()
        {
            var model = new ViewModel()
            {
                Users = db.Users.ToList(),
                Payments = db.Payments.ToList()
            };
            return View(model);
        }
        public ActionResult LoginIndex()
        {
            return View();
        }
        public ActionResult ChangePhoto( HttpPostedFileBase Photo ,int id)
        {
            string image = "";
            if (Photo!= null)
            {
                string photoName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                image = Path.Combine(Server.MapPath("~/Uploads"), photoName);
                Photo.SaveAs(image);
                ClubInfo ci = db.ClubInfoes.Find(id);
                ci.Photo = photoName;
                db.SaveChanges();
            }
           
            return RedirectToAction("ClubInfo");
        }
        public ActionResult ClubInfo( )
        {
            ViewModel model = new ViewModel()
            {
                ClubInfos = db.ClubInfoes.ToList(),
            };
            return View(model);
        }
       
    }
}