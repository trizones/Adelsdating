using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : BaseController.ApplicationBaseController
    {
        private ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

        // GET: Inlogged Page
        public ActionResult MyPage(ApplicationUser model)
        {
            //Hämtar den inloggade användaren
            return View(model);
        }

 
        public ActionResult UserPage(string nickname)
        {
            //Hämtar användaren som matchar användarnamnet, hämtat från sökfunktionen
            var user = ApplicationDbContext.Users.Where(x => x.Nickname.Equals(nickname));
            return View(user);
        }

        // GET: Search
        public ActionResult Search()
        {
            return View();
        }

        //Postar alla användare som matchar sökparametern
        [HttpPost]
        public ActionResult Search(string search)
        {
            //Hämtar alla användare som matchar parametern
            var allUsers = ApplicationDbContext.Users.Where(x => x.Nickname.Contains(search) && x.Searchable == true || search == null).ToList();
            
            return View(allUsers);
        }


    }
}