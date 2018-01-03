using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMate.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public ApplicationUser Users { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}