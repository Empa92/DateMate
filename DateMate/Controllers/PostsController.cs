using DateMate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMate.Controllers
{
    public class PostsController : BaseController
    {
        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Post()
        {
                var posts = db.Posts.ToList();
                return View(posts);
        }

        public ActionResult Create(string id)
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Post post, string id)
        //{

        //    var userName = User.Identity.Name;

        //    var user = db.Users.Single(x => x.UserName == userName);

        //    post.From = user;

        //    var toUser = db.Users.Single(x => x.Id == id);
        //    post.To = toUser;
        //    db.Posts.Add(post);
        //    db.SaveChanges();
        //    return View();
        //}
    }
}