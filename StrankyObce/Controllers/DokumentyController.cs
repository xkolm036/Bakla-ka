using System;
using System.Collections.Generic;
using System.IO;
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

                string path = Server.MapPath(@"~/App_Data/Dokumenty/");
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Path.Combine(path, file.FileName));
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