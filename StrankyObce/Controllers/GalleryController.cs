using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using DataAcces.Models;
using System.IO;

namespace StrankyObce.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index(string year="last")
        {
            List<string> rokyVDB=new List<string>();
           
            List<Images> imagescollection = new List<Images>();
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {

                if (year == "last")
                {
                    var data = context.ImagesSet.OrderByDescending(i => i.Rok_nahrani).Take(1);
                   foreach(Images img in data)
                    {
                        year = img.Rok_nahrani;

                    }
                }

                var allyers = context.ImagesSet.Select(i => i.Rok_nahrani);
                foreach (string s in allyers)
                {
                    if (!rokyVDB.Contains(s))
                    {
                        rokyVDB.Add(s);

                    }

                }

                ViewBag.roky = rokyVDB;

                var data1 = context.ImagesSet.Where(i => i.Rok_nahrani == year);

                foreach (Images img in data1)
                {
                    imagescollection.Add(img);
                }

            }
            return View(imagescollection);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase picture, int quality)
        {
            string path = Path.Combine(Server.MapPath(@"~/Public_Images/"), picture.FileName);

            if (System.IO.File.Exists(path))
            {
                TempData["msg-error"] = "Soubor již existuje";
                return RedirectToAction("Index", "Gallery");
            }


            //  file.SaveAs(path);
            if (picture.ContentLength > 0)
            {
                using (hrebec_dataEntities context = new hrebec_dataEntities())
                {
                    Images i = new Images();
                    i.Nazev = picture.FileName;
                    i.Rok_nahrani = DateTime.Today.Year.ToString();
                    i.Umisteni = path;
                    context.ImagesSet.Add(i);
                    context.SaveChanges();

                    TempData["msg-succes"] = picture.FileName + " byl uspěšně nahrán";

                }
                if (picture.ContentLength > 1000000) //>1MB
                   quality = 45;

                if (picture.ContentLength < 1000000 && picture.ContentLength > 500000) //>500Kb -1 MB
                    quality = 60;

                Images.SaveJpeg(path, quality, Image.FromStream(picture.InputStream, true, true));
            }
            return RedirectToAction("Index", "Gallery");
        }
        [Authorize]
        [HttpPost]
        public ActionResult delete(List<Images> checkedimage)
        {
            Images filesFromDB = new Images();
            using (hrebec_dataEntities contex = new hrebec_dataEntities())
            {
                foreach (Images file in checkedimage)
                {

                    if (file.selected == true)
                    {
                        try
                        {
                            filesFromDB = contex.ImagesSet.FirstOrDefault(f => f.ID == file.ID);
                            System.IO.File.Delete(filesFromDB.Umisteni); // odstraneni ze serveru
                            TempData["msg-succes"] = "obrázek " + filesFromDB.Nazev + "Byl úspěšně odstraněn";
                        }
                        catch { TempData["msg-error"] = "Sobor " + filesFromDB.Nazev + "Nebyl nalezen na serveru"; }
                        finally
                        {
                            contex.ImagesSet.Remove(filesFromDB);       //odstraneni z db
                            contex.SaveChanges();
                        }
                    }

                }

            }

            return RedirectToAction("Index");
        }


    }
}