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
        public DbSet<Friend> Friends { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        //public System.Data.Entity.DbSet<DateMate.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<DateMate.Models.ApplicationUser> ApplicationUsers { get; set; }
    }

    //public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    //{
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        var store = new UserStore<ApplicationUser>(context);

    //        var userManager = new ApplicationUserManager(store);

    //        for (int i = 0; i < 20; i++)
    //        {

    //            var user = new ApplicationUser { NickName = "user" + i, UserName = $"user{i}@gmail.com", Email = $"user{i}@gmail.com", Location = $"N13{i}0", Fabric = $"{i}0%-Polyester", Searchable = true};

    //            userManager.CreateAsync(user, "User1!").Wait();
    //        }


    //        base.Seed(context);
    //    }
    //}
}