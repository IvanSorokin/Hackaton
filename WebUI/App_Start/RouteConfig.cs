using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdvancedSearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Character", action = "AdvancedList", id = "" }
            );

            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{fieldName}/{fieldValue}",
                defaults: new { controller = "Character", action = "List", id = UrlParameter.Optional }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Character", action = "List", id = UrlParameter.Optional }
            );
           
        }
    }
}
