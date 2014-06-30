using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Druga",
                url: "{controller}/{action}/{code}",
                defaults: new { controller = "Home", action = "Index", code = UrlParameter.Optional }
            );

            /*routes.MapRoute(
                name: "Default2",
                url: "{action}",
                defaults: new { controller = "Home", action = "countries" }
            );*/

            /*
            routes.MapRoute(
                name: "countries",
                url: "Home/countries",
                defaults: new { controller = "Home", action = "countries" }
            );
            */


            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default2",
                url: "/{action}",
                defaults: new { controller = "Home"}
            );

            routes.MapRoute(
                name: "Druga",
                url: "{controller}/{action}/{id}"
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/
            /*
            routes.MapRoute(
                name: "/",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );*/
            /*routes.MapRoute(
                name: "/",
                url: "/",
                defaults: new { controller = "Home", action = "Index" }
            );
            /*routes.MapRoute(
                name: "/countries",
                url: "{controller}/countries",
                defaults: new { controller = "Home", action = "countries" }
            );*/
            /*routes.MapRoute(
                name: "aaaaa",
                url: "{action}",
                defaults: new { controller = "Home", action = "countries" }
            );*/
            
        }
    }
}