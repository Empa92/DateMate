using DateMate.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DateMate.Controllers
{
    public class FriendController : BaseController
    {
        // Metod för att skicka friend requests.
        public ActionResult SendFriendRequest(string id)
        {
            var user = User.Identity.GetUserId();

            var fromUser = db.Users.Find(user);

            var toUser = db.Users.Find(id);

            var friendrequest = new FriendRequest
            {
                To = toUser,
                From = fromUser
            };

            db.FriendRequests.Add(friendrequest);
            
            db.SaveChanges();

            return RedirectToAction("Explore", "Explore");
        }

        // Metod för att visa inloggade användarens friend requests.
        public ActionResult ShowFriendRequest()
        {
            var id = User.Identity.GetUserId();
            var request = db.FriendRequests.Where(x => x.To.Id == id);
            return View(request);
        }

        // Metod för att acceptera friend requests och sedan uppdatera databasen med de nya vännerna.
        public ActionResult AcceptRequest(int id)
        {
            var request = db.FriendRequests.Find(id);
            var friend1 = request.From;
            var friend2 = request.To;
            var friend = new Friend
            {
                From = friend1,
                To = friend2
            };
            db.Friends.Add(friend);
            db.FriendRequests.Remove(request);
            db.SaveChanges();

            return RedirectToAction("ShowFriendRequest");
        }

        // Metod för att ta bort en nekad friend request.
        public ActionResult DenyRequest(int id)
        {
            var request = db.FriendRequests.Find(id);
            db.FriendRequests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("ShowFriendRequest");
        }

        // Metod som visar den inloggades användare.
        // Eftersom en användare kan stå som både To och From i friends-tabellen har vi gjort så
        // att vi tittar på båda kolumnerna och kör en Union på dem.
        public ActionResult SeeFriends()
        {
            var id = User.Identity.GetUserId();
            var request = db.Friends.Where(x => x.To.Id == id && x.From.Id != id);
            var request2 = db.Friends.Where(x => x.From.Id == id && x.To.Id != id);
            var req = request.Union(request2).ToList();
            //var castedreq2 = (ApplicationUser)request2;
            //var friends = new MyFriendsViewModel { MyFriends = castedreq + castedreq2.ToString(); };
            return View(req);
        }

        public ActionResult RemoveFriend(int id)
        {
            var friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
            db.SaveChanges();
            return RedirectToAction("SeeFriends");

        }
    }
}