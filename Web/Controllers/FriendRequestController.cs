using AdelsDating.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using System.Data.Entity;
using DataLogic.Models;

namespace Web.Controllers
{
    public class FriendRequestController : BaseController.ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index(string name) //Returnerar en specifik användares vänförfrågningar
        {
            ApplicationUser aUser = db.Users.Single(x => x.UserName == name);
            List<FriendRequests> requests = db.Requests.Where(x => x.ToUser.Id == aUser.Id && x.Accepted == false).ToList();
            return View(new PostFriendRequestViewModel { Id = aUser.Id, Requests = requests});
        }

        public ActionResult SendRequest(string id)
        {
            return View();
        }

        //Skapar en request och sparar den i databasen
        [HttpPost]
        public ActionResult SendRequest(FriendRequests request, string id)
        {
            try
            {
                var passViewBag = ""; 

                var userName = User.Identity.Name;
                var From = db.Users.Single(x => x.UserName == userName);
                request.FromUser = From;
                var To = db.Users.Single(x => x.Id == id);
                request.ToUser = To;

                //Kollar om dom redan är kompisar
                if (db.Requests.Count(x => x.FromUser.UserName == From.UserName && x.ToUser.UserName == To.UserName || x.ToUser.UserName
                 == To.UserName && x.FromUser.UserName == From.UserName) == 0)
                {
                    //Är dom inte det, spara requesten
                    db.Requests.Add(request);             
                    db.SaveChanges();
                    passViewBag = "SentRequest"; //Skickar vidare viewbagen till usercontrollern
                }
                else
                {
                    passViewBag = "AlreadySentRequest"; //Skickar vidare viewbagen till usercontrollern
                }
                return RedirectToAction("UserPage", "User", routeValues: new { id = To.Id, passedViewBag = passViewBag });
            }
            catch
            {
                return View("SendRequestMessage", "FriendRequest");
            }
            
        }
        
        public ActionResult AcceptRequest(int requestId) //Logik för att acceptera en vänförfrågan
        { 
            var request = db.Requests.Single(x => x.Id == requestId); //Hittar den specifika requesten med hjälp av parametern 

            var userSentRequest = request.FromUser;
            var loggedinUser = request.ToUser;

            Friends friendsTable = new Friends
            {
                Friend1 = (userSentRequest),
                Friend2 = (loggedinUser)
            };

            db.Friends.Add(friendsTable);

            request.Accepted = true;

            db.Entry(request).State = EntityState.Modified; //Beskriver för databasen att den ska ändra något i databasen

            db.SaveChanges();

            return RedirectToAction("Index", routeValues: new { name = request.ToUser.UserName});
        }

        
    }
    public class PostFriendRequestViewModel //ViewModel för friendrequests
    {
        public string Id { get; set; }
        public ICollection<FriendRequests> Requests { get; set; }
    }
}