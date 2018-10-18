using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessForLife.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated && !User.IsInRole("FitnessManager"))
                return View("IndexUser");
            if (User.IsInRole("FitnessManager"))
                return View("IndexAdmin");
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Stay Healthy. Stay fit.";
  
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult Appointment()
        { 
            return View();
        }
    }
}