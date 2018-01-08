using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMate.Controllers
{
    public class ExploreController : BaseController
    {
        private List<ApplicationUser> users;
        // GET: Explore
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Explore()
        {
            var users = from m in db.Users select m;
            users = users.Where(s => s.Searchable == true);
            return View(users.ToList());
        }



        public ActionResult SeeProfile(string id)
        {
            var user = db.Users.Find(id);
            var posts = db.Posts.Include(x => x.From).Where(x => x.To.Id == id).ToList();
            return View(new ProfileViewModel { Id = id, Users = user, Posts = posts });
        }

        
        public ActionResult Explore(string searchString)
        {
            var users = from m in db.Users
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.NickName.Contains(searchString) && s.Searchable == true);
            }

            return View(users.ToList());
        }
    }
    
}