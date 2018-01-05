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

        
        public JsonResult HasRequest()
        {
            var user = db.Users.Single(x => x.UserName == User.Identity.Name);

            var hasRequest = false;

            var Requests = db.Requests.Where(x => x.FromUser == user || x.ToUser == user && x.Accepted == false);
            
            if(Requests.Count() > 0)
            {
                hasRequest = true;
            }
            string hej = "";
            return Json(hasRequest, JsonRequestBehavior.AllowGet);
        }

        private JsonResult Json(bool hasRequest, JsonRequestBehavior allowGet)
        {
            throw new NotImplementedException();
        }
    }
}