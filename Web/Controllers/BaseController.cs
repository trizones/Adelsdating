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
            //Hämta olika properties från inloggad användare
            protected override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (User != null)
                {
                    var context = new ApplicationDbContext();
                    var username = User.Identity.Name;

                    if (!string.IsNullOrEmpty(username))
                    {
                        var user = context.Users.SingleOrDefault(u => u.UserName == username);
                        string nickName = user.Nickname;
                        ViewData.Add("nickName", nickName);
                 
                        string firstName = user.Firstname;
                        ViewData.Add("firstName", firstName);

                        string lastName = user.Firstname;
                        ViewData.Add("lastName", lastName);
                    }
                }
                base.OnActionExecuted(filterContext);
            }
        }
    }
}