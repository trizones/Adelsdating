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
        
    }

    public class PostIndexViewModel //ViewModel för poster
    {
        public string Id { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}