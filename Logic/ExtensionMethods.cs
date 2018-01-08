using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DateMate.Logic
{
    public static class ExtensionMethods
    {
        // Metod som kollar om två personer är vänner.
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
        
        // Metod som räknar hur många friend requests en användare har och returnerar en int med hur många.
        public static int CountFriendRequests(string id)
        {
            int count;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list  = db.FriendRequests.Where(x => x.To.Id == id);
                count = list.Count();
            }
            return count;
        }
        // En metod som hämtar nickname på en användare.
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

        // En metod som returnerar en user beroende på vilket id som skickas in.
        public static ApplicationUser GetUser(string id)
        {
            ApplicationUser user;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                 user = db.Users.Find(id);
            }
            return user;
        }

        //Kollar om en det finns en vänförfrågan mellan två användare.
        public static bool CheckRequest(string loggedUser, string friendUser)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var logged = db.Users.Find(loggedUser);

                var friend = db.Users.Find(friendUser);

                var friendList = db.FriendRequests.ToList();

                foreach (FriendRequest f in friendList)
                {
                    if ((f.To == logged && f.From == friend) || (f.To == friend && f.From == logged))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
