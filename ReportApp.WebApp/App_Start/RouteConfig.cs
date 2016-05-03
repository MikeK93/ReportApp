using System.Web.Mvc;
using System.Web.Routing;

namespace ReportApp.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "ReportApi",
                url: "report/api/{action}",
                defaults: new
                {
                    controller = "ReportApi",
                    title = UrlParameter.Optional,
                    moneySpent = UrlParameter.Optional,
                    description = UrlParameter.Optional,
                    tags = UrlParameter.Optional,
                    date = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{day}/{month}/{year}",
                defaults: new
                {
                    controller = "Report",
                    action = "Index",
                    day = UrlParameter.Optional,
                    month = UrlParameter.Optional,
                    year = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Report_Error",
                url: "DateNotFound",
                defaults: new { controller = "Report", action = "WrongDate" }
            );
        }
    }
}
