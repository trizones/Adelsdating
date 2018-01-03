using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController.ApplicationBaseController
    {
        private ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            //Hämtar alla användare i databasen
            var allUsers = ApplicationDbContext.Users.OrderBy(x => Guid.NewGuid()).Take(3);
            return View(allUsers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()   
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        //Returnerar en profilbild

        public FileContentResult UserPicture(String nickname)
        {
            
                // Hämtar profilbilden som matchar användarnamnet
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Nickname == nickname).FirstOrDefault();

                return new FileContentResult(userImage.ProfilePicture, "image/jpeg");

        }

        public FileContentResult ProfilePicture()
        {
            if (User.Identity.IsAuthenticated)
            {
                String userId = User.Identity.GetUserId(); //Get the inlogged user ID, to tie the correct profilepicture

                if (userId == null) //If no userID is found
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png"); //Fetch an empty examplepicture

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                }
                // to get the user details to load user Image
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.ProfilePicture, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }



    }

}
