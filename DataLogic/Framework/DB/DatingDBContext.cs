using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace DataLogic.Framework.DB
{
    class DatingDBContext : IdentityDbContext<ApplicationUser>
    {
        public DatingDBContext() : base("AdelsDB")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
