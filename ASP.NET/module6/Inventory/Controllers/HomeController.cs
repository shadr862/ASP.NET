using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Sample()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sample(string btn)
        {
            return RedirectToAction("Contact");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string btn)
        {
            if (btn == "submit")
            {
                ViewBag.Message = btn + " after submission";
            }
            if (btn == "search")
            {
                ViewBag.Message = btn + " after submission";
            }

            return View();
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your first landing page.";

            return View();
        }
        [HttpPost]
        public ActionResult About(string btn)
        {
            if(btn=="submit")
            {
                ViewBag.Message = btn+" after submission";
            }
            if (btn == "search")
            {
                ViewBag.Message = btn + " after submission";
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}