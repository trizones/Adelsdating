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
                        
                        string userName = user.UserName;
                        ViewData.Add("userName", userName);

                        string nickName = user.Nickname;
                        ViewData.Add("nickName", nickName);

                        string firstName = user.Firstname;
                        ViewData.Add("firstName", firstName);

                        string lastName = user.Lastname;
                        ViewData.Add("lastName", lastName);

                        string fullName = string.Concat(firstName," ",lastName);
                        ViewData.Add("fullName", fullName);

                        var friendrequests = context.Requests.Where(u => u.ToUser.UserName == username);

                        foreach (var hasRequest in friendrequests)
                        {
                            if (!hasRequest.Accepted)
                            {

                                string newFriend = "Vänförfrågan inc!";
                                var value = ViewData["newFriend"];
                                if (value == null)
                                {
                                    ViewData.Add("newFriend", newFriend);
                                }
                                else if (value.Equals(""))
                                {
                                    ViewData.Add("newFriend", newFriend);
                                }                           
                                
                            }
                            else
                            {
                                var value = ViewData["noFriend"];
                                string noFriend = "";
                                
                                if (value == null)
                                {
                                    ViewData.Add("noFriend", noFriend);
                                }
                                else if (value.Equals("Vänförfrågan inc!"))
                                {
                                    ViewData.Add("noFriend", noFriend);
                                }

                             
                                

                            }
                        }
                        

                        
                    }
                }
                base.OnActionExecuted(filterContext);
            }
        }
    }
}