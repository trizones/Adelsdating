using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class FriendRequestController : Controller
    {
        // GET: FriendRequest
        public ActionResult Index(string id)
        {
            var db = new ApplicationDbContext();
            return View();
        }

        public ActionResult SendRequest()
        {
            return View();
        }
    }
}