using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wen.BooksStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Book", action = "Details" }
            );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{category}",
                defaults: new { controller = "Book", action = "Details" }
            );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{category}/{pageIndex}",
                defaults: new { controller = "Book", action = "Details", pageIndex = UrlParameter.Optional }
            );
        }
    }
}
