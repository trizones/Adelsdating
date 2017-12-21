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
        // GET: User
        public ActionResult MyPage()
        {
            var db = new ApplicationDbContext();
            var users = db.Users.ToList();
            return View(users);
        }


    }
}