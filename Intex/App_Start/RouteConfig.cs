using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Intex
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Email",
                url: "{controller}/{action}/{email}/{name}",
                defaults: new { controller = "Contact", action = "Email", email = UrlParameter.Optional, name = UrlParameter.Optional }
                );
        }
    }
}
