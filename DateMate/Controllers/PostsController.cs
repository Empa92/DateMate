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
    }
}