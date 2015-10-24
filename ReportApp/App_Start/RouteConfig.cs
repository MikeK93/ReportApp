using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ReportApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Report", action = "Index", day = DateTime.Now.Day, month = DateTime.Now.Month, year = DateTime.Now.Year }
            );

            routes.MapRoute(
                name: "Report_Error",
                url: "DateNotFound",
                defaults: new { controller = "Report", action = "WrongDate" }
            );

            routes.MapRoute(
                name: "ReportForDate",
                url: "{day}/{month}/{year}",
                defaults: new { controller = "Report", action = "Index", day = 0, month = 0, year = 0 }
            );
        }
    }
}
