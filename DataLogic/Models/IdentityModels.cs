using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AdelsDating.Models;
using AdelsDating.Framework.Repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DataLogic.Models;

namespace Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }


        public byte[] ProfilePicture { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Display(Name = "Sökbar")]
        public bool Searchable { get; set; } = true;

        public virtual List<Interests> Interests { get; set; }

        public virtual List<Posts> Posts { get; set; }

        public virtual List<Friends> Friends { get; set; }

        public virtual List<FriendRequests> FriendRequests { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<FriendRequests> Requests { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}