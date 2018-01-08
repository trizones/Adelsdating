using AdelsDating.Framework.Repositories;
using Web.Models;

namespace AdelsDating.Models
{
    public class Posts : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; } 
        public string FromID { get; set; }
        public string ToID { get; set; }
        public string FromUserNickname { get; set; }

    }
}