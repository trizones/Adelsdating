using AdelsDating.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using System.Data.Entity;

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
        
        public ActionResult Index(string name)
        {
            ApplicationUser aUser = db.Users.Single(x => x.UserName == name);
            List<FriendRequests> requests = db.Requests.Where(x => x.ToUser.Id == aUser.Id && x.Accepted == false).ToList();
            return View(new PostFriendRequestViewModel { Id = aUser.Id, Requests = requests});
        }

        public ActionResult SendRequest(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendRequest(FriendRequests request, string id)
        {
            try
            {
                var userName = User.Identity.Name;

                var From = db.Users.Single(x => x.UserName == userName);

                request.FromUser = From;

                var To = db.Users.Single(x => x.Id == id);
                request.ToUser = To;

                db.Requests.Add(request);

                db.SaveChanges();

                return RedirectToAction("UserPage", "User", routeValues: new { nickname = To.Nickname });
            }
            catch
            {

                return RedirectToAction("UserPage", "User", new { Message = "Du måste skriva in något." });
            }
            
        }

        public ActionResult AcceptRequest(string requestId)
        {
            var request = db.Requests.Single(x => x.Id == requestId);

            request.Accepted = true;

            db.Entry(request).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index", routeValues: new { name = request.ToUser.UserName});
        }

        
    }
    public class PostFriendRequestViewModel
    {
        public string Id { get; set; }
        public ICollection<FriendRequests> Requests { get; set; }
    }
}