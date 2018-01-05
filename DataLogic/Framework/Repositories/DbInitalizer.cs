using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace DataLogic.Framework.Repositories
{

        public class DbInitizalizer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        {
            protected override void Seed(ApplicationDbContext db)
            {
                db.Users.Add(new ApplicationUser { UserName = "Kingen@kungahuset.se", Email = "Kingen@Kungahuset.se", Firstname = "Carl", Lastname = "XVI Gustaf", Nickname = "Kingen" });
                db.Users.Add(new ApplicationUser { UserName = "Carl.Philip@kungahuset.se", Email = "Carl.Philip@Kungahuset.se", Firstname = "Carl", Lastname = "Philip", Nickname = "Flexarn" });
                db.Users.Add(new ApplicationUser { UserName = "VonLaxnacke@kungahuset.se", Email = "VonLaxnacke@Kungahuset.se", Firstname = "Noppe", Lastname = "Von Laxnacke", Nickname = "Jägarn" });
                db.Users.Add(new ApplicationUser { UserName = "OlofAfSilvfersked@kungahuset.se", Email = "OlofAfSilfversked@Kungahuset.se", Firstname = "Olof", Lastname = "Af Silfversked", Nickname = "Silfverskeden" });

                db.SaveChanges();
                base.Seed(db);
            }
        }

}
