using AdelsDating.Framework.Repositories;
using Web.Models;

namespace DataLogic.Models
{
    public class Friends : IEntity
    {
        public int Id { get; set; }
        public ApplicationUser FriendId { get; set; }
    }
}
