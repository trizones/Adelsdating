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
        private ApplicationDbContext db = new ApplicationDbContext();


        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }

        // GET: Inlogged Page
        public ActionResult MyPage()
        {
            //Hämtar den inloggade användaren
            var loggedInUser = db.Users.Where(x => x.UserName == User.Identity.Name).Single();
            
            return View(loggedInUser);
        }

 
        public ActionResult UserPage(string id)
        {
            //Hämtar användaren som matchar användarnamnet, hämtat från sökfunktionen
            var user = db.Users.Where(x => x.Id.Equals(id)).Single();
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
            var loggedInUser = User.Identity.Name;
            var allUsers = db.Users.Where(x => x.Nickname.Contains(search) && x.Searchable == true && x.UserName != loggedInUser || search == null).ToList();
            
            return View(allUsers);
        }


        public ActionResult GetFriends()
        {
            //var allUsers = db.Users.ToList();
            var user = db.Users.Single(x => x.UserName == User.Identity.Name);
            var myFriends = db.Requests
                .Join(db.Users, r => r.ToUser.Id, u => u.Id, (r, u) => new { Request = r, Users = u })
                .Where(x => x.Request.FromUser.Id == user.Id && x.Request.Accepted == true)
                .Select(x => x.Users).ToList(); //Hämtar alla vänner där de accepterat din förfrågan

            var friendsWithMe = db.Requests
                .Join(db.Users, r => r.FromUser.Id, u => u.Id, (r, u) => new { Request = r, Users = u })
                .Where(x => x.Request.ToUser.Id == user.Id && x.Request.Accepted == true)
                .Select(x => x.Users).ToList(); // Hämtar alla vänner där du accepterat deras förfrågan

            var friends = myFriends.Concat(friendsWithMe); // Slår ihop listorna

            return View(friends);
        }


    }
}