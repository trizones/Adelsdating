using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Index() 
        {
            return View();
        }
        //Controller för att byta språk där man tar in en kulturparameter "sv", eller "en"
        public ActionResult Change(string LanguageAbbrevation)
        {
            if(LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);   
            }

            //Sparar valet i en cookie så webbläsaren kommer ihåg valet.
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbrevation;
            Response.Cookies.Add(cookie);

            return View("Index");
        }
    }
}