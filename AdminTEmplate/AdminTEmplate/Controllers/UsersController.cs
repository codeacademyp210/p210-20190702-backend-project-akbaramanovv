using AdminTEmplate.Helpers;
using AdminTEmplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
    [Auth]
    public class UsersController : BaseController
    {
        // GET: Users
        public ActionResult Index()
        {
            var model = new ViewModel()
            {
                Users = db.Users.ToList(),
             
            };
            return View(model);
        }
        public ActionResult Uprofile()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            List<string> gender = new List<string>()
            {
                "Male",
                "Female",
                "Other"
            };
            List<string> status = new List<string>()
            {
                "Approved",
                "Pending",
                "Blocked"
            };
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;
            var model = new ViewModel()
            {
                Gender = gender,
                Users = db.Users.ToList(),
                Status =status

            };
            return View(model);
        }

        public ActionResult EditUser(int id)
        {
            List<string> gender = new List<string>()
            {
                "Male",
                "Female",
                "Other"
            };
            List<string> status = new List<string>()
            {
                "Approved",
                "Pending",
                "Blocked"
            };
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;
            var model = new ViewModel()
            {
                Gender = gender,
                User = db.Users.Find(id),
                Users = db.Users.ToList(),
                Status = status
            };
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("AddUser", model);
        }
        public ActionResult Paymnet()
        {
            var model = new ViewModel()
            {
                Payments = db.Payments.ToList(),
               UsersPendings = db.UsersPendings.ToList()

            };
            return View(model);
        } 

        public ActionResult Add(HttpPostedFileBase Photo , User user)
        {

            string PhotoName = "";
            string image = "";
           
            if (user == null)
            {
                return HttpNotFound();
            }
            if (user.Id == 0)
            {
                if (Photo != null)
                {
                    PhotoName = DateTime.Now.ToString("yyyyMMddmmssfff") + Photo.FileName;
                    image = Path.Combine(Server.MapPath("~/Uploads"), PhotoName);
                    Photo.SaveAs(image);
                    user.Photo = PhotoName;
                }
                db.Users.Add(user);
                db.SaveChanges();
            }
            else
            {
                if (Photo != null)
                {
                    PhotoName = DateTime.Now.ToString("yyyyMMddmmssfff") + Photo.FileName;
                    image = Path.Combine(Server.MapPath("~/Uploads"), PhotoName);
                    Photo.SaveAs(image);
                    user.Photo = PhotoName;
                }
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email)|| string.IsNullOrEmpty(user.PhoneNumber))
                {
                    return HttpNotFound();
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        } 

        public ActionResult DeleteUser(int id)
        {
            var model = db.Users.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}