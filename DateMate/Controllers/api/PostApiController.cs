using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateMate.Controllers.API
{
    public class PostApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Post(PostItem postItem)
        {
            Post post = new Post
            {
                To = db.Users.Find(postItem.To),
                From = db.Users.Find(postItem.From),
                Text = postItem.Text
            };

            db.Posts.Add(post);
            db.SaveChanges();
        }
    }
}