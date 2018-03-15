using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Models 
{
    public class DBControl : hrebec_dataEntities


    {
        /// <summary>
        /// Vybere model na zaklade id
        /// </summary>
        public static Clanky SelectByID_Cl(int id)
        {
            Clanky clZdb = new Clanky();
            clZdb = null;
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                    clZdb = context.Clanky.FirstOrDefault(c => c.ID == id);
            }
            return clZdb;
        }

        public static Image SelectByID_Img(int id)
        {
            Image img = new Image();
            img = null;
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                img = context.Image.FirstOrDefault(c => c.ID == id);
            }
            return img;
        }

        public static Files SelectByID_File(int id)
        {
            Files f = new Files();
            f = null;
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                f = context.Files.FirstOrDefault(c => c.ID == id);
            }
            return f;
        }
        /// <summary>
        /// Prida model do DB
        /// </summary>
        public static void AddToDB(Clanky cl)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                context.Clanky.Add(cl);
                context.SaveChanges();
            }
        }

        public static void AddToDB(Image Im)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                context.Image.Add(Im);
                context.SaveChanges();
            }
        }

        public static void AddToDB(Files File)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                context.Files.Add(File);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Vybere prvních N z db nebo vsechny záznamy all=true
        /// </summary>
        public static void FirtsN(int N, ref List<Clanky> ClFromDb, bool all = false)
        {
            ClFromDb.Clear();
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                if (all == true) N = context.Clanky.Count();
                var data = context.Clanky.Take(N);

                foreach (Clanky DBcl in data)
                {
                    ClFromDb.Add(DBcl);
                }
            }

        }
    
        public static void FirtsN(int N, ref List<Files> files, bool all = false)
        {
            files.Clear();
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                if (all == true) N = context.Files.Count();
                var data = context.Files.Take(N);

                foreach (Files DBFile in data)
                {
                    files.Add(DBFile);
                }
            }
        }
      
        public static void FirtsN(int N, ref List<Image> image, bool all = false)
        {
            image.Clear();
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                if (all == true) N = context.Image.Count();
                var data = context.Image.Take(N);

                foreach (Image img in data)
                {
                    image.Add(img);
                }
            }
        }
        /// <summary>
        /// Uprava zazamu databaze
        /// </summary>
        public static void Update(Clanky cl)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                Clanky clZdb = new Clanky();
                clZdb = context.Clanky.FirstOrDefault(c => c.ID == cl.ID);
                clZdb = cl;
                context.SaveChanges();
            }
        }

        public static void Update(Image img)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                Image Im = new Image();
                Im = context.Image.FirstOrDefault(i => i.ID == img.ID);
                Im = img;
                context.SaveChanges();
            }
        }

        public static void Update(Files file)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                Files fileZDb = new Files();
                fileZDb = context.Files.FirstOrDefault(f => f.ID == file.ID);
                fileZDb = file;
                context.SaveChanges();
            }
        }


        public static void RemoveCL(int id)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                Clanky clZdb = new Clanky();
                clZdb = context.Clanky.FirstOrDefault(c => c.ID == id);
                context.Clanky.Remove(clZdb);
                context.SaveChanges();
            }
        }

        public static void RemoveFile(int id)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                Files f = new Files();
                f = context.Files.FirstOrDefault(c => c.ID == id);
                context.Files.Remove(f);
                context.SaveChanges();
            }
        }
        public static void RemoveImage(int id)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                Image i = new Image();
                i = context.Image.FirstOrDefault(c => c.ID == id);
                context.Image.Remove(i);
                context.SaveChanges();
            }
        }
    }
    }
