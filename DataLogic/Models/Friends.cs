using AdelsDating.Framework.Repositories;

namespace DataLogic.Models
{
    public class Friends : IEntity
    {
        public string Id { get; set; }
        public int FriendId { get; set; }
    }
}
