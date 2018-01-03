using AdelsDating.Framework.Repositories;
using Web.Models;

namespace AdelsDating.Models
{
    public class Interests : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}