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
    public class PackagesController : BaseController
    {
        // GET: Packages
        public ActionResult Index()
        {
            ViewModel model = new ViewModel()
            {
                
                Packs = db.Packages.ToList(),
        };
            return View(model);
        }
       
        public ActionResult Rooms()
        {
            var model = new ViewModel(){
                Rooms = db.Rooms.ToList(),
                Room = new Room()
            };
            return View(model);
        }
        public ActionResult Ttrainers()
        {
            var model = new ViewModel()
            {
                Trainers = db.Trainers.ToList(),
               
            };
            return View(model);
        }
        public ActionResult AddTrainer(HttpPostedFileBase Photo , Trainer trainer)
        {
            string PhotoName = "";
            string image = "";

            if (trainer.Name == null)
            {
                return HttpNotFound();
            }
            if (Photo != null)
            {
                PhotoName = DateTime.Now.ToString("yyyyMMddmmssfff") + Photo.FileName;
                image = Path.Combine(Server.MapPath("~/Uploads"), PhotoName);
                Photo.SaveAs(image);
               
            }
            else
            {
                PhotoName = "";
            }
            Trainer t = new Trainer();
            if (trainer.Id == 0)
            {
                t.Photo = PhotoName;
                t.Name = trainer.Name;
                db.Trainers.Add(t);
                db.SaveChanges();
            }
            else
            {
                if (Photo != null)
                {
                    PhotoName = DateTime.Now.ToString("yyyyMMddmmssfff") + Photo.FileName;
                    image = Path.Combine(Server.MapPath("~/Uploads"), PhotoName);
                    Photo.SaveAs(image);
                    //trainer.Name = trainer.Name;
                    trainer.Photo = PhotoName;
                }
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
            }
          
            return RedirectToAction("Ttrainers");
        }
        public ActionResult DeleteTrainer(int id)
        {
            var trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            db.Trainers.Remove(trainer);
            db.SaveChanges();
            return RedirectToAction("Ttrainers");
        }
        public ActionResult EditTrainer(int id)
        {
           
            var model = new ViewModel()
            {
                Trainer = db.Trainers.Find(id),
                Trainers = db.Trainers.ToList()
            };
            if (model == null)
            {
                return HttpNotFound();
            }
            
            return View("Ttrainers",model);
        }
        public ActionResult Add(Package package)
        {
            if (package.Id == 0)
            {
                db.Packages.Add(package);
                db.SaveChanges();
            }
            else
            {
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
           var model = new ViewModel()
            {
                Package = db.Packages.Find(id),
                Packs = db.Packages.ToList()
                
            };
            if(model == null)
            {
                return HttpNotFound();
            }


            return View("Index",model);
        }
        public ActionResult AddCourse(Cours cours)
        {
            if (cours.Id == 0)
            {
                db.Courses.Add(cours);
                db.SaveChanges();
            }
            return RedirectToAction("Courses");
        }
        [HttpPost]
        public ActionResult AddRoom(HttpPostedFileBase Photo, Room room )
        {
            string PhotoName = "";
            string image = "";
            if ( room.Name == null)
            {
                return RedirectToAction("Rooms");
            }
            if (Photo != null)
            {
                PhotoName = DateTime.Now.ToString("yyyyMMddmmssfff") + Photo.FileName;
                image = Path.Combine(Server.MapPath("~/Uploads"), PhotoName);
                Photo.SaveAs(image);
            }
            else
            {
                PhotoName = "";
            }
          
          
            if (room.Id == 0)
            {
               
                Room r = new Room();
                r.Photo = PhotoName;
                r.Name = room.Name;
                db.Rooms.Add(r);
                db.SaveChanges();
            }
            else
            {
                string upimage = "";
                string upPhotoName = "";
                if (Photo !=null)
                {
                    upPhotoName = DateTime.Now.ToString("yyyyMMddmmssfff") + Photo.FileName;
                    upimage = Path.Combine(Server.MapPath("~/Uploads"), upPhotoName);
                    Photo.SaveAs(upimage);
                    room.Photo = upPhotoName;
                    room.Name = room.Name;
                }
                else
                {
                    upPhotoName = "";
                }
               
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
            }
          

            return RedirectToAction("Rooms");
        }
        public ActionResult RoomDelete(int id)
        {
            var room = db.Rooms.Find(id);
            if (room == null)
            {
                return RedirectToAction("Rooms");
            }
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Rooms");
        }
        public ActionResult EditRoom( int id)
        {
            if (id==null)
            {
                return RedirectToAction("Rooms");
            }
            var model = new ViewModel()
            {
                Room = db.Rooms.Find(id),
                Rooms = db.Rooms.ToList()
            };
            return View("Rooms",model);
        }
    }
}