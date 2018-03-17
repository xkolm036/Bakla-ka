using DataAcces.Models;
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

            List<Files> down = new List<Files>();
            List<Files> date = new List<Files>();

            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                var stazene = context.Files.OrderByDescending(i => i.Pocet_Stazeni).Take(7);
                var pridany = context.Files.OrderByDescending(i => i.Datum_Nahrani).Take(7);

                foreach (Files f in stazene)
                    down.Add(f);

                foreach (Files f in pridany)
                    date.Add(f);
            }

            ViewBag.down = down;
            ViewBag.date = date;


            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {

            try
            {


                string path = Path.Combine(Server.MapPath(@"~/App_Data/Dokumenty/"), file.FileName);
                if (file.ContentLength > 0)
                {

                    file.SaveAs(path);
                    TempData["msg-succes"] = file.FileName + " byl uspěšně nahrán";
                    using (hrebec_dataEntities context = new hrebec_dataEntities())
                    {

                        Files f = new Files();
                        f.Cesta = path;
                        f.Název = file.FileName;
                        DateTime thisDay = DateTime.Today;
                        f.Datum_Nahrani = DateTime.Parse(thisDay.ToString("D")); // jenom datum
                        int byteCount = file.ContentLength;
                        f.Velikost = byteCount;
                        f.Pocet_Stazeni = 0;

                        context.Files.Add(f);
                        context.SaveChanges();
                    }

                }
                else
                {
                    TempData["msg-error"] = "Prazdný soubor nelze nahrát";
                }
            }
            catch (System.NullReferenceException)
            {

            }




            return RedirectToAction("Index", "Home");
        }


        public FileResult Download(int id)
        {
            using (hrebec_dataEntities contex = new hrebec_dataEntities())
            {
                Files f =new Files();
                f = contex.Files.FirstOrDefault(x => x.ID == id);
                f.Pocet_Stazeni += 1;
                contex.SaveChanges();

                byte[] fileBytes = System.IO.File.ReadAllBytes(f.Cesta);
                var response = new FileContentResult(fileBytes, "application/octet-stream");
                response.FileDownloadName = f.Název;
          
                return response;

            }
               
        }

        public ActionResult AjaxRequest(string text)
        {
            List<Files> filesFromDB = new List<Files>();
            using (hrebec_dataEntities contex= new hrebec_dataEntities())
            {

                var DBfiles = contex.Files.Where(f => f.Název.ToLower().Contains(text.ToLower()));

                foreach (Files f in DBfiles)
                {
                    filesFromDB.Add(f);
                }

            }

                return View(filesFromDB);
        }

    }
}