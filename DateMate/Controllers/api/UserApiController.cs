using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateMate.Controllers.API
{
    public class UserApiController : ApiController
    {
        [Route("Controller/api/UserApi/Get")]
        [HttpGet]
        public List<ApplicationUser> Get()
        {
            List<ApplicationUser> list = new List<ApplicationUser>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(db.Users.Find(i));
                }
            }
            return list;
        }
    }
}
