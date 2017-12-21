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
        private ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();

        // GET: Inlogged Page
        public ActionResult MyPage()
        {
            return View();
        }

 
        public ActionResult UserPage(string nickname)
        {
            var user = ApplicationDbContext.Users.Where(x => x.Nickname.Equals(nickname));
            
            return View(user);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            //Hämtar alla användare som matchar parametern
            var allUsers = ApplicationDbContext.Users.Where(x => x.Nickname.Contains(search) || search == null).ToList();
            
            return View(allUsers);
        }


    }
}