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
        
        public ActionResult MyPage() //Inloggade användarens egna sida
        {
            //Hämtar den inloggade användaren
            var loggedInUser = db.Users.Where(x => x.UserName == User.Identity.Name).Single();
            
            return View(loggedInUser);
        }
        
        public ActionResult UserPage(string id, string passedViewBag) //En speciferad användares sida
        {
            //Hämtar användaren som matchar användarnamnet, hämtat från sökfunktionen

            var otherUser = db.Users.Where(x => x.Id.Equals(id)).Single();
            var myUser = User.Identity.Name;

            var From = db.Users.Single(x => x.UserName == myUser);

            var a = db.Friends.Count(x => x.Friend1.UserName == From.UserName && x.Friend2.UserName == otherUser.UserName 
            || x.Friend2.UserName == From.UserName && x.Friend1.UserName == otherUser.UserName);  //Kollar om du och den inloggade användaren är vänner
            

            //Kollar om dom redan är kompisar
            if (a == 0)
            {
                if(passedViewBag == null) //Om man bara klickar genom sökningen så hamnar man inne i den här
                {
                    ViewBag.Message = "NotFriends";
                }
                else
                {
                    ViewBag.Message = passedViewBag; //Den kommer från friendrequestcontrollern
                }
               
            }
            else
            {
                if (passedViewBag == null)//Om man bara klickar genom sökningen så hamnar man inne i den här
                {
                    ViewBag.Message = "AlreadyFriends";
                }
                else
                {
                    ViewBag.Message = passedViewBag; //Den kommer från friendrequestcontrollern
                }

            }
            return View(otherUser);
        }
        
        public ActionResult Search()
        {
            return View();
        }

        //Postar alla användare som matchar sökparametern
        [HttpPost]
        public ActionResult Search(string search)
        {
            if(Request.IsAuthenticated) //Kollar om användaren är inloggad, om inte så skickas den till registreringssidan
            {
                //Hämtar alla användare som matchar parametern
                var loggedInUser = User.Identity.Name;
                var allUsers = db.Users.Where(x => x.Nickname.Contains(search) && x.Searchable == true && x.UserName != loggedInUser || search == null).ToList();
                
                return View(allUsers);
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }
            
        }
        
        public ActionResult GetFriends()
        {
            var user = db.Users.Single(x => x.UserName == User.Identity.Name); //Hämtar inloggade användaren
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