using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMate.Controllers
{
    public class HomeController : BaseController
    {
        // Visar användare på startsidan.
        public ActionResult Index()
        {
            var users = from m in db.Users
                        select m;
            return View(users.ToList());
        }
    }
}