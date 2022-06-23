using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapMvcAttributeRoutes();


            //routes.MapRoute(
            //    "MoviesByReleaseDate",
            //    "Movies/released/{year}/{month}",
            //    new {controller="Movies",action="ByReleasedDate" },
            //    new {year=@"2021|2022",month= @"\d{2}"}   
            //    ); //anonymous type

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
