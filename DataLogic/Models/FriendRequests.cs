using AdelsDating.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.Models
{
    public class FriendRequests : IEntity
    {
        public int FromUser { get; set; }
        public bool Accepted { get; set; }
        public string Id { get; set; }
    }
}
