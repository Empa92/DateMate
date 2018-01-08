using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateMate.Controllers.API
{
    //ApiController som hanterar nya posts, skapar dem och skickar in dem i databasen.
    public class PostApiController : ApiController
    {
        public void Post(PostItem postItem)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
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
}