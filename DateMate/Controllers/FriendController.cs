using DateMate.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMate.Controllers
{
    public class FriendController : BaseController
    {

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
    }
}