using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitApp.Models;

namespace FitApp.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Grafik()
        {
            return View();
        }

        public ActionResult Cennik()
        {
            return View();
        }

        public ActionResult Kalkulatory()
        {
            return View();
        }

        public ActionResult BMR(BMR bmr)
        {
            return View();
        }

        
        public ActionResult BMI()
        {
            //var yourBMI = 0;
            return View();
        }

        [HttpPost]
        public ActionResult BMI(BMI bmi)
        {
            var yourBMI = (bmi.Weight / ((bmi.Height/100) * (bmi.Height/100)));
            ViewBag.Message = yourBMI;
            return View("YourBMI");
        }

        public ActionResult ONERM(ONERM onerm)
        {
            return View();
        }

        public ActionResult Edukacja()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
           

            return View();
        }
    }
}