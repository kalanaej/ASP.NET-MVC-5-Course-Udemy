using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

// Install this using "Install-Package Microsoft.AspNet.WebApi.WebHost" command
using System.Web.Http;

// Mapper support libraries
using Vidly.App_Start;
using AutoMapper;

namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Start mapper when starting the app
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            // This line copied from Controller/Api/readme.txt
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
