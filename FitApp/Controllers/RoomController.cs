using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitApp.Controllers
{
    public class RoomController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var room = db.Rooms.ToList();
                return View(room);

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
        public ActionResult Create(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", room);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Rooms.Add(room);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var room = db.Rooms.Find(id);
                if (room == null)
                    return View("Error");
                return View(room);

            }

        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", room);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Activities.Find(room);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var room = db.Rooms.Find(id);
                if (room == null)
                    return View("Error");
                return View(room);

            }
        }

        // POST: Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Room room)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete", room);
            }
            else
            {
                ApplicationDbContext db = new ApplicationDbContext();
                db.Rooms.Remove(room);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
