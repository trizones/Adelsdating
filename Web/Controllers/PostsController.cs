using AdelsDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PostsController : BaseController.ApplicationBaseController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Inlägg
        public ActionResult Index()
        {
            return View(db.Posts.ToList());

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

        public class PostIndexViewModel
        {
            public string Id { get; set; }
            public ICollection<Posts> Posts { get; set; }
        }
    }
}