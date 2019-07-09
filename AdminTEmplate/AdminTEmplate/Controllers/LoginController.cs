using AdminTEmplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Index
        public ActionResult Index()
        {
            var model = new Adminn()
            {
                Admin = db.Admins.ToList().FirstOrDefault()

            };
            return View(model);
        }

       
        public ActionResult IsLogin(Admin adminn)
        {
            bool isLogin = false;
            if (string.IsNullOrEmpty(adminn.Email) || string.IsNullOrEmpty(adminn.Password))
            {
                return RedirectToAction("Index");
            }
            Admin adm = db.Admins.Where(a => a.Email == adminn.Email).FirstOrDefault();
            if (adm == null)
            {
                return RedirectToAction("Index");
            }
            isLogin = Crypto.VerifyHashedPassword(adm.Password, adminn.Password);
            if (isLogin == false)
            {
                return RedirectToAction("Index","Login");
            }
            Session["IsLogin"] = isLogin;

            return RedirectToAction("Index","Home");
        }
        public ActionResult Logout()
        {
            Session["IsLogin"] = null;
            return RedirectToAction("Index");
        }
      

    }
}