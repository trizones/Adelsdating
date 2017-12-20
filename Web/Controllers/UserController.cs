using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserController : BaseController.ApplicationBaseController
    {
        // GET: User
        public ActionResult MyPage()
        {
            return View();
        }


    }
}