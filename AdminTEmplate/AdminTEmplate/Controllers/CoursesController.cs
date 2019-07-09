using AdminTEmplate.Helpers;
using AdminTEmplate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTEmplate.Controllers
{
    [Auth]
    public class CoursesController : BaseController
    {
        // GET: Courses
        List<string> AuthorList = new List<string>() {

            "Male",
            "Female"
        };

        

        public ActionResult Index()
        {

            ViewModel model = new ViewModel()
            {   
            Courses = db.Courses.ToList(),
                Trainers = db.Trainers.ToList(),
                Packs = db.Packages.ToList(),
                Rooms = db.Rooms.ToList(),
                Gender = AuthorList,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Cours cours)
        {
            if (cours.PackId == null || cours.TrainerId == null || cours.RoomId == null)
            {
                return RedirectToAction("Index");
            }

            if (cours.Id == 0)
            {
                db.Courses.Add(cours);
                db.SaveChanges();
            }
            else
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
            }
          
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var cours = db.Courses.Find(id);
            db.Courses.Remove(cours);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = new ViewModel()
            {
                Cours = db.Courses.Find(id),
                Trainers = db.Trainers.ToList(),
                Packs = db.Packages.ToList(),
                Rooms = db.Rooms.ToList(),
                Courses = db.Courses.ToList()
            };
            return View("Index",model);
        }
    }
}