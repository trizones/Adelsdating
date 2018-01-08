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

        [HttpPost, ActionName("NewPost")]
        public void NewPost([System.Web.Http.FromBody] Posts Post)
        {
            if (Post.Message != "")
            {
                db.Posts.Add(Post);
                db.SaveChanges();
            }
        }
    }
}