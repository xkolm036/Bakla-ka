using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces.Models;
using System.Web.UI;

namespace StrankyObce.Controllers
{
    public class StaticPagesController : Controller
    {
        // GET: StaticPages
        public ActionResult Page_Show(string name)
        {
            Stranka s = new Stranka { text = System.IO.File.ReadAllText(Server.MapPath(@"~/Stranky/" + name + ".txt")) };
            s.title = name;
            return View(s);
        }
       
        public ActionResult Page_Edit(string name)
        {
            Stranka s = new Stranka { text = System.IO.File.ReadAllText(Server.MapPath(@"~/Stranky/" + name + ".txt")) };
            s.title = name;
            return View(s);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Page_Edit_Comit(Stranka s, string name)
        {
            System.IO.File.WriteAllText(Server.MapPath(@"~/Stranky/" + name + ".txt"), s.text);
            TempData["msg-succes"] = "Stránka byla uspěšně upravena";
            return RedirectToAction("Page_Show", "StaticPages", new { name = name });
        }
    }
}