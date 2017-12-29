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
        // GET: Explore
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Explore()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult SeeProfile(string id)
        {
            var user = db.Users.Find(id);
            return View(user);
        }

        public FileContentResult Image(string id)
        {
            if (User.Identity.IsAuthenticated)
            {

                //if (id == null)
                //{
                //    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                //    byte[] imageData = null;
                //    FileInfo fileInfo = new FileInfo(fileName);
                //    long imageFileLength = fileInfo.Length;
                //    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //    BinaryReader br = new BinaryReader(fs);
                //    imageData = br.ReadBytes((int)imageFileLength);

                //    return File(imageData, "image/png");

                //}
                // to get the user details to load user Image
                var user = db.Users.Single(x => x.Id == id);

                return new FileContentResult(user.UserPhoto, "image/jpeg");
            }
            else
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }
    }
}