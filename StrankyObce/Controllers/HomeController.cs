using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces;

namespace StrankyObce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Background = "background";
            return View(Clanky1.VseZDB());
        }

        public ActionResult Info()
        {
            return View();
        }


        public ActionResult Form(string FirstName)
        {
            ViewBag.jmeno = FirstName;
            return View();
        }

    }
}