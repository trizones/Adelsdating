using AdelsDating.Models;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class InterestsController : BaseController.ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Interests anInterest, string id)
        {
            var userName = User.Identity.Name;

            var user = db.Users.Single(x => x.UserName == userName);

            anInterest.User = user;

            db.Interests.Add(anInterest);

            db.SaveChanges();

            return RedirectToAction("MyPage", "User");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}