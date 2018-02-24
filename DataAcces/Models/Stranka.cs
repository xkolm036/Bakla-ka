using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAcces.Models
{
   public class Stranka
    { 
            [AllowHtml]
            public string text { get; set; } = null;
            public string title { get; set; } = null;
     
    }
}
