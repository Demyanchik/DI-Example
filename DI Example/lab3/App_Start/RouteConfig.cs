using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MyRoute",
                url: "{controller}/{action}",
                defaults: new { controller = "Dict", action = "Index" }
            );

            //Можно 404 обработать так
            routes.MapRoute(
                 name: "ALL",
                 url: "{*catchall}",
                 defaults: new { controller = "Dict", action = "Default" }
             );
        }
    }
}
