using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitApp.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var activity = db.Activities.ToList();
                return View(activity);

            }
        }

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var activity = db.Activities.Find(id);
                if (activity == null)
                    return View("Error");
                return View(activity);

            }
        }

        // GET: Activity/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(CreateActivityViewModels activity)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", activity);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var model = new CreateActivityViewModels
                {
                    Rooms = db.Rooms.ToList(),
                    Coachs = db.Coachs.ToList(),
                    Name = activity.Name,
                    Start_time = activity.Start_time,
                    End_time = activity.End_time
                };

                //db.Activities.Add(activity);
                db.SaveChanges();

                return RedirectToAction("Index", model);
            }

        }

        // GET: Activity/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var activity = db.Activities.Find(id);
                if (activity == null)
                    return View("Error");
                return View(activity);

            }
            
        }

        // POST: Activity/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", activity);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Activity/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var activity = db.Activities.Find(id);
                if (activity == null)
                    return View("Error");
                return View(activity);

            }
        }

        // POST: Activity/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete", activity);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                activity = db.Activities.Find(id);
                db.Activities.Remove(activity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
