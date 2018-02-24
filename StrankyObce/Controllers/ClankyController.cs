using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces;


namespace StrankyObce.Controllers
{
    public class ClankyController : Controller
    {
        // GET: Clanky
    
        [Authorize(Roles = "Admin")]
        public ActionResult Pridat()
        {
            return View();

        }

        [ValidateInput(false)]
        public ActionResult Pridej(Clanky1 cl)
        {
            //ViewBag.EmailTemp = Request.Form["Clanek"];

            cl.Autor = "aa";
            cl.Datum = System.DateTime.Today.ToString();
            

            if (ModelState.IsValid)
            {
              cl.Text=Server.HtmlDecode(cl.Text);
                Clanky1.pridejDoDB(cl);
                TempData["msg-succes"] = "Clanek byl uspěšně přidán";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg-error"] = "Vyplňte všechna data";
                return View("Pridat", cl);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Seznam()
        {
            return View(Clanky1.VseZDB());
        }

        public ActionResult Smazat(int id)
        {
            Clanky1.odeberZDB(id);
            TempData["msg-succes"] = "Článek byl úspěšně smazán";
            return RedirectToAction("Seznam", "Clanky");
        }
        
        public ActionResult Upravit(int id)
        {
            Clanky1 cl = new Clanky1();
            cl = Clanky1.vyberZDb(id);
            return View(cl);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Clanky1 cl, int id)
        {
            cl.Id = id;
            Clanky1.update(cl);
            TempData["msg-succes"] = "Článek byl úspěšně upraven";
            return RedirectToAction("Seznam", "Clanky");
        }

        public ActionResult Detail(int id)
        {
            /* var dotaz = from c in database.vratClanky()
                         where c.id == id
                         select c;

             Clanek cl = null;
             foreach (Clanek c in dotaz)
                 cl = c;*/

            Clanky1.vyberZDb(id);


            return View(Clanky1.vyberZDb(id));
        }
    }
}