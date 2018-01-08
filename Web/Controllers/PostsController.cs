using AdelsDating.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PostsController : BaseController.ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }
        
        public ActionResult Index(string id) //Returnerar en lista med alla poster för en specifierad användare
        {
            var posts = db.Posts.Where(x => x.ToID == id).ToList();
            return View(new PostIndexViewModel { Id = id, Posts = posts });
        }

        public ActionResult Create(string id)
        {
            var toUser = db.Users.Single(x => x.Id == id);
            return View(toUser);
        }
/*
        [System.Web.Http.HttpPost]
        public ActionResult Create(Posts post, string id) //Skapar en ny post och sparar den i databasen
        {
            var userName = User.Identity.Name;

            var user = db.Users.Single(x => x.UserName == userName); //Hämtar inloggade användarens info

            post.FromID = user.Id;

            var toUser = db.Users.Single(x => x.Id == id); //Hämtar användaren som ska motta inlägget
            post.ToID = toUser.Id;

            db.Posts.Add(post);

            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
        }
*/
        
    }

    public class PostIndexViewModel //ViewModel för poster
    {
        public string Id { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}