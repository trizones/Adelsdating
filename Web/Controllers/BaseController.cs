using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public class ApplicationBaseController : Controller
        {   
            //Hämta namnet från inloggad användare
            protected override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (User != null)
                {
                    var context = new ApplicationDbContext();
                    var username = User.Identity.Name;

                    if (!string.IsNullOrEmpty(username))
                    {
                        var user = context.Users.SingleOrDefault(u => u.UserName == username);
                        string fullName = string.Concat(new string[] { user.Firstname, " ", user.Lastname });
                        ViewData.Add("FullName", fullName);
                    }
                }
                base.OnActionExecuted(filterContext);
            }


            public ApplicationBaseController()
            { }
        }
    }
}