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
            //Hämtar tre slumpmässiga användare och skickar in dom index-viewn
            var allUsers = ApplicationDbContext.Users.Where(c => c.Searchable == true).OrderBy(x => Guid.NewGuid()).Take(3).Distinct();
            return View(allUsers);
        }

        
        //Returnerar en profilbild

        public FileContentResult UserPicture(string id)
        {
            
                // Hämtar profilbilden som matchar användarnamnet
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == id).FirstOrDefault();
                if(userImage.ProfilePicture != null)
                {
                return new FileContentResult(userImage.ProfilePicture, "image/jpeg");
                }
                
                else
                {
                string fileName = HttpContext.Server.MapPath(@"~/Images/crown.png"); //Fetch an empty examplepicture

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
                }

        }

        public FileContentResult ProfilePicture()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    String userId = User.Identity.GetUserId(); //Get the inlogged user ID, to tie the correct profilepicture

                    if (userId == null) //If no userID is found
                    {
                        string fileName = HttpContext.Server.MapPath(@"~/Images/crown.png"); //Fetch an empty examplepicture

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

                    if (userImage.ProfilePicture.Length < 1)
                    {
                        string fileName = HttpContext.Server.MapPath(@"~/Images/crown.png"); //Fetch an empty examplepicture

                        byte[] imageData = null;
                        FileInfo fileInfo = new FileInfo(fileName);
                        long imageFileLength = fileInfo.Length;
                        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        imageData = br.ReadBytes((int)imageFileLength);

                        return File(imageData, "image/png");
                    }

                    return new FileContentResult(userImage.ProfilePicture, "image/jpeg");
                }
                else
                {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/crown.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");

                }
            }
            catch 
            {
                return null;
                ViewBag.FelStorlek = "För stor bild.";
            }
           
        }



    }

}
