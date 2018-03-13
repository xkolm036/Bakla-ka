using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAcces.Models;


namespace StrankyObce.Controllers
{
    public class ClankyController : Controller
    {
        // GET: Clanky
    
        [Authorize]
        public ActionResult Pridat()
        {
            return View();

        }

        [ValidateInput(false)]
        public ActionResult Pridej(Clanky cl)
        {
            //ViewBag.EmailTemp = Request.Form["Clanek"];

        
            cl.Datum_Vytvoreni = System.DateTime.Today;
            

            if (ModelState.IsValid)
            {
              cl.Text=Server.HtmlDecode(cl.Text);
                Clanky.pridejDoDB(cl);
                TempData["msg-succes"] = "Clanek byl uspěšně přidán";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg-error"] = "Vyplňte všechna data";
                return View("Pridat", cl);
            }
        }
        [Authorize]
        public ActionResult Seznam()
        {
            return View(Clanky.VseZDB());
        }

        public ActionResult Smazat(int id)
        {
            Clanky.odeberZDB(id);
            TempData["msg-succes"] = "Článek byl úspěšně smazán";
            return RedirectToAction("Seznam", "Clanky");
        }
        
        public ActionResult Upravit(int id)
        {
            Clanky cl = new Clanky();
            cl = Clanky.vyberZDb(id);
            return View(cl);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Clanky cl, int id)
        {
            cl.ID = id;
            Clanky.update(cl);
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

            Clanky.vyberZDb(id);


            return View(Clanky.vyberZDb(id));
        }
    }
}