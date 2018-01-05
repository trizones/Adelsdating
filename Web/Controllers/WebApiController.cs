using AdelsDating.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class WebApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();

            base.Dispose(disposing);
        }

        //GET: Om det finns en friend request
        [System.Web.Http.HttpGet]
        public JsonResult HasRequest()
        {
            var user = db.Users.Single(x => x.UserName == User.Identity.Name);

            var amountRequests = db.Requests.Where(x => x.FromUser != user && x.Accepted == false).Count();

            var hasRequest = "FALSE";

            if(amountRequests > 0)
            {
                hasRequest = "true";
            }

            var result = new JsonResult();
            result.Data = new { hasRequest };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}