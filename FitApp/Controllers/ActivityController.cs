using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
                var activity = db.Activities.ToList().Select(x=>new ActivityViewModel {ActivityId=x.ActivityId ,Name=x.Name, Coach=db.Coachs.Find(x.CoachId).Name,End_time=x.End_time, Start_time=x.Start_time,Room=db.Rooms.Find(x.RoomId).Name}).ToList();
               
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
        public ActionResult Create()
        {
            using (var db = new ApplicationDbContext()) {
                var model = new CreateActivityViewModels
                {
                    Rooms = db.Rooms.Select(x => new SelectListItem { Text = x.Name, Value = x.RoomId.ToString() }).ToList(),
                    Coachs = db.Coachs.Select(x => new SelectListItem { Text = x.Name, Value = x.CoachId.ToString() }).ToList()
                };
                     return View(model);
            }
         }
               
        

        // POST: Activity/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateActivityViewModels activity)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", activity);
            }
            else
            {
                using (var db = new ApplicationDbContext())
                {

                    var mapper = Automapper.GetInstance();
                    var model =  mapper.Map<Activity>(activity);
 


                    db.Activities.Add(model);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index", activity);
            }

        }

        // GET: Activity/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var activity =  await db.Activities.FindAsync(id);
                if (activity == null)
                    return View("Error");
                var mapper = Automapper.GetInstance();
                var model = mapper.Map<EditActivityFormViewModel>(activity);
                 model.Rooms  = await db.Rooms.Select(x => new SelectListItem { Text = x.Name, Value = x.RoomId.ToString() }).ToListAsync();
                 model.Coachs = await db.Coachs.Select(x => new SelectListItem { Text = x.Name, Value = x.CoachId.ToString() }).ToListAsync();
                return View(model);

            }
            
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditActivityFormViewModel activity)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", activity);
            }
            else
            {
                using (var db = new ApplicationDbContext())
                {
                    var mapper = Automapper.GetInstance();
                    var model = mapper.Map<Activity>(activity);
                    db.Entry(model).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
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
