using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index()
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