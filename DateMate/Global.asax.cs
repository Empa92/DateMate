using DateMate.App_Start;
using DateMate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DateMate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {   
            Database.SetInitializer(new MyInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebbApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}
