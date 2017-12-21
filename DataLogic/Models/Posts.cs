using AdelsDating.Framework.Repositories;
using Web.Models;

namespace AdelsDating.Models
{
    public class Posts : IEntity
    {
        public string Id { get; set; }
        public string Message { get; set; } 
        public virtual ApplicationUser From { get; set; }
        public virtual ApplicationUser To { get; set; }

    }
}