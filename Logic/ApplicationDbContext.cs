using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Logic;

namespace DateMate.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DateMate", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        //public System.Data.Entity.DbSet<DateMate.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DateMate.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}