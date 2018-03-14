using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Models
{
    public class DBControl<T> : hrebec_dataEntities
         where T : class, new() 
   

    {
        /// <summary>
        /// Vrati polozku z DB na zaklade id
        /// </summary>
        public static T SelectByID(int id)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                try
                {
                    if (typeof(T) == typeof(Files))
                    {
                        Files FileZDb = new Files();
                        FileZDb = context.Files.FirstOrDefault(c => c.ID == id);
                        return (T)Convert.ChangeType(FileZDb, typeof(T));

                    }
                    if (typeof(T) == typeof(Image))
                    {
                        Image ImgZDb = new Image();
                        ImgZDb = context.Image.FirstOrDefault(c => c.ID == id);
                        return (T)Convert.ChangeType(ImgZDb, typeof(T));
                    }

                    if (typeof(T) == typeof(Clanky))
                    {
                        Clanky cl = new Clanky();
                        cl = context.Clanky.FirstOrDefault(c => c.ID == id);
                        return (T)Convert.ChangeType(cl, typeof(T));
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Přidání záznamu do DB
        /// </summary>
        public static void AddToDB(T model)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                try
                {
                    if (typeof(T) == typeof(Files))
                    {
                        context.Files.Add((Files)Convert.ChangeType(model, typeof(T)));
                        context.SaveChanges();


                    }
                    if (typeof(T) == typeof(Image))
                    {
                        Image ImgZDb = new Image();
                        ImgZDb = context.Image.Add((Image)Convert.ChangeType(model, typeof(T)));

                    }

                    if (typeof(T) == typeof(Clanky))
                    {
                        Clanky cl = new Clanky();
                        cl = context.Clanky.Add((Clanky)Convert.ChangeType(model, typeof(T)));

                    }
                }
                catch
                {

                }
            }

        }

        /// <summary>
        /// Vybere prvních N z db nebo vsechny záznamy all=true
        /// </summary>
        public static List<T> FirtsN(int N, bool all = false)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                try
                {
                    if (typeof(T) == typeof(Files))
                    {
                        if (all == true)
                            N = context.Files.Count();

                        var zaznamy = context.Files.Take(N);
                        List<Files> DB = new List<Files>();

                        foreach (Files f in zaznamy)
                        {
                            DB.Add(f);
                        }
                        return (List<T>)Convert.ChangeType(DB, typeof(T));

                    }
                    if (typeof(T) == typeof(Image))
                    {
                        if (all == true)
                            N = context.Image.Count();

                        var zaznamy = context.Image.Take(N);
                        List<Image> DB = new List<Image>();

                        foreach (Image I in zaznamy)
                        {
                            DB.Add(I);
                        }
                        return (List<T>)Convert.ChangeType(DB, typeof(T));

                    }

                    if (typeof(T) == typeof(Clanky))
                    {
                        if (all == true)
                            N = context.Clanky.Count();

                        var zaznamy = context.Clanky.Take(N);
                        List<Clanky> DB = new List<Clanky>();

                        foreach (Clanky Cl in zaznamy)
                        {
                            DB.Add(Cl);
                        }
                        
                        return (List<T>)Convert.ChangeType(DB, typeof(T));
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

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
                fileZDb = context.Files.FirstOrDefault(f => f.ID ==file.ID);
                fileZDb = file;
                context.SaveChanges();
            }
        }


        public static void Remove(int id)
        {
            using (hrebec_dataEntities context = new hrebec_dataEntities())
            {
                try
                {
                    if (typeof(T) == typeof(Files))
                    {
                        Files FileZDb = new Files();
                        FileZDb = context.Files.FirstOrDefault(c => c.ID == id);
                        context.Files.Remove(FileZDb);
                        context.SaveChanges();

                    }
                    if (typeof(T) == typeof(Image))
                    {
                        Image ImgZDb = new Image();
                        ImgZDb = context.Image.FirstOrDefault(c => c.ID == id);
                        context.Image.Remove(ImgZDb);
                        context.SaveChanges();
                    }

                    if (typeof(T) == typeof(Clanky))
                    {
                        Clanky cl = new Clanky();
                        cl = context.Clanky.FirstOrDefault(c => c.ID == id);
                        context.Clanky.Remove(cl);
                        context.SaveChanges();
                    }
                }
                catch
                {
                
                }
            }
         
        }


    }
}
