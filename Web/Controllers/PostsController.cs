using AdelsDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using System.Data.Entity;

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

        // GET: Inlägg
        public ActionResult Index(string id)
        {
            var posts = db.Posts.Where(x => x.To.Id == id).ToList();
            return View(new PostIndexViewModel {  Id = id, Posts = posts});
        }

        public ActionResult Create(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Posts post, string id)
        {
            
                var userName = User.Identity.Name;

                var user = db.Users.Single(x => x.UserName == userName);

                post.From = user;

                var toUser = db.Users.Single(x => x.Id == id);
                post.To = toUser;

                db.Posts.Add(post);

                db.SaveChanges();

                return RedirectToAction("Index", new { id = id });
        }
    }

    public class PostIndexViewModel
    {
        public string Id { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}