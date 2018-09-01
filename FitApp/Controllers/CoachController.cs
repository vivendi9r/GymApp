using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitApp.Controllers
{
    public class CoachController : Controller
    {

        // GET: Coach
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var coach = db.Coachs.ToList();
                return View(coach);

            }
        }

        // GET: Coach/Details/5
        public ActionResult Details(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var coach = db.Coachs.Find(id);
                if (coach == null)
                    return View("Error");
                return View(coach);

            }
        }

        // GET: Coach/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coach/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Coach coach)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", coach);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Coachs.Add(coach);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        // GET: Coach/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var coach = db.Coachs.Find(id);
                if (coach == null)
                    return View("Error");
                return View(coach);

            }

        }

        // POST: Coach/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, Coach coach)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", coach);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                
                db.Entry(coach).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Coach/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var coach = db.Coachs.Find(id);
                if (coach == null)
                    return View("Error");
                return View(coach);

            }
        }

        // POST: Coach/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, Coach coach)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete", coach);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                coach = db.Coachs.Find(id);
                db.Coachs.Remove(coach);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}