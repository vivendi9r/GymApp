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

        public ActionResult BMR()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BMR(BMR bmr)
        {
            var sex = 0.9;
            if (bmr.SexMale)
                sex = 1.0;
            var yourBMR = 24 * bmr.Weight * bmr.Activity/100 * sex;
            ViewBag.Message = yourBMR;
            return View("YourBMR");
        }

        public ActionResult BMI()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult BMI(BMI bmi)
        {
            var yourBMI = (bmi.Weight / ((bmi.Height/100) * (bmi.Height/100)));
            ViewBag.Message = yourBMI;
            return View("YourBMI");
        }

        public ActionResult ONERM()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ONERM(ONERM onerm)
        {
            //(weight*reps*0,0333) +weight
           
            var oneRepMax = (onerm.Weight * onerm.Reps * 0.0333)+ onerm.Weight;
            ViewBag.Message = oneRepMax;
            return View("YourONERM");
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