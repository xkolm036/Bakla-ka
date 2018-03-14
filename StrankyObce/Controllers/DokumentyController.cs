using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StrankyObce.Controllers
{
    public class DokumentyController : Controller
    {
        // GET: Dokumenty
   

        public ActionResult UpFrom()
        {


            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                var model = Server.MapPath(@"~/Dokumenty/") + file.FileName;
                if (file.ContentLength > 0)
                {
                    file.SaveAs(model);
                    TempData["msg-succes"] = file.FileName + " byl uspěšně nahrán";

                }
                else
                {
                    TempData["msg-error"] = "Prazdný soubor nelze nahrát";
                }

            }
            catch (System.NullReferenceException)
            {
                TempData["msg-error"] = "Nebyl zvolen žádný soubor";
                return RedirectToAction("UpForm");

            }

            return RedirectToAction("Index", "Home");
        }



    }
}