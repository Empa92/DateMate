using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        //public System.Data.Entity.DbSet<DateMate.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DateMate.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}