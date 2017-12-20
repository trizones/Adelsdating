using AdelsDating.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdelsDating.Models
{
    public class Interests : IEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }

    }
}