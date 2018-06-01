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

            DateTime thisDay = DateTime.Today ;
            cl.Datum_Vytvoreni = thisDay;



            if (ModelState.IsValid)
            {
              cl.Text=Server.HtmlDecode(cl.Text);
                DBControl.AddToDB(cl);
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
            List<Clanky> cl = new List<Clanky>();
            DBControl.FirtsN(0, ref cl, true);
            return View(cl);
        }

        public ActionResult Smazat(int id)
        {
          DBControl.RemoveCL(id);
            TempData["msg-succes"] = "Článek byl úspěšně smazán";
            return RedirectToAction("Seznam", "Clanky");
        }
        
        public ActionResult Upravit(int id)
        {
            Clanky cl = new Clanky();
            cl = DBControl.SelectByID_Cl(id);
            return View(cl);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Clanky cl, int id)
        {
            cl.ID = id;
            DBControl.Update(cl);
            TempData["msg-succes"] = "Článek byl úspěšně upraven v editu";
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


            return View(DBControl.SelectByID_Cl(id));
        }
    }
}