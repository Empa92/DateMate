using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateMate.Logic
{
    public static class ExtensionMethods
    {
        public static bool CheckIfFriends(string loggedUser, string friendUser)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var logged = db.Users.Find(loggedUser);

                var friend = db.Users.Find(friendUser);

                var friendList = db.Friends.ToList();

                foreach(Friend f in friendList)
                {
                    if ((f.To == logged && f.From == friend) || (f.To == friend && f.From == logged))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static string GetNickName(string id)
        {
            var nickname = "";
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var user = db.Users.Find(id);
                nickname = user.NickName;

            }
            return nickname;
        }

        public static ApplicationUser GetUser(string id)
        {
            ApplicationUser user;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                 user = db.Users.Find(id);
            }
            return user;
        }
    }
}
