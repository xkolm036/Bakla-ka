using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces.Models;

namespace StrankyObce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {/*
            Clanky1 ww=new Clanky1 {Text="řřřřř",Autor="tst",Datum="1.1.2018",Nazev="pokus"};
            Clanky1.pridejDoDB(ww);*/
            ViewBag.Background = "background";

            List<Clanky> cl = new List<Clanky>();
            DBControl.FirtsN(0,ref cl, true);

            return View(cl);
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