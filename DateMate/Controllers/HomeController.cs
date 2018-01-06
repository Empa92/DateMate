using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMate.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var users = from m in db.Users
                        select m;
            return View(users.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}