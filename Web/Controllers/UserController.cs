﻿using DataLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class UserController : BaseController.ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inlogged Page
        public ActionResult MyPage()
        {
            //Hämtar den inloggade användaren
            var loggedInUser = db.Users.Where(x => x.UserName == User.Identity.Name).Single();
            
            return View(loggedInUser);
        }

 
        public ActionResult UserPage(string nickname)
        {
            //Hämtar användaren som matchar användarnamnet, hämtat från sökfunktionen
            var user = db.Users.Where(x => x.Nickname.Equals(nickname)).Single();
            return View(user);
        }

        // GET: Search
        public ActionResult Search()
        {
            return View();
        }

        //Postar alla användare som matchar sökparametern
        [HttpPost]
        public ActionResult Search(string search)
        {
            //Hämtar alla användare som matchar parametern
            var loggedInUser = User.Identity.Name;
            var allUsers = db.Users.Where(x => x.Nickname.Contains(search) && x.Searchable == true && x.UserName != loggedInUser || search == null).ToList();
            
            return View(allUsers);
        }


    }
}