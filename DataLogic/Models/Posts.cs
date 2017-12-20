using AdelsDating.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdelsDating.Models
{
    public class Posts : IEntity
    {
        public string Id { get; set; }
        
        public string Content { get; set; } 

    }

}