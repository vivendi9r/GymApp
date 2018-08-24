using FitApp.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", activity);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Activities.Add(activity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        // GET: Activity/Edit/5
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
                db.Activities.Find(activity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Activity/Delete/5
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
                db.Activities.Remove(activity);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
