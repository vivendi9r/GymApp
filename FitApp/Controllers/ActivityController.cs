﻿using FitApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FitApp.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        // GET: Activity
        
        public ActionResult Index(string sortby = "")
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var activity = db.Activities.ToList().Select(x => new ActivityViewModel
                {
                    ActivityId = x.ActivityId,
                    Name = x.Name,
                    Coach = db.Coachs.Find(x.CoachId).Name,
                    End_time = x.End_time,
                    Start_time = x.Start_time,
                    Room = db.Rooms.Find(x.RoomId).Name,
                    OccupiedPlaces = db.ActivitiesUsers.Where(y => y.ActivityId == x.ActivityId).Count()
                ,
                    AvailablePlaces = 20,
                    Participant = db.ActivitiesUsers.Any(y => y.UserId == userId && y.ActivityId == x.ActivityId),
                    UserId = userId
                    
                }).ToList();
                switch (sortby.ToLower())
                {
                    case "room":
                        activity = activity.OrderBy(x => x.Room).ToList();
                        break;
                    case "room_desc":
                        activity = activity.OrderByDescending(x => x.Room).ToList();
                        break;
                    case "coach":
                        activity = activity.OrderBy(x => x.Coach).ToList();
                        break;
                    case "coach_desc":
                        activity = activity.OrderByDescending(x => x.Coach).ToList();
                        break;
                    case "end_time":
                        activity = activity.OrderBy(x => x.End_time).ToList();
                        break;
                    case "end_time_desc":
                        activity = activity.OrderByDescending(x => x.End_time).ToList();
                        break;
                    case "start_time":
                        activity = activity.OrderBy(x => x.Start_time).ToList();
                        break;
                    case "start_time_desc":
                        activity = activity.OrderByDescending(x => x.Start_time).ToList();
                        break;
                    case "name":
                        activity = activity.OrderBy(x => x.Name).ToList();
                        break;
                    case "name_desc":
                        activity = activity.OrderByDescending(x => x.Name).ToList();
                        break;
                    case "occupied_place":
                        activity = activity.OrderBy(x => x.OccupiedPlaces).ToList();
                        break;



                    default:
                        activity = activity.OrderBy(x => x.Name).ToList();
                        break;
                }
                
               
                return View(activity);

            }
        }

        
        public ActionResult SendEmail()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var receiver = User.Identity.GetUserName();
            var subject = "FitApp - Potwierdzenie zapisów na zajęcia";
            var message = "Witaj! Nie zapomnij o swoich zajęciach! Czekamy na Ciebie!"; 
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("przemek930010@gmail@gmail.com", "Barczik");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "Your Email Password here";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
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

        [HttpPost]
        
        public async Task<ActionResult> Involved(int ActivityId, Guid UserId)
        {
            using (var context = new ApplicationDbContext())
            {
                var model = await context.Activities.FindAsync(ActivityId);
                var emailModel = new ActivityEmailMessageViewModel()
                {
                    Name = model.Name,
                    Start_time = model.Start_time,
                    End_time = model.End_time,
                    Coach = context.Coachs.Find(model.CoachId).Name,
                    Room = context.Rooms.Find(model.RoomId).Name
                };
                
                string subject = $"Przypomnienie zajęcia z {emailModel.Name}";
                string body = $"{emailModel.Name} {emailModel.Start_time} {emailModel.End_time} {emailModel.Coach} {emailModel.Room}";

            
                context.ActivitiesUsers.Add(new ActivityUser { ActivityId = ActivityId, UserId = UserId });
                await context.SaveChangesAsync();
                EmailService serivce = new EmailService();
                await serivce.SendAsync(new IdentityMessage { Destination = User.Identity.Name, Subject = subject,Body=body});
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<ActionResult> NotInvolved(int ActivityId, Guid UserId)
        {
            using (var context = new ApplicationDbContext())
            {
                var model = context.ActivitiesUsers.Where(x => x.ActivityId == ActivityId && x.UserId == UserId).First();
            context.ActivitiesUsers.Remove(model);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("index");

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
