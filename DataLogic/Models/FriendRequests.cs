using AdelsDating.Framework.Repositories;
using Web.Models;

namespace AdelsDating.Models
{
    public class FriendRequests : IEntity
    {
        public int Id { get; set; }
        public bool Accepted { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser ToUser { get; set; }
    }
}
