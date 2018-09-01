using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitApp.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var room = db.Rooms.ToList();
                return View(room);

            }
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var room = db.Rooms.Find(id);
                if (room == null)
                    return View("Error");
                return View(room);

            }
        }

        // GET: Room/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [Authorize(Roles = "admin")]
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

        // GET: Room/Edit/5
        [Authorize(Roles = "admin")]
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

        // POST: Room/Edit/5
        [Authorize(Roles = "admin")]
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
                //db.Rooms.Find(id);
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // GET: Room/Delete/5
        [Authorize(Roles = "admin")]
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

        // POST: Room/Delete/5
        [Authorize(Roles = "admin")]
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
                room = db.Rooms.Find(id);
                db.Rooms.Remove(room);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
